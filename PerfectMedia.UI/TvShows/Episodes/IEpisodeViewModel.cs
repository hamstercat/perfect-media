using System.Collections.Generic;
using System.Threading.Tasks;
using PerfectMedia.UI.Progress;

namespace PerfectMedia.UI.TvShows.Episodes
{
    public interface IEpisodeViewModel
    {
        Task<IEnumerable<ProgressItem>> Update();
    }
}
