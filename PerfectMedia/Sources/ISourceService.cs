using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectMedia.Sources
{
    /// <summary>
    /// Retrieves sources.
    /// </summary>
    public interface ISourceService
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
        Task Save(Source source);

        /// <summary>
        /// Deletes the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        Task Delete(Source source);
    }
}
