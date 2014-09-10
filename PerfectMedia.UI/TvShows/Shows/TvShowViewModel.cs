using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Actors;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Seasons;
using PerfectMedia.UI.TvShows.ShowSelection;
using PerfectMedia.UI.Validations;
using PropertyChanged;

namespace PerfectMedia.UI.TvShows.Shows
{
    [ImplementPropertyChanged]
    public class TvShowViewModel : MediaViewModel<ISeasonViewModel>, ITvShowViewModel
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly ITvShowFileService _tvShowFileService;
        private readonly ITvShowMetadataService _metadataService;
        private readonly IBusyProvider _busyProvider;

        public override string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(Title.OriginalValue))
                {
                    return System.IO.Path.GetFileName(Path);
                }
                return Title.OriginalValue;
            }
        }

        [Rating]
        public double? Rating { get; set; }

        [RequiredCached]
        public IPropertyViewModel<string> Title { get; private set; }

        [LocalizedRequired]
        public string Id { get; set; }

        [Positive]
        public int? RuntimeInMinutes { get; set; }

        [ActorsValid]
        public IActorManagerViewModel ActorManager { get; private set; }

        public int State { get; set; }
        public string MpaaRating { get; set; }
        public DashDelimitedCollectionViewModel<string> Genres { get; set; }
        public string ImdbId { get; set; }
        public string Plot { get; set; }
        public DateTime? PremieredDate { get; set; }
        public string Studio { get; set; }
        public string Language { get; set; }

        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public string Path { get; private set; }
        public ITvShowImagesViewModel Images { get; private set; }
        public ITvShowSelectionViewModel Selection { get; private set; }

        public TvShowViewModel(ITvShowViewModelFactory viewModelFactory,
            ITvShowFileService tvShowFileService,
            ITvShowMetadataService metadataService,
            IBusyProvider busyProvider,
            IDialogViewer dialogViewer,
            IProgressManagerViewModel progressManager,
            IKeyDataStore keyDataStore,
            string path)
            : base(busyProvider, dialogViewer)
        {
            _viewModelFactory = viewModelFactory;
            _tvShowFileService = tvShowFileService;
            _metadataService = metadataService;
            _busyProvider = busyProvider;
            Title = new RequiredPropertyDecorator<string>(new StringCachedPropertyDecorator(keyDataStore, path));
            Title.PropertyChanged += TitleValueChanged;
            Path = path;
            Selection = viewModelFactory.GetTvShowSelection(this, path);

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager, busyProvider);
            SaveCommand = new SaveMetadataCommand(this);
            DeleteCommand = new DeleteMetadataCommand(this);

            Images = viewModelFactory.GetTvShowImages(this, path);
            ActorManager = viewModelFactory.GetActorManager(path, () => OnPropertyChanged("ActorManager"));
            Genres = new DashDelimitedCollectionViewModel<string>(s => s);

            // We need to set a "dummy" item in the collection for an arrow to appear in the TreeView since we're lazy-loading the items under it
            Children.Add(_viewModelFactory.GetSeason(this, "dummy"));
        }

        protected override async Task RefreshInternal()
        {
            TvShowMetadata metadata = await _metadataService.Get(Path);
            await RefreshFromMetadata(metadata);
        }

        protected override async Task<IEnumerable<ProgressItem>> UpdateInternal()
        {
            await Refresh();
            if (string.IsNullOrEmpty(Id))
            {
                Lazy<string> displayName = new Lazy<string>(() => DisplayName);
                return new List<ProgressItem> { new ProgressItem(Path, displayName, UpdateMethod) };
            }
            return Enumerable.Empty<ProgressItem>();
        }

        protected override async Task SaveInternal()
        {
            Title.Save();
            await ActorManager.Save();
            TvShowMetadata metadata = CreateMetadata();
            await _metadataService.Save(Path, metadata);
        }

        protected override async Task DeleteInternal()
        {
            await _metadataService.Delete(Path);
            await Refresh();
        }

        protected override async Task LoadChildrenInternal()
        {
            IEnumerable<Season> seasons = await _tvShowFileService.GetSeasons(Path);
            foreach (Season season in seasons)
            {
                ISeasonViewModel seasonViewModel = _viewModelFactory.GetSeason(this, season.Path);
                Children.Add(seasonViewModel);
            }
        }

        public async Task<IEnumerable<ProgressItem>> FindNewEpisodes()
        {
            using (_busyProvider.DoWork())
            {
                await LoadChildren();
                List<ProgressItem> items = new List<ProgressItem>();
                foreach (ISeasonViewModel season in Children)
                {
                    items.AddRange(await season.FindNewEpisodes());
                }
                return items;
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
            ActorManager.Initialize(TransformActors(metadata.Actors));
            await Images.Refresh();
        }

        private IEnumerable<IActorViewModel> TransformActors(IEnumerable<ActorMetadata> actors)
        {
            foreach (ActorMetadata actor in actors)
            {
                ActorViewModel actorViewModel = new ActorViewModel(_viewModelFactory.GetImage(true));
                actorViewModel.Initialize(actor.Name, actor.Role);
                actorViewModel.ThumbUrl = actor.Thumb;
                actorViewModel.ThumbPath.Path = actor.ThumbPath;
                yield return actorViewModel;
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
            foreach (IActorViewModel actorViewModel in ActorManager.Actors)
            {
                ActorMetadata actor = new ActorMetadata
                {
                    Name = actorViewModel.Name.Value,
                    Role = actorViewModel.Role.Value,
                    Thumb = actorViewModel.ThumbUrl,
                    ThumbPath = actorViewModel.ThumbPath.Path
                };
                metadata.Actors.Add(actor);
            }

            return metadata;
        }

        private async Task UpdateMethod()
        {
            using (_busyProvider.DoWork())
            {
                await _metadataService.Update(Path);
                await Refresh();
            }
        }
    }
}
