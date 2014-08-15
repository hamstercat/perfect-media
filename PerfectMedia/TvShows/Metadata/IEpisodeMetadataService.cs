
using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    public interface IEpisodeMetadataService
    {
        Task<EpisodeMetadata> Get(string episodeFile);
        void Save(string episodeFile, EpisodeMetadata metadata);
        void Update(string episodeFile, string serieId);
        void Delete(string episodeFile);
    }
}
