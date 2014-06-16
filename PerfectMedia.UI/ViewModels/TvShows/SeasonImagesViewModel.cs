using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.ViewModels.TvShows
{
    public class SeasonImagesViewModel : BaseViewModel
    {
        private string _posterUrl;
        public string PosterUrl
        {
            get
            {
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
                return _bannerUrl;
            }
            set
            {
                _bannerUrl = value;
                OnPropertyChanged("BannerUrl");
            }
        }

        private int _seasonNumber;
        public int SeasonNumber
        {
            get
            {
                return _seasonNumber;
            }
            set
            {
                _seasonNumber = value;
                OnPropertyChanged("SeasonNumber");
            }
        }
    }
}
