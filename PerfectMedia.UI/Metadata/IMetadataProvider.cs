using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using PerfectMedia.UI.Progress;

namespace PerfectMedia.UI.Metadata
{
    public interface IMetadataProvider : INotifyPropertyChanged
    {
        bool IsValid { get; }
        Task Refresh();
        Task<IEnumerable<ProgressItem>> Update();
        Task Save();
        Task Delete();
    }
}
