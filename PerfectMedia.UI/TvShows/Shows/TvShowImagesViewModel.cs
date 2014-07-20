using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.TvShows.Seasons;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.TvShows.Shows
{
    [ImplementPropertyChanged]
    public class TvShowImagesViewModel : ITvShowImagesViewModel
    {
        private ITvShowFileService _tvShowFileService;
        private readonly ITvShowMetadataService _metadataService;
        private readonly IFileSystemService _fileSystemService;
        private readonly string _path;

        private bool _tvShowImagesLoaded;

        private ImageViewModel _fanartUrl;
        public ImageViewModel FanartUrl
        {
            get
            {
                InitialLoadTvShowImages();
                return _fanartUrl;
            }
        }

        private ImageViewModel _posterUrl;
        public ImageViewModel PosterUrl
        {
            get
            {
                InitialLoadTvShowImages();
                return _posterUrl;
            }
        }

        private ImageViewModel _bannerUrl;
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
            ITvShowMetadataViewModel metadataViewModel,
            string path)
        {
            _tvShowFileService = tvShowFileService;
            _metadataService = metadataService;
            _fileSystemService = fileSystemService;
            _path = path;
            _tvShowImagesLoaded = false;

            _fanartUrl = new ImageViewModel(fileSystemService, new FanartImageStrategy(metadataService, metadataViewModel));
            _posterUrl = new ImageViewModel(fileSystemService, new PosterImageStrategy(metadataService, metadataViewModel));
            _bannerUrl = new ImageViewModel(fileSystemService, new BannerImageStrategy(metadataService, metadataViewModel));
        }

        public void Refresh()
        {
            ForceInitialLoadTvShowImages();
            InitialLoadSeasonImages();
        }

        private void InitialLoadTvShowImages()
        {
            if (!_tvShowImagesLoaded)
            {
                _tvShowImagesLoaded = true;
                ForceInitialLoadTvShowImages();
            }
        }

        private void ForceInitialLoadTvShowImages()
        {
            FanartUrl.Path = Path.Combine(_path, "fanart.jpg");
            PosterUrl.Path = Path.Combine(_path, "poster.jpg");
            BannerUrl.Path = Path.Combine(_path, "banner.jpg");
        }

        private void InitialLoadSeasonImages()
        {
            if (_seasonImages == null)
            {
                _seasonImages = new ObservableCollection<SeasonImagesViewModel>();
            }
            _seasonImages.Clear();
            IEnumerable<Season> seasons = _tvShowFileService.GetSeasons(_path);
            foreach (Season season in seasons)
            {
                LoadSeason(season);
            }
        }

        private void LoadSeason(Season season)
        {
            SeasonImagesViewModel viewModel = new SeasonImagesViewModel(_fileSystemService, _metadataService, _path, season.Path);
            viewModel.BannerUrl.Path = season.BannerUrl;
            viewModel.PosterUrl.Path = season.PosterUrl;
            viewModel.SeasonNumber = season.SeasonNumber;
            _seasonImages.Add(viewModel);
        }
    }
}
