using PerfectMedia.UI.Progress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.TvShows.Episodes
{
    public interface IEpisodeViewModel
    {
        IEnumerable<ProgressItem> Update();
    }
}
