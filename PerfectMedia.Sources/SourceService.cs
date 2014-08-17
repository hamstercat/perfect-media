using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectMedia.Sources
{
    /// <summary>
    /// Retrieves sources using SourceRepository.
    /// </summary>
    public class SourceService : ISourceService, ILifecycleService
    {
        private readonly ISourceRepository _sourceRepository;
        private readonly IDictionary<SourceType, List<Source>> _sourcesByType;

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceService"/> class.
        /// </summary>
        /// <param name="sourceRepository">The source repository.</param>
        public SourceService(ISourceRepository sourceRepository)
        {
            _sourceRepository = sourceRepository;
            _sourcesByType = new Dictionary<SourceType, List<Source>>();
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
        /// Adds the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        public void Add(Source source)
        {
            List<Source> sourcesList = GetSourceListForSourceType(source.SourceType);
            sourcesList.Add(source);
        }

        /// <summary>
        /// Removes the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        public void Remove(Source source)
        {
            List<Source> sourcesList = GetSourceListForSourceType(source.SourceType);
            sourcesList.Remove(source);
        }

        async Task ILifecycleService.Initialize()
        {
            IEnumerable<SourceType> allSourceTypes = Enum.GetValues(typeof(SourceType)).Cast<SourceType>();
            foreach (SourceType sourceType in allSourceTypes)
            {
                List<Source> sourcesList = GetSourceListForSourceType(sourceType);
                sourcesList.AddRange(await _sourceRepository.GetSources(sourceType));
            }
        }

        void ILifecycleService.Uninitialize()
        {
            foreach (var sourcesList in _sourcesByType)
            {
                _sourceRepository.Save(sourcesList.Key, sourcesList.Value);
            }
        }

        private List<Source> GetSourceListForSourceType(SourceType sourceType)
        {
            if (!_sourcesByType.ContainsKey(sourceType))
            {
                _sourcesByType[sourceType] = new List<Source>();
            }
            return _sourcesByType[sourceType];
        }
    }
}
