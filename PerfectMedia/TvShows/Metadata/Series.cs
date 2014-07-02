using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    public class Series
    {
        public string SeriesId { get; set; }
        public string Language { get; set; }
        public string SeriesName { get; set; }
        public string Banner { get; set; }
        public string Overview { get; set; }
        public DateTime FirstAired { get; set; }
    }
}
