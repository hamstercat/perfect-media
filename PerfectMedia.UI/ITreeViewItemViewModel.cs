
using System.Threading.Tasks;

namespace PerfectMedia.UI
{
    public interface ITreeViewItemViewModel
    {
        string DisplayName { get; }
        Task Load();
        Task LoadChildren();
    }
}
