using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.Validation;
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
        public ICommand DeleteCommand { get; private set; }

        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(Title.CachedValue))
                {
                    return System.IO.Path.GetFileName(Path);
                }
                return Title.CachedValue;
            }
        }

        [Rating]
        public double? Rating { get; set; }

        [RequiredCached]
        public ICachedPropertyViewModel<string> Title { get; private set; }

        [LocalizedRequired]
        public string Id { get; set; }

        [Positive]
        public int? RuntimeInMinutes { get; set; }

        public ObservableCollection<ActorViewModel> Actors { get; set; }
        public int State { get; set; }
        public string MpaaRating { get; set; }
        public DashDelimitedCollectionViewModel<string> Genres { get; set; }
        public string ImdbId { get; set; }
        public string Plot { get; set; }
        public DateTime? PremieredDate { get; set; }
        public string Studio { get; set; }
        public string Language { get; set; }

        public TvShowMetadataViewModel(ITvShowViewModelFactory viewModelFactory,
            ITvShowMetadataService metadataService,
            IProgressManagerViewModel progressManager,
            IBusyProvider busyProvider,
            string path)
        {
            _viewModelFactory = viewModelFactory;
            _metadataService = metadataService;
            _busyProvider = busyProvider;
            _lazyLoaded = false;

            Title = viewModelFactory.GetStringCachedProperty(path);
            Title.PropertyChanged += TitleValueChanged;
            Path = path;

            Images = viewModelFactory.GetTvShowImages(this, path);
            Actors = new ObservableCollection<ActorViewModel>();
            Genres = new DashDelimitedCollectionViewModel<string>(s => s);

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager, busyProvider);
            SaveCommand = new SaveMetadataCommand(this);
            DeleteCommand = new DeleteMetadataCommand(this);
        }

        public async Task Refresh()
        {
            using (_busyProvider.DoWork())
            {
                TvShowMetadata metadata = await _metadataService.Get(Path);
                await RefreshFromMetadata(metadata);
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
                    return new List<ProgressItem> { new ProgressItem(Path, displayName, UpdateInternal) };
                }
                await RefreshFromMetadata(metadata);
                return Enumerable.Empty<ProgressItem>();
            }
        }

        public async Task Save()
        {
            using (_busyProvider.DoWork())
            {
                Title.Save();
                TvShowMetadata metadata = CreateMetadata();
                await _metadataService.Save(Path, metadata);
            }
        }

        public async Task Delete()
        {
            using (_busyProvider.DoWork())
            {
                await _metadataService.Delete(Path);
                await Refresh();
            }
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

        private async Task RefreshFromMetadata(TvShowMetadata metadata)
        {
            State = metadata.State;
            Title.Value = metadata.Title;
            Title.Save();
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
            await Images.Refresh();
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
