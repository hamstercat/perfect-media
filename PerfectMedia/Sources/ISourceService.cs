using System.Collections.Generic;

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
        IEnumerable<Source> GetSources(SourceType sourceType);

        /// <summary>
        /// Saves the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        void Save(Source source);

        /// <summary>
        /// Deletes the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        void Delete(Source source);
    }
}
