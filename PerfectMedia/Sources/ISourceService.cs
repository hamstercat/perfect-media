using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Sources
{
    public interface ISourceService
    {
        IEnumerable<Source> GetSources(SourceType sourceType);
        void Save(Source source);
        void Delete(Source source);
    }
}
