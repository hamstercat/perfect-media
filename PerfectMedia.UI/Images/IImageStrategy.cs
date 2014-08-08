using System.Collections.Generic;

namespace PerfectMedia.UI.Images
{
    public interface IImageStrategy
    {
        IEnumerable<Image> FindImages();
    }
}
