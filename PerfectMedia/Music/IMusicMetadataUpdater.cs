using System.Collections.Generic;
using System.Threading.Tasks;
using PerfectMedia.Music.Albums;
using PerfectMedia.Music.Artists;

namespace PerfectMedia.Music
{
    public interface IMusicMetadataUpdater
    {
        Task<PagedList<ArtistSummary>> FindArtists(string name, int page, int pageSize);
        Task<ArtistSummary> GetArtistMetadata(string artistId);
        Task<PagedList<ReleaseGroup>> FindAlbums(string artistId, int page, int pageSize);
        Task<ReleaseGroup> GetAlbum(string albumId);
    }
}
