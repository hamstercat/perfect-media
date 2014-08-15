using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    /// <summary>
    /// Retrieves movie metadata.
    /// </summary>
    public interface IMovieMetadataUpdater
    {
        /// <summary>
        /// Finds the movies.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        Task<IEnumerable<Movie>> FindMovies(string name);

        /// <summary>
        /// Gets the movie metadata.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        /// <returns></returns>
        Task<FullMovie> GetMovieMetadata(string movieId);

        /// <summary>
        /// Finds the images.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        /// <returns></returns>
        Task<AvailableMovieImages> FindImages(string movieId);

        /// <summary>
        /// Finds the set images.
        /// </summary>
        /// <param name="setName">Name of the set.</param>
        /// <returns></returns>
        Task<AvailableMovieImages> FindSetImages(string setName);

        /// <summary>
        /// Finds the cast.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        /// <returns></returns>
        Task<MovieActorsResult> FindCast(string movieId);

        /// <summary>
        /// Finds the certification.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        /// <returns></returns>
        Task<string> FindCertification(string movieId);
    }
}
