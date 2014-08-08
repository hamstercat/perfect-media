using System.Collections.Generic;

namespace PerfectMedia.TvShows
{
    public class TvShowImages
    {
        public string Fanart { get; set; }
        public string Poster { get; set; }
        public string Banner { get; set; }
        public IEnumerable<Season> Seasons { get; set; }

        public TvShowImages()
        {
            Seasons = new List<Season>();
        }
    }
}
