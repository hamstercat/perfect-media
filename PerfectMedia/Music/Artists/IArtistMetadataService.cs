using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectMedia.Music.Artists
{
    public interface IArtistMetadataService
    {
        Task<ArtistMetadata> Get(string path);
        Task Save(string path, ArtistMetadata metadata);
        Task Update(string path);
        Task Delete(string path);
        Task<IEnumerable<ArtistSummary>> FindArtists(string name, int page, int pageNumber);
    }
}