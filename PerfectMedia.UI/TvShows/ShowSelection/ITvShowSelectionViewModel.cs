using PerfectMedia.TvShows.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.TvShows.ShowSelection
{
    public interface ITvShowSelectionViewModel : INotifyPropertyChanged
    {
        string Title { get; set; }
        bool IsClosed { get; set; }
        object OriginalContent { get; set; }
        SmartObservableCollection<Series> Series { get; }
    }
}
