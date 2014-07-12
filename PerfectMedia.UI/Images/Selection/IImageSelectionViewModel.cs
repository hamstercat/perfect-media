using PerfectMedia.TvShows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.Images.Selection
{
    public interface IImageSelectionViewModel : INotifyPropertyChanged
    {
        IChooseImageFileViewModel Download { get; }
        bool IsClosed { get; set; }
        object OriginalContent { get; set; }
    }
}
