using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    public interface IMovieSynopsisService
    {
        MovieSynopsis GetSynopsis(string movieId);
    }
}
