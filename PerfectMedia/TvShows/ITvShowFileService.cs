using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows
{
    public interface ITvShowFileService
    {
        Task<TvShowImages> GetShowImages(string tvShowPath);
        Season GetSeason(string tvShowPath, string seasonFolder);
        Task<IEnumerable<Season>> GetSeasons(string tvShowPath);
        Task<IEnumerable<Episode>> GetEpisodes(string seasonPath);
    }
}
