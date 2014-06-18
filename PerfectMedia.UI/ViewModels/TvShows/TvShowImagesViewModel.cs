using PerfectMedia.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.ViewModels.TvShows
{
    public class TvShowImagesViewModel : BaseViewModel
    {
        private readonly ITvShowLocalMetadataService _tvShowLocalMetadataService;
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

        public TvShowImagesViewModel(ITvShowLocalMetadataService tvShowLocalMetadataService, string path)
        {
            _tvShowLocalMetadataService = tvShowLocalMetadataService;
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
            TvShowImages images = _tvShowLocalMetadataService.GetLocalImages(_path);
            FanartUrl = images.FanartUrl;
            BannerUrl = images.BannerUrl;
            PosterUrl = images.PosterUrl;
        }

        private void InitialLoadSeasonImages()
        {
            if (_seasonImages == null)
            {
                _seasonImages = new ObservableCollection<SeasonImagesViewModel>();
            }
            _seasonImages.Clear();
            IEnumerable<SeasonImages> images = _tvShowLocalMetadataService.GetLocalSeasonImages(_path);
            foreach (SeasonImages seasonImage in images)
            {
                SeasonImagesViewModel viewModel = new SeasonImagesViewModel
                {
                    BannerUrl = seasonImage.BannerUrl,
                    PosterUrl = seasonImage.PosterUrl,
                    SeasonNumber = seasonImage.SeasonNumber
                };
                _seasonImages.Add(viewModel);
            }
        }
    }
}
