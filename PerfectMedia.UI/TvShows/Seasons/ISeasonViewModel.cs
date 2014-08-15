using System.Collections.Generic;
using System.Threading.Tasks;
using PerfectMedia.UI.Progress;

namespace PerfectMedia.UI.TvShows.Seasons
{
    public interface ISeasonViewModel
    {
        Task<IEnumerable<ProgressItem>> FindNewEpisodes();
    }
}
