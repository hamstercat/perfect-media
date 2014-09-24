using System.Collections.Generic;
using System.Threading.Tasks;
using PerfectMedia.Music.Albums;
using PerfectMedia.Music.Artists;

namespace PerfectMedia.Music
{
    public interface IMusicMetadataUpdater
    {
        Task<IEnumerable<ArtistSummary>> FindArtists(string name);
        Task<ArtistSummary> GetArtistMetadata(string artistId);
        Task<IEnumerable<AlbumSummary>> FindAlbums(string artistId);
        Task<AlbumSummary> GetAlbum(string albumId);
    }
}
