using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Sources
{
    public class SourceService : ISourceService
    {
        private readonly ISourceRepository _sourceRepository;

        public SourceService(ISourceRepository sourceRepository)
        {
            // TODO: determine what should be in the service and what should be in the repository
            _sourceRepository = sourceRepository;
        }

        public IEnumerable<Source> GetSources(SourceType sourceType)
        {
            return _sourceRepository.GetSources(sourceType);
        }

        public void Save(Source source)
        {
            _sourceRepository.Save(source);
        }

        public void Delete(Source source)
        {
            _sourceRepository.Delete(source);
        }
    }
}
