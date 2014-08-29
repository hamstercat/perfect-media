using System.Threading.Tasks;

namespace PerfectMedia.Music.Artists
{
    public interface IArtistMetadataRepository
    {
        Task<ArtistMetadata> Get(string path);
        Task Save(string path, ArtistMetadata metadata);
        Task Delete(string path);
    }
}
