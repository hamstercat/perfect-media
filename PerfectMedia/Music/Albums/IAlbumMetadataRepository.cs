using System.Threading.Tasks;

namespace PerfectMedia.Music.Albums
{
    public interface IAlbumMetadataRepository
    {
        Task<AlbumMetadata> Get(string path);
        Task Save(string path, AlbumMetadata metadata);
        Task Delete(string path);
    }
}
