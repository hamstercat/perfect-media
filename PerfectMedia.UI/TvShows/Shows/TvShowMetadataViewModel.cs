using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PropertyChanged;

namespace PerfectMedia.UI.TvShows.Shows
{
    [ImplementPropertyChanged]
    public class TvShowMetadataViewModel : BaseViewModel, ITvShowMetadataViewModel
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly ITvShowMetadataService _metadataService;
        private readonly IBusyProvider _busyProvider;
        private bool _lazyLoaded;

        public string Path { get; private set; }
        public ITvShowImagesViewModel Images { get; private set; }

        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(Title.Value))
                {
                    return System.IO.Path.GetFileName(Path);
                }
                return Title.Value;
            }
        }

        #region Metadata
        public ICachedPropertyViewModel<string> Title { get; private set; }
        public ObservableCollection<ActorViewModel> Actors { get; set; }
        public int State { get; set; }
        public string Id { get; set; }
        public string MpaaRating { get; set; }
        public DashDelimitedCollectionViewModel<string> Genres { get; set; }
        public string ImdbId { get; set; }
        public string Plot { get; set; }
        public int RuntimeInMinutes { get; set; }
        public double? Rating { get; set; }
        public DateTime? PremieredDate { get; set; }
        public string Studio { get; set; }
        public string Language { get; set; }
        #endregion

        public TvShowMetadataViewModel(ITvShowViewModelFactory viewModelFactory,
            ITvShowMetadataService metadataService,
            IProgressManagerViewModel progressManager,
            IBusyProvider busyProvider,
            string path)
        {
            _viewModelFactory = viewModelFactory;
            _metadataService = metadataService;
            _busyProvider = busyProvider;
            Path = path;
            _lazyLoaded = false;

            Title = viewModelFactory.GetCachedProperty(path, s => s, s => s);
            Title.PropertyChanged += TitleValueChanged;

            Images = viewModelFactory.GetTvShowImages(this, path);
            Actors = new ObservableCollection<ActorViewModel>();
            Genres = new DashDelimitedCollectionViewModel<string>(s => s);

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager, busyProvider);
            SaveCommand = new SaveMetadataCommand(this);
        }

        public async Task Refresh()
        {
            using (_busyProvider.DoWork())
            {
                TvShowMetadata metadata = await _metadataService.Get(Path);
                RefreshFromMetadata(metadata);
                await Images.Refresh();
            }
        }

        public async Task<IEnumerable<ProgressItem>> Update()
        {
            using (_busyProvider.DoWork())
            {
                TvShowMetadata metadata = await _metadataService.Get(Path);
                if (string.IsNullOrEmpty(metadata.Id))
                {
                    Lazy<string> displayName = new Lazy<string>(() => DisplayName);
                    return new List<ProgressItem> {new ProgressItem(Path, displayName, UpdateInternal)};
                }
                return Enumerable.Empty<ProgressItem>();
            }
        }

        public Task Save()
        {
            return Task.Run(() =>
            {
                using (_busyProvider.DoWork())
                {
                    TvShowMetadata metadata = CreateMetadata();
                    _metadataService.Save(Path, metadata);
                }
            });
        }

        public async Task Load()
        {
            if (!_lazyLoaded)
            {
                _lazyLoaded = true;
                await Refresh();
            }
        }

        private void TitleValueChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("Title");
            OnPropertyChanged("DisplayName");
        }

        private void RefreshFromMetadata(TvShowMetadata metadata)
        {
            State = metadata.State;
            Title.Value = metadata.Title;
            Id = metadata.Id;
            MpaaRating = metadata.MpaaRating;
            ImdbId = metadata.ImdbId;
            Plot = metadata.Plot;
            RuntimeInMinutes = metadata.RuntimeInMinutes;
            Rating = metadata.Rating;
            PremieredDate = metadata.Premiered;
            Studio = metadata.Studio;
            Language = metadata.Language;

            Genres.ReplaceWith(metadata.Genres);
            AddActors(metadata.Actors);
        }

        private void AddActors(IEnumerable<ActorMetadata> actors)
        {
            Actors.Clear();
            foreach (ActorMetadata actor in actors)
            {
                ActorViewModel actorViewModel = new ActorViewModel(_viewModelFactory.GetImage(true));
                actorViewModel.Name = actor.Name;
                actorViewModel.Role = actor.Role;
                actorViewModel.ThumbUrl = actor.Thumb;
                actorViewModel.ThumbPath.Path = actor.ThumbPath;
                Actors.Add(actorViewModel);
            }
        }

        private TvShowMetadata CreateMetadata()
        {
            TvShowMetadata metadata = new TvShowMetadata
            {
                State = State,
                Title = Title.Value,
                Id = Id,
                MpaaRating = MpaaRating,
                ImdbId = ImdbId,
                Plot = Plot,
                RuntimeInMinutes = RuntimeInMinutes,
                Rating = Rating,
                Premiered = PremieredDate,
                Studio = Studio,
                Language = Language,
                Genres = new List<string>(Genres.Collection)
            };

            metadata.Actors = new List<ActorMetadata>();
            foreach (ActorViewModel actorViewModel in Actors)
            {
                ActorMetadata actor = new ActorMetadata
                {
                    Name = actorViewModel.Name,
                    Role = actorViewModel.Role,
                    Thumb = actorViewModel.ThumbUrl,
                    ThumbPath = actorViewModel.ThumbPath.Path
                };
                metadata.Actors.Add(actor);
            }

            return metadata;
        }

        private async Task UpdateInternal()
        {
            using (_busyProvider.DoWork())
            {
                await _metadataService.Update(Path);
                await Refresh();
            }
        }
    }
}
