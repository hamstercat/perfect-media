using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using PerfectMedia.UI.Progress;

namespace PerfectMedia.UI.Metadata
{
    public interface IMetadataProvider : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        Task Refresh();
        Task<IEnumerable<ProgressItem>> Update();
        Task Save();
        Task Delete();
    }
}
