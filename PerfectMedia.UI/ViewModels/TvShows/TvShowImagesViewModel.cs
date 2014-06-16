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
        private readonly ITvShowMetadataService _tvShowMetadataService;
        private readonly string _path;

        private readonly bool _tvShowImagesLoaded;

        private string _fanartUrl;
        public string FanartUrl
        {
            get
            {
                InitialLoadTvShowImages();
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
                InitialLoadTvShowImages();
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
                InitialLoadTvShowImages();
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
                InitialLoadSeasonImages();
                return _seasonImages;
            }
        }

        public TvShowImagesViewModel(ITvShowMetadataService tvShowMetadataService, string path)
        {
            _tvShowMetadataService = tvShowMetadataService;
            _path = path;
            _tvShowImagesLoaded = false;
        }

        private void InitialLoadTvShowImages()
        {
            if (!_tvShowImagesLoaded)
            {
                TvShowImages images = _tvShowMetadataService.GetLocalImages(_path);
                _fanartUrl = images.FanartUrl;
                _bannerUrl = images.BannerUrl;
                _posterUrl = images.PosterUrl;
            }
        }

        private void InitialLoadSeasonImages()
        {
            if (_seasonImages == null)
            {
                _seasonImages = new ObservableCollection<SeasonImagesViewModel>();
                IEnumerable<SeasonImages> images = _tvShowMetadataService.GetLocalSeasonImages(_path);
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
}
