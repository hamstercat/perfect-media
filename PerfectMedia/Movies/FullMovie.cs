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
        public MovieSet BelongsToCollection { get; set; }
        public List<Reference> Genres { get; set; }
        public string ImdbId { get; set; }
        public string OriginalTitle { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public List<Reference> ProductionCompanies { get; set; }
        public List<Reference> ProductionCountries { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public string Tagline { get; set; }
        public double? VoteAverage { get; set; }

        // Not returned by Themoviedb first API call
        public string Plot { get; set; }
        public string Certification { get; set; }
    }
}
