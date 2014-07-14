using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
