using PerfectMedia.UI.Selection;

namespace PerfectMedia.UI.Images.Selection
{
    public interface IImageSelectionViewModel : ISelectionViewModel<Image>
    {
        IChooseImageFileViewModel Download { get; }
    }
}
