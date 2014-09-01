using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Episodes;
using PerfectMedia.UI.TvShows.Shows;
using PropertyChanged;

namespace PerfectMedia.UI.TvShows.Seasons
{
    [ImplementPropertyChanged]
    public class SeasonViewModel : TreeViewItemViewModel, ISeasonViewModel
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly ITvShowFileService _tvShowFileService;
        private readonly ITvShowViewModel _tvShowMetadata;
        private readonly IBusyProvider _busyProvider;
        private readonly string _path;
        private bool _imagesLoaded;

        public override string DisplayName
        {
            get
            {
                return System.IO.Path.GetFileName(_path);
            }
        }

        private readonly IImageViewModel _posterUrl;
        public IImageViewModel PosterUrl
        {
            get
            {
                LoadImages();
                return _posterUrl;
            }
        }

        private readonly IImageViewModel _bannerUrl;
        public IImageViewModel BannerUrl
        {
            get
            {
                LoadImages();
                return _bannerUrl;
            }
        }

        public ObservableCollection<IEpisodeViewModel> Episodes { get; private set; }

        public SeasonViewModel(ITvShowViewModelFactory viewModelFactory,
            ITvShowFileService tvShowFileService,
            ITvShowViewModel tvShowMetadata,
            ITvShowMetadataService metadataService,
            IBusyProvider busyProvider,
            string path)
            : base(busyProvider)
        {
            _viewModelFactory = viewModelFactory;
            _tvShowFileService = tvShowFileService;
            _tvShowMetadata = tvShowMetadata;
            _busyProvider = busyProvider;
            _path = path;

            _posterUrl = viewModelFactory.GetImage(true, new SeasonPosterImageStrategy(metadataService, tvShowMetadata.Path, path));
            _bannerUrl = viewModelFactory.GetImage(false, new SeasonBannerImageStrategy(metadataService, tvShowMetadata.Path, path));

            // We need to set a "dummy" item in the collection for an arrow to appear in the TreeView since we're lazy-loading the items under it
            _imagesLoaded = false;
            Episodes = new ObservableCollection<IEpisodeViewModel> { _viewModelFactory.GetEpisode(_tvShowMetadata, "dummy") };
        }

        public async Task<IEnumerable<ProgressItem>> FindNewEpisodes()
        {
            using (_busyProvider.DoWork())
            {
                await LoadChildren();
                List<ProgressItem> items = new List<ProgressItem>();
                foreach (IEpisodeViewModel episode in Episodes)
                {
                    items.AddRange(await episode.Update());
                }
                return items;
            }
        }

        protected override Task LoadInternal()
        {
            // Do nothing
            return Task.Delay(0);
        }

        protected override async Task LoadChildrenInternal()
        {
            // Delete the dummy object
            Episodes.Clear();

            IEnumerable<PerfectMedia.TvShows.Episode> episodes = await _tvShowFileService.GetEpisodes(_path);
            foreach (PerfectMedia.TvShows.Episode episode in episodes)
            {
                IEpisodeViewModel episodeViewModel = _viewModelFactory.GetEpisode(_tvShowMetadata, episode.Path);
                Episodes.Add(episodeViewModel);
            }
        }

        private void LoadImages()
        {
            using (_busyProvider.DoWork())
            {
                if (!_imagesLoaded)
                {
                    Season season = _tvShowFileService.GetSeason(_tvShowMetadata.Path, _path);
                    _imagesLoaded = true;
                    PosterUrl.Path = season.PosterUrl;
                    BannerUrl.Path = season.BannerUrl;
                }
            }
        }
    }
}
