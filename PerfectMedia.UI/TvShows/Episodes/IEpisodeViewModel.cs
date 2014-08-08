using System.Collections.Generic;
using PerfectMedia.UI.Progress;

namespace PerfectMedia.UI.TvShows.Episodes
{
    public interface IEpisodeViewModel
    {
        IEnumerable<ProgressItem> Update();
    }
}
