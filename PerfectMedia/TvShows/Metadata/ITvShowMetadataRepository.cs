
namespace PerfectMedia.TvShows.Metadata
{
    public interface ITvShowMetadataRepository
    {
        TvShowMetadata Get(string path);
        void Save(string path, TvShowMetadata metadata);
        void Delete(string path);
    }
}
