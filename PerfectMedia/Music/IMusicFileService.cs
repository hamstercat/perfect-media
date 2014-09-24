using System.Collections.Generic;
using System.Threading.Tasks;
using PerfectMedia.Music.Albums;

namespace PerfectMedia.Music
{
    public interface IMusicFileService
    {
        Task<IEnumerable<AlbumFile>> GetAlbums(string artistFolder);
        Task<IEnumerable<TrackFile>> GetTracks(string albumFolder);
    }
}
