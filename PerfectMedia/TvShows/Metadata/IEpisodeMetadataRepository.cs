
using System.Threading.Tasks;
namespace PerfectMedia.TvShows.Metadata
{
    /// <summary>
    /// Repository for TV show episodes metadata based on XBMC .nfo files.
    /// </summary>
    public interface IEpisodeMetadataRepository
    {
        /// <summary>
        /// Gets the path to the .nfo file.
        /// </summary>
        /// <param name="path">The episode file path.</param>
        /// <returns></returns>
        Task<EpisodeMetadata> Get(string path);

        /// <summary>
        /// Gets the metadata associated with the episode located at the specified path.
        /// </summary>
        /// <param name="path">The episode file path.</param>
        /// <param name="metadata">The metadata.</param>
        Task Save(string path, EpisodeMetadata metadata);

        /// <summary>
        /// Deletes the metadata associated with the episode located at the specified path.
        /// </summary>
        /// <param name="path">The episode file path.</param>
        void Delete(string path);
    }
}
