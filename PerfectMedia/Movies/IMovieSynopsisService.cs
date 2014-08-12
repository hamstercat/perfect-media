
namespace PerfectMedia.Movies
{
    /// <summary>
    /// Finds plot, outline and tagline for a specific movie.
    /// </summary>
    public interface IMovieSynopsisService
    {
        /// <summary>
        /// Gets the synopsis.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        /// <returns></returns>
        MovieSynopsis GetSynopsis(string movieId);
    }
}
