using System.Collections.Generic;

namespace PerfectMedia.TvShows
{
    public interface ITvShowFileService
    {
        TvShowImages GetShowImages(string tvShowPath);
        Season GetSeason(string tvShowPath, string seasonFolder);
        IEnumerable<Season> GetSeasons(string tvShowPath);
        IEnumerable<Episode> GetEpisodes(string seasonPath);
    }
}
