using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    public interface ITvShowMetadataUpdater
    {
        Task<IEnumerable<Series>> FindSeries(string name);
        Task<FullSerie> GetTvShowMetadata(string serieId);
        Task<AvailableTvShowImages> FindImages(string serieId);
        Task<IEnumerable<Actor>> FindActors(string serieId);
        Task<EpisodeMetadata> GetEpisodeMetadata(string serieId, int seasonNumber, int episodeNumber);
    }
}
