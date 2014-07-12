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
        string SearchTitle { get; set; }
        bool IsClosed { get; set; }
        object OriginalContent { get; set; }
        Series SelectedSerie { get; }
        SmartObservableCollection<Series> Series { get; }
    }
}
