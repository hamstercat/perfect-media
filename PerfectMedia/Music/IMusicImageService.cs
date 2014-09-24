using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectMedia.Music
{
    public interface IMusicImageService
    {
        Task UpdateArtist(string path, Image image);
        Task DeleteArtist(string path);
        Task UpdateAlbum(string path, Image image);
        Task DeleteAlbum(string path);
    }
}
