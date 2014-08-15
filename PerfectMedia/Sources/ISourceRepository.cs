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
        /// Saves the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        void Save(Source source);

        /// <summary>
        /// Deletes the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        Task Delete(Source source);
    }
}
