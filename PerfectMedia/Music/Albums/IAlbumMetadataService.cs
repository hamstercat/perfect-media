using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectMedia.Music.Albums
{
    public interface IAlbumMetadataService
    {
        Task<AlbumMetadata> Get(string path);
        Task Save(string path, AlbumMetadata metadata);
        Task Update(string path, string artistId);
        Task Delete(string path);
        Task<IEnumerable<ReleaseGroup>> FindAlbums(string artistId, int page, int pageNumber);
    }
}
