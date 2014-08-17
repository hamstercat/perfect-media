using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectMedia.Sources
{
    /// <summary>
    /// Repository that allows the persistance of sources.
    /// </summary>
    public interface ISourceRepository
    {
        /// <summary>
        /// Gets all the sources.
        /// </summary>
        /// <param name="sourceType">Type of the source.</param>
        /// <returns></returns>
        Task<IEnumerable<Source>> GetSources(SourceType sourceType);

        /// <summary>
        /// Saves the specified sources.
        /// </summary>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="sources">The sources.</param>
        /// <returns></returns>
        void Save(SourceType sourceType, IEnumerable<Source> sources);
    }
}
