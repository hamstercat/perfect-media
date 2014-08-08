using System.Collections.Generic;
using System.ComponentModel;
using PerfectMedia.TvShows.Metadata;

namespace PerfectMedia.UI.TvShows.ShowSelection
{
    public interface ITvShowSelectionViewModel : INotifyPropertyChanged
    {
        string SearchTitle { get; set; }
        bool IsClosed { get; set; }
        object OriginalContent { get; set; }
        void ReplaceSeries(IEnumerable<Series> series);
    }
}
