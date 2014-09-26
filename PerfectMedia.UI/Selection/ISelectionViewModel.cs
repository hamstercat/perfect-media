using System.ComponentModel;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Selection
{
    public interface ISelectionViewModel<T> : ISelectionViewModel
    {
        T SelectedItem { get; set; }
    }

    public interface ISelectionViewModel : INotifyPropertyChanged
    {
        bool IsClosed { get; set; }
        object OriginalContent { get; set; }
        Task SaveSelectedItem();
    }
}