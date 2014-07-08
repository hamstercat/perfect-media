using PerfectMedia.TvShows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.Images
{
    public interface IImageViewModel : INotifyPropertyChanged
    {
        string Path { get; set; }
        Image SelectedImage { get; }
        object OriginalContent { get; set; }
        bool IsClosed { get; set; }
        ChooseImageFileViewModel Download { get; }
        void LoadAvailableImages();
        void SaveSelectedImage();
    }
}
