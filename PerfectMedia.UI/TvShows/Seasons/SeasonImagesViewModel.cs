using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.TvShows.Seasons
{
    [ImplementPropertyChanged]
    public class SeasonImagesViewModel
    {
        public string PosterUrl { get; set; }
        public string BannerUrl { get; set; }
        public int SeasonNumber { get; set; }
    }
}
