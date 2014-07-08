using PerfectMedia.TvShows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
