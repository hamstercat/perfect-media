using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.TvShows.Metadata
{
    public class AvailableTvShowImages
    {
        public IEnumerable<Image> Fanarts { get; set; }
        public IEnumerable<Image> Posters { get; set; }
        public IEnumerable<Image> Banners { get; set; }
        public IDictionary<int, AvailableSeasonImages> Seasons { get; set; }
    }
}
