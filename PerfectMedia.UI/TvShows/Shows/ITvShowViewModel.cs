using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.ShowSelection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.TvShows.Shows
{
    public interface ITvShowViewModel
    {
        string Path { get; }
        ITvShowSelectionViewModel Selection { get; }
        IEnumerable<ProgressItem> Update();
        IEnumerable<ProgressItem> FindNewEpisodes();
    }
}
