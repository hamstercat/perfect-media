using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Images
{
    public interface IImageStrategy
    {
        Task<IEnumerable<Image>> FindImages();
    }
}
