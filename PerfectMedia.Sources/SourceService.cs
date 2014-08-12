using System.Collections.Generic;

namespace PerfectMedia.Sources
{
    /// <summary>
    /// Retrieves sources using SourceRepository.
    /// </summary>
    public class SourceService : ISourceService
    {
        private readonly ISourceRepository _sourceRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceService"/> class.
        /// </summary>
        /// <param name="sourceRepository">The source repository.</param>
        public SourceService(ISourceRepository sourceRepository)
        {
            // TODO: determine what should be in the service and what should be in the repository
            _sourceRepository = sourceRepository;
        }

        /// <summary>
        /// Gets all the sources.
        /// </summary>
        /// <param name="sourceType">Type of the source.</param>
        /// <returns></returns>
        public IEnumerable<Source> GetSources(SourceType sourceType)
        {
            return _sourceRepository.GetSources(sourceType);
        }

        /// <summary>
        /// Saves the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        public void Save(Source source)
        {
            _sourceRepository.Save(source);
        }

        /// <summary>
        /// Deletes the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        public void Delete(Source source)
        {
            _sourceRepository.Delete(source);
        }
    }
}
