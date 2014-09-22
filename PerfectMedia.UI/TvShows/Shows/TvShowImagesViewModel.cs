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
        private bool _seasonImagesLoaded;

        public IImageViewModel FanartUrl { get; private set; }
        public IImageViewModel PosterUrl { get; private set; }
        public IImageViewModel BannerUrl { get; private set; }
        public ObservableCollection<ISeasonImagesViewModel> SeasonImages { get; private set; }

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
            SeasonImages = new ObservableCollection<ISeasonImagesViewModel>();

            FanartUrl = viewModelFactory.GetImage(true, new FanartImageStrategy(metadataService, metadataViewModel));
            PosterUrl = viewModelFactory.GetImage(true, new PosterImageStrategy(metadataService, metadataViewModel));
            BannerUrl = viewModelFactory.GetImage(false, new BannerImageStrategy(metadataService, metadataViewModel));
        }

        public async Task Refresh()
        {
            using (_busyProvider.DoWork())
            {
                await InitialLoadSeasonImages();
                ForceInitialLoadTvShowImages();
            }
        }

        private void ForceInitialLoadTvShowImages()
        {
            FanartUrl.RefreshImage(Path.Combine(_path, "fanart.jpg"));
            PosterUrl.RefreshImage(Path.Combine(_path, "poster.jpg"));
            BannerUrl.RefreshImage(Path.Combine(_path, "banner.jpg"));
            foreach (ISeasonImagesViewModel season in SeasonImages)
            {
                season.Refresh();
            }
        }

        private async Task InitialLoadSeasonImages()
        {
            if (!_seasonImagesLoaded)
            {
                _seasonImagesLoaded = true;
                SeasonImages.Clear();
                IEnumerable<Season> seasons = await _tvShowFileService.GetSeasons(_path);
                foreach (Season season in seasons)
                {
                    LoadSeason(season);
                }
            }
        }

        private void LoadSeason(Season season)
        {
            ISeasonImagesViewModel viewModel = _viewModelFactory.GetSeasonImages(_path, season.Path);
            viewModel.BannerUrl.Path = season.BannerUrl;
            viewModel.PosterUrl.Path = season.PosterUrl;
            viewModel.SeasonNumber = season.SeasonNumber;
            SeasonImages.Add(viewModel);
        }
    }
}
