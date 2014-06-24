using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows
{
    public class TvShowImages
    {
        public string Fanart { get; set; }
        public string Poster { get; set; }
        public string Banner { get; set; }
        public IEnumerable<Season> Seasons { get; set; }
    }
}
