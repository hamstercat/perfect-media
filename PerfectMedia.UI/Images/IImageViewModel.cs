using PerfectMedia.TvShows;
using PerfectMedia.UI.Images.Selection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.Images
{
    public interface IImageViewModel
    {
        string Path { get; set; }
        object OriginalContent { get; set; }
        void LoadAvailableImages();
    }
}
