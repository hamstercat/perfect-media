
namespace PerfectMedia.Movies
{
    public interface IMovieMetadataRepository
    {
        MovieMetadata Get(string path);
        void Save(string path, MovieMetadata metadata);
        void Delete(string path);
    }
}
