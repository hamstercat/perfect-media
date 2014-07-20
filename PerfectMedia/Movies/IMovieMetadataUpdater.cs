using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    public interface IMovieMetadataUpdater
    {
        IEnumerable<Movie> FindMovies(string name);
        FullMovie GetMovieMetadata(string movieId);
        AvailableMovieImages FindImages(string movieId);
        AvailableMovieImages FindSetImages(string setName);
        MovieActorsResult FindCast(string movieId);
        string FindCertification(string movieId);
    }
}
