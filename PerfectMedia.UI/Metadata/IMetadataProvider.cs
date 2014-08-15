using System.Collections.Generic;
using System.Threading.Tasks;
using PerfectMedia.UI.Progress;

namespace PerfectMedia.UI.Metadata
{
    public interface IMetadataProvider
    {
        Task Refresh();
        Task<IEnumerable<ProgressItem>> Update();
        Task Save();
    }
}
