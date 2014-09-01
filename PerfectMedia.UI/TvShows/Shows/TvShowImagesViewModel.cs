using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.TvShows.Seasons;
using PropertyChanged;

namespace PerfectMedia.UI.TvShows.Shows
{
    [ImplementPropertyChanged]
    public class TvShowImagesViewModel : ITvShowImagesViewModel
    {
        private readonly ITvShowFileService _tvShowFileService;
        private readonly ITvShowMetadataService _metadataService;
        private readonly IFileSystemService _fileSystemService;
        private readonly IBusyProvider _busyProvider;
        private readonly string _path;

        private bool _tvShowImagesLoaded;

        private readonly ImageViewModel _fanartUrl;
        public ImageViewModel FanartUrl
        {
            get
            {
                InitialLoadTvShowImages();
                return _fanartUrl;
            }
        }

        private readonly ImageViewModel _posterUrl;
        public ImageViewModel PosterUrl
        {
            get
            {
                InitialLoadTvShowImages();
                return _posterUrl;
            }
        }

        private readonly ImageViewModel _bannerUrl;
        public ImageViewModel BannerUrl
        {
            get
            {
                InitialLoadTvShowImages();
                return _bannerUrl;
            }
        }

        private ObservableCollection<SeasonImagesViewModel> _seasonImages;
        public ObservableCollection<SeasonImagesViewModel> SeasonImages
        {
            get
            {
                if (_seasonImages == null)
                {
                    InitialLoadSeasonImages();
                }
                return _seasonImages;
            }
        }

        public TvShowImagesViewModel(ITvShowFileService tvShowFileService,
            ITvShowMetadataService metadataService,
            IFileSystemService fileSystemService,
            ITvShowViewModel metadataViewModel,
            IBusyProvider busyProvider,
            string path)
        {
            _tvShowFileService = tvShowFileService;
            _metadataService = metadataService;
            _fileSystemService = fileSystemService;
            _busyProvider = busyProvider;
            _path = path;
            _tvShowImagesLoaded = false;

            _fanartUrl = new ImageViewModel(fileSystemService, _busyProvider, true, new FanartImageStrategy(metadataService, metadataViewModel));
            _posterUrl = new ImageViewModel(fileSystemService, _busyProvider, true, new PosterImageStrategy(metadataService, metadataViewModel));
            _bannerUrl = new ImageViewModel(fileSystemService, _busyProvider, false, new BannerImageStrategy(metadataService, metadataViewModel));
        }

        public async Task Refresh()
        {
            using (_busyProvider.DoWork())
            {
                ForceInitialLoadTvShowImages();
                await InitialLoadSeasonImages();
            }
        }

        private void InitialLoadTvShowImages()
        {
            using (_busyProvider.DoWork())
            {
                if (!_tvShowImagesLoaded)
                {
                    _tvShowImagesLoaded = true;
                    ForceInitialLoadTvShowImages();
                }
            }
        }

        private void ForceInitialLoadTvShowImages()
        {
            FanartUrl.Path = Path.Combine(_path, "fanart.jpg");
            PosterUrl.Path = Path.Combine(_path, "poster.jpg");
            BannerUrl.Path = Path.Combine(_path, "banner.jpg");
        }

        private async Task InitialLoadSeasonImages()
        {
            if (_seasonImages == null)
            {
                _seasonImages = new ObservableCollection<SeasonImagesViewModel>();
            }
            _seasonImages.Clear();
            IEnumerable<Season> seasons = await _tvShowFileService.GetSeasons(_path);
            foreach (Season season in seasons)
            {
                LoadSeason(season);
            }
        }

        private void LoadSeason(Season season)
        {
            SeasonImagesViewModel viewModel = new SeasonImagesViewModel(_fileSystemService, _metadataService, _busyProvider, _path, season.Path);
            viewModel.BannerUrl.Path = season.BannerUrl;
            viewModel.PosterUrl.Path = season.PosterUrl;
            viewModel.SeasonNumber = season.SeasonNumber;
            _seasonImages.Add(viewModel);
        }
    }
}
