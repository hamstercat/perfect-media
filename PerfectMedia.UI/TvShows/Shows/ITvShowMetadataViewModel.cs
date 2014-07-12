using PerfectMedia.UI.Progress;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.TvShows.Shows
{
    public interface ITvShowMetadataViewModel : INotifyPropertyChanged
    {
        string Id { get; }
        string Path { get; }
        string DisplayName { get; }
        IEnumerable<ProgressItem> Update();
        void Refresh();
    }
}
