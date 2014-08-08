using System.Collections.Generic;
using PerfectMedia.UI.Progress;

namespace PerfectMedia.UI.TvShows.Seasons
{
    public interface ISeasonViewModel
    {
        IEnumerable<ProgressItem> FindNewEpisodes();
    }
}
