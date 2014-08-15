
using System.Threading.Tasks;
namespace PerfectMedia.Movies
{
    /// <summary>
    /// Repository for movie metadata based on XBMC .nfo files.
    /// </summary>
    public interface IMovieMetadataRepository
    {
        /// <summary>
        /// Gets the path to the .nfo file.
        /// </summary>
        /// <param name="path">The movie file path.</param>
        /// <returns></returns>
        Task<MovieMetadata> Get(string path);

        /// <summary>
        /// Gets the metadata associated with the movie located at the specified path.
        /// </summary>
        /// <param name="path">The movie file path.</param>
        /// <param name="metadata">The metadata.</param>
        Task Save(string path, MovieMetadata metadata);

        /// <summary>
        /// Deletes the metadata associated with the movie located at the specified path.
        /// </summary>
        /// <param name="path">The movie file path.</param>
        void Delete(string path);
    }
}
