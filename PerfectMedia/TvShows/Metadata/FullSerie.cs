using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    public class FullSerie
    {
        public string Id { get; set; }
        public string Actors { get; set; }
        public string ContentRating { get; set; }
        public DateTime? FirstAired { get; set; }
        public string Genre { get; set; }
        public string ImdbId { get; set; }
        public string Language { get; set; }
        public string Network { get; set; }
        public string Overview { get; set; }
        public double? Rating { get; set; }
        public int Runtime { get; set; }
        public string SeriesName { get; set; }
        public string Status { get; set; }
        public string Banner { get; set; }
        public string Fanart { get; set; }
        public string Poster { get; set; }
    }
}
