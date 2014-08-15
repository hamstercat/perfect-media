using System.ComponentModel;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Images.Selection
{
    public interface IImageSelectionViewModel : INotifyPropertyChanged
    {
        IChooseImageFileViewModel Download { get; }
        bool IsClosed { get; set; }
        object OriginalContent { get; set; }
        Task LoadAvailableImages();
    }
}
