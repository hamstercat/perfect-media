using System.Collections.Generic;
using System.Linq;

namespace PerfectMedia.UI.Images.Selection
{
    public class NoImageStrategy : IImageStrategy
    {
        public IEnumerable<Image> FindImages()
        {
            return Enumerable.Empty<Image>();
        }
    }
}
