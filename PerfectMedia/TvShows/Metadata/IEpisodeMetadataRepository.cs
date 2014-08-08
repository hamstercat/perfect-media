
namespace PerfectMedia.TvShows.Metadata
{
    public interface IEpisodeMetadataRepository
    {
        EpisodeMetadata Get(string episodeFile);
        void Save(string episodeFile, EpisodeMetadata metadata);
        void Delete(string episodeFile);
    }
}
