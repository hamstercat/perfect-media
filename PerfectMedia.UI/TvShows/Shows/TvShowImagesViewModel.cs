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
    public class TvShowImagesViewModel : BaseViewModel, ITvShowImagesViewModel
    {
        private readonly ITvShowFileService _tvShowFileService;
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly IBusyProvider _busyProvider;
        private readonly string _path;

        private bool _tvShowImagesLoaded;

        private readonly IImageViewModel _fanartUrl;
        public IImageViewModel FanartUrl
        {
            get
            {
                InitialLoadTvShowImages();
                return _fanartUrl;
            }
        }

        private readonly IImageViewModel _posterUrl;
        public IImageViewModel PosterUrl
        {
            get
            {
                InitialLoadTvShowImages();
                return _posterUrl;
            }
        }

        private readonly IImageViewModel _bannerUrl;
        public IImageViewModel BannerUrl
        {
            get
            {
                InitialLoadTvShowImages();
                return _bannerUrl;
            }
        }

        private ObservableCollection<ISeasonImagesViewModel> _seasonImages;
        public ObservableCollection<ISeasonImagesViewModel> SeasonImages
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
            ITvShowViewModelFactory viewModelFactory,
            ITvShowViewModel metadataViewModel,
            IBusyProvider busyProvider,
            string path)
        {
            _tvShowFileService = tvShowFileService;
            _viewModelFactory = viewModelFactory;
            _busyProvider = busyProvider;
            _path = path;
            _tvShowImagesLoaded = false;

            _fanartUrl = viewModelFactory.GetImage(true, new FanartImageStrategy(metadataService, metadataViewModel));
            _posterUrl = viewModelFactory.GetImage(true, new PosterImageStrategy(metadataService, metadataViewModel));
            _bannerUrl = viewModelFactory.GetImage(false, new BannerImageStrategy(metadataService, metadataViewModel));
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
            FanartUrl.RefreshImage(Path.Combine(_path, "fanart.jpg"));
            PosterUrl.RefreshImage(Path.Combine(_path, "poster.jpg"));
            BannerUrl.RefreshImage(Path.Combine(_path, "banner.jpg"));
            foreach (SeasonImagesViewModel season in SeasonImages)
            {
                season.Refresh();
            }
        }

        private async Task InitialLoadSeasonImages()
        {
            if (_seasonImages == null)
            {
                _seasonImages = new ObservableCollection<ISeasonImagesViewModel>();
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
            ISeasonImagesViewModel viewModel = _viewModelFactory.GetSeasonImages(_path, season.Path);
            viewModel.BannerUrl.Path = season.BannerUrl;
            viewModel.PosterUrl.Path = season.PosterUrl;
            viewModel.SeasonNumber = season.SeasonNumber;
            _seasonImages.Add(viewModel);
        }
    }
}
