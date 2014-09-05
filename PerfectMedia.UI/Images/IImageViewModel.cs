
using System.Threading.Tasks;

namespace PerfectMedia.UI.Images
{
    public interface IImageViewModel
    {
        string Path { get; set; }
        object OriginalContent { get; set; }
        Task LoadAvailableImages();
        void RefreshImage();
        void RefreshImage(string newPath);
    }
}
