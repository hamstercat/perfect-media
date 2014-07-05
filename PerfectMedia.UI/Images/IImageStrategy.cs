using PerfectMedia.TvShows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.Images
{
    public interface IImageStrategy
    {
        IEnumerable<Image> FindImages();
    }
}
