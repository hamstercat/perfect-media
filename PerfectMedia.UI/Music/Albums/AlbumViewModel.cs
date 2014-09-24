using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.Music;
using PerfectMedia.Music.Albums;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Music.Artists;
using PerfectMedia.UI.Music.Tracks;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.Validations;

namespace PerfectMedia.UI.Music.Albums
{
    public class AlbumViewModel : MediaViewModel<ITrackViewModel>, IAlbumViewModel
    {
        private readonly IMusicFileService _musicFileService;
        private readonly IAlbumMetadataService _metadataService;
        private readonly IMusicViewModelFactory _viewModelFactory;
        private readonly IBusyProvider _busyProvider;
        private readonly IArtistViewModel _artistViewModel;

        public string Path { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

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

        [RequiredCached]
        public IPropertyViewModel<string> Title { get; private set; }

        [LocalizedRequired]
        public string Id { get; set; }

        public DashDelimitedCollectionViewModel<string> Genres { get; private set; }
        public string Label { get; set; }
        public DashDelimitedCollectionViewModel<string> Moods { get; private set; }
        public double? Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Review { get; set; }
        public DashDelimitedCollectionViewModel<string> Styles { get; private set; }
        public DashDelimitedCollectionViewModel<string> Themes { get; private set; }
        public string Type { get; set; }
        public int? Year { get; set; }

        public AlbumViewModel(IMusicFileService musicFileService,
            IAlbumMetadataService metadataService,
            IMusicViewModelFactory viewModelFactory,
            IBusyProvider busyProvider,
            IDialogViewer dialogViewer,
            IProgressManagerViewModel progressManager,
            IKeyDataStore keyDataStore,
            IArtistViewModel artistViewModel,
            string path)
            : base(busyProvider, dialogViewer, viewModelFactory.GetTrack("dummy"))
        {
            _musicFileService = musicFileService;
            _metadataService = metadataService;
            _viewModelFactory = viewModelFactory;
            _busyProvider = busyProvider;
            _artistViewModel = artistViewModel;
            Title = new RequiredPropertyDecorator<string>(new StringCachedPropertyDecorator(keyDataStore, path));
            Path = path;

            Genres = new DashDelimitedCollectionViewModel<string>(s => s);
            Moods = new DashDelimitedCollectionViewModel<string>(s => s);
            Styles = new DashDelimitedCollectionViewModel<string>(s => s);
            Themes = new DashDelimitedCollectionViewModel<string>(s => s);

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager, busyProvider);
            SaveCommand = new SaveMetadataCommand(this);
            DeleteCommand = new DeleteMetadataCommand(this);
        }

        protected override async Task LoadChildrenInternal()
        {
            IEnumerable<TrackFile> tracks = await _musicFileService.GetTracks(Path);
            foreach (TrackFile track in tracks)
            {
                ITrackViewModel trackViewModel = _viewModelFactory.GetTrack(track.Path);
                Children.Add(trackViewModel);
            }
        }

        protected override async Task RefreshInternal()
        {
            var metadata = await _metadataService.Get(Path);
            RefreshFromMetadata(metadata);
        }

        protected override async Task<IEnumerable<ProgressItem>> UpdateInternal()
        {
            List<ProgressItem> items = new List<ProgressItem>();
            foreach (ProgressItem item in await _artistViewModel.Update())
            {
                items.Add(item);
            }

            await Refresh();
            if (string.IsNullOrEmpty(Title.Value))
            {
                Lazy<string> displayName = new Lazy<string>(() => DisplayName);
                items.Add(new ProgressItem(Path, displayName, UpdateMethod));
            }
            return items;
        }

        protected override async Task SaveInternal()
        {
            Title.Save();
            AlbumMetadata metadata = CreateMetadata();
            await _metadataService.Save(Path, metadata);
        }

        protected override async Task DeleteInternal()
        {
            await _metadataService.Delete(Path);
        }

        private void RefreshFromMetadata(AlbumMetadata metadata)
        {
            Genres.ReplaceWith(metadata.Genres);
            Label = metadata.Label;
            Id = metadata.Mbid;
            Moods.ReplaceWith(metadata.Moods);
            Rating = metadata.Rating;
            ReleaseDate = metadata.ReleaseDate;
            Review = metadata.Review;
            Styles.ReplaceWith(metadata.Styles);
            Themes.ReplaceWith(metadata.Themes);
            Title.Value = metadata.Title;
            Title.Save();
            Type = metadata.Type;
            Year = metadata.Year;
        }

        private AlbumMetadata CreateMetadata()
        {
            return new AlbumMetadata
            {
                //Artists
                Genres = Genres.Collection.ToList(),
                Label = Label,
                Mbid = Id,
                Moods = Moods.Collection.ToList(),
                Rating = Rating,
                ReleaseDate = ReleaseDate,
                Review = Review,
                Styles = Styles.Collection.ToList(),
                Themes = Themes.Collection.ToList(),
                Title = Title.Value,
                //Tracks
                Type = Type,
                Year = Year
            };
        }

        private async Task UpdateMethod()
        {
            using (_busyProvider.DoWork())
            {
                await _metadataService.Update(Path, _artistViewModel.Id);
                await Refresh();
            }
        }
    }
}