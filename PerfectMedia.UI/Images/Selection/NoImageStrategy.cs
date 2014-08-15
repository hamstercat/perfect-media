using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Images.Selection
{
    public class NoImageStrategy : IImageStrategy
    {
        public Task<IEnumerable<Image>> FindImages()
        {
            IEnumerable<Image> images = Enumerable.Empty<Image>();
            return Task.FromResult(images);
        }
    }
}
