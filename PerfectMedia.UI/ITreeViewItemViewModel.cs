
using System.Threading.Tasks;

namespace PerfectMedia.UI
{
    public interface ITreeViewItemViewModel
    {
        string DisplayName { get; }
        bool IsExpanded { get; set; }
        Task Load();
    }
}
