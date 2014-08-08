
namespace PerfectMedia.UI.Images
{
    public interface IImageViewModel
    {
        string Path { get; set; }
        object OriginalContent { get; set; }
        void LoadAvailableImages();
        void RefreshImage();
    }
}
