using System.Collections.Generic;

namespace PerfectMedia.Movies
{
    internal class SearchMovieResult
    {
        public int Page { get; set; }
        public List<Movie> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
}
