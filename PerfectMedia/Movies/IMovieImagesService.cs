
using System.Threading.Tasks;
namespace PerfectMedia.Movies
{
    /// <summary>
    /// Handles fanart and poster images for a specific movie.
    /// </summary>
    public interface IMovieImagesService
    {
        /// <summary>
        /// Updates the images of the movie located at the specified path.
        /// </summary>
        /// <param name="path">The movie path.</param>
        /// <param name="movie">The movie metadata.</param>
        Task Update(string path, FullMovie movie);

        /// <summary>
        /// Deletes the images of the movie located at the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        void Delete(string path);
    }
}
