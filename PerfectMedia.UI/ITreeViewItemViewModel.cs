
namespace PerfectMedia.UI
{
    public interface ITreeViewItemViewModel
    {
        string DisplayName { get; }
        bool IsExpanded { get; set; }
    }
}
