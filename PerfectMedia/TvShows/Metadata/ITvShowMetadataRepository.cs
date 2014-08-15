
using System.Threading.Tasks;
namespace PerfectMedia.TvShows.Metadata
{
    /// <summary>
    /// Repository for TV shows metadata based on XBMC .nfo files.
    /// </summary>
    public interface ITvShowMetadataRepository
    {
        /// <summary>
        /// Gets the path to the .nfo file.
        /// </summary>
        /// <param name="path">The TV show folder path.</param>
        /// <returns></returns>
        Task<TvShowMetadata> Get(string path);

        /// <summary>
        /// Gets the metadata associated with the TV show located at the specified path.
        /// </summary>
        /// <param name="path">The TV show folder path.</param>
        /// <param name="metadata">The metadata.</param>
        Task Save(string path, TvShowMetadata metadata);

        /// <summary>
        /// Deletes the metadata associated with the TV show located at the specified path.
        /// </summary>
        /// <param name="path">The TV show folder path.</param>
        void Delete(string path);
    }
}
