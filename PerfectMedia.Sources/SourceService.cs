using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<Source>> GetSources(SourceType sourceType)
        {
            return await _sourceRepository.GetSources(sourceType);
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
        public async Task Delete(Source source)
        {
            await _sourceRepository.Delete(source);
        }
    }
}
