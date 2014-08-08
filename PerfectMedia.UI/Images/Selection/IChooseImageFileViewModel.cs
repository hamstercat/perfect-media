using System.ComponentModel;

namespace PerfectMedia.UI.Images.Selection
{
    public interface IChooseImageFileViewModel : INotifyPropertyChanged
    {
        string Url { get; }
        bool IsClosed { get; set; }
        void SaveLocalFile();
        void DownloadFile();
    }
}
