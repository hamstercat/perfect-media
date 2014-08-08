using System.Collections.Generic;

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
