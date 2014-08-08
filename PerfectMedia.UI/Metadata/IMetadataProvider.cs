using System.Collections.Generic;
using PerfectMedia.UI.Progress;

namespace PerfectMedia.UI.Metadata
{
    public interface IMetadataProvider
    {
        void Refresh();
        IEnumerable<ProgressItem> Update();
        void Save();
    }
}
