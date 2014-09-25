using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectMedia.Music
{
    public interface IMusicImageService
    {
        Task UpdateArtist(string path, string imageUrl);
        Task DeleteArtist(string path);
        Task UpdateAlbum(string path, string imageUrl);
        Task DeleteAlbum(string path);
    }
}
