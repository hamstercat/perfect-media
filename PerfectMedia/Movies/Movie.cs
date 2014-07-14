using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    public class Movie
    {
        public string BackdropPath { get; set; }
        public string Id { get; set; }
        public string OriginalTitle { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string PosterPath { get; set; }
        public double? VoteAverage { get; set; }
    }
}
