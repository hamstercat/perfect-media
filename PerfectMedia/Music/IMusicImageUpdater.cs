using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectMedia.Music
{
    public interface IMusicImageUpdater
    {
        Task<IEnumerable<string>> FindArtistImages(string id);
        Task<IEnumerable<string>> FindAlbumImages(string id);
    }
}
