using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.Images.Selection
{
    public interface IChooseImageFileViewModel : INotifyPropertyChanged
    {
        string Url { get; }
        bool IsClosed { get; set; }
        void SaveLocalFile();
        void DownloadFile();
    }
}
