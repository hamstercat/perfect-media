using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.ViewModels.TvShows
{
    public class TvShowImagesViewModel : BaseViewModel
    {
        private ITvShowFileService _tvShowFileService;
        private readonly ITvShowMetadataService _metadataService;
        private readonly string _path;

        private bool _tvShowImagesLoaded;

        private string _fanartUrl;
        public string FanartUrl
        {
            get
            {
                if (!_tvShowImagesLoaded)
                {
                    _tvShowImagesLoaded = true;
                    InitialLoadTvShowImages();
                }
                return _fanartUrl;
            }
            set
            {
                _fanartUrl = value;
                OnPropertyChanged("FanartUrl");
            }
        }

        private string _posterUrl;
        public string PosterUrl
        {
            get
            {
                if (!_tvShowImagesLoaded)
                {
                    _tvShowImagesLoaded = true;
                    InitialLoadTvShowImages();
                }
                return _posterUrl;
            }
            set
            {
                _posterUrl = value;
                OnPropertyChanged("PosterUrl");
            }
        }

        private string _bannerUrl;
        public string BannerUrl
        {
            get
            {
                if (!_tvShowImagesLoaded)
                {
                    _tvShowImagesLoaded = true;
                    InitialLoadTvShowImages();
                }
                return _bannerUrl;
            }
            set
            {
                _bannerUrl = value;
                OnPropertyChanged("BannerUrl");
            }
        }

        private ObservableCollection<SeasonImagesViewModel> _seasonImages;
        public INotifyCollectionChanged SeasonImages
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

        public TvShowImagesViewModel(ITvShowFileService tvShowFileService, ITvShowMetadataService metadataService, string path)
        {
            _tvShowFileService = tvShowFileService;
            _metadataService = metadataService;
            _path = path;
            _tvShowImagesLoaded = false;
        }

        public void Refresh()
        {
            InitialLoadTvShowImages();
            InitialLoadSeasonImages();
        }

        private void InitialLoadTvShowImages()
        {
            FanartUrl = Path.Combine(_path, "fanart.jpg");
            PosterUrl = Path.Combine(_path, "poster.jpg");
            BannerUrl = Path.Combine(_path, "banner.jpg");
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
                SeasonImagesViewModel viewModel = new SeasonImagesViewModel
                {
                    BannerUrl = season.BannerUrl,
                    PosterUrl = season.PosterUrl,
                    SeasonNumber = season.SeasonNumber
                };
                _seasonImages.Add(viewModel);
            }
        }
    }
}
