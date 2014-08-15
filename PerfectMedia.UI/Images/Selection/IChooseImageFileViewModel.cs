using System.ComponentModel;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Images.Selection
{
    public interface IChooseImageFileViewModel : INotifyPropertyChanged
    {
        string Url { get; }
        bool IsClosed { get; set; }
        Task SaveLocalFile();
        Task DownloadFile();
    }
}
