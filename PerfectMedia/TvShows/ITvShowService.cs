using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows
{
    public interface ITvShowService
    {
        IEnumerable<Season> GetSeasons(string tvShowPath);
    }
}
