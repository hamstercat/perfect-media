using System.Collections.Generic;

namespace PerfectMedia.TvShows.Metadata
{
    public class AvailableTvShowImages
    {
        public IEnumerable<Image> Fanarts { get; set; }
        public IEnumerable<Image> Posters { get; set; }
        public IEnumerable<Image> Banners { get; set; }
        public IDictionary<int, AvailableSeasonImages> Seasons { get; set; }

        public AvailableTvShowImages()
        {
            Fanarts = new List<Image>();
            Posters = new List<Image>();
            Banners = new List<Image>();
            Seasons = new Dictionary<int, AvailableSeasonImages>();
        }
    }
}
