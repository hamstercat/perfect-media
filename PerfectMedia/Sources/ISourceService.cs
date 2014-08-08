using System.Collections.Generic;

namespace PerfectMedia.Sources
{
    public interface ISourceService
    {
        IEnumerable<Source> GetSources(SourceType sourceType);
        void Save(Source source);
        void Delete(Source source);
    }
}
