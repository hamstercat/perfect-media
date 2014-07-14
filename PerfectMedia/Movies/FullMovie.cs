using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    public class FullMovie
    {
        public string BackdropPath { get; set; }
        public string BelongsToCollection { get; set; }
        public List<Genre> Genres { get; set; }
        public string ImdbId { get; set; }
        public string OriginalTitle { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public List<StudioCompany> ProductionCompanies { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public string Tagline { get; set; }
        public double? VoteAverage { get; set; }
    }
}
