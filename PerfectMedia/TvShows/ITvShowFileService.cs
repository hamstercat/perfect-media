using PerfectMedia.TvShows.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows
{
    public interface ITvShowFileService
    {
        TvShowImages GetShowImages(string tvShowPath);
        IEnumerable<Season> GetSeasons(string tvShowPath);
        IEnumerable<Episode> GetEpisodes(string seasonPath);
    }
}
