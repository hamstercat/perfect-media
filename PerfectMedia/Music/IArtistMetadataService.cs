using System.Threading.Tasks;

namespace PerfectMedia.Music
{
    public interface IArtistMetadataService
    {
        Task<ArtistMetadata> Get(string path);
        Task Save(string path, ArtistMetadata metadata);
        Task Update(string path);
        Task Delete(string path);
    }
}