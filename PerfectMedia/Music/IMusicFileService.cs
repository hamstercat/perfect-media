using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Music
{
    public interface IMusicFileService
    {
        Task<IEnumerable<AlbumFile>> GetAlbums(string artistFolder);
        Task<IEnumerable<TrackFile>> GetTracks(string albumFolder);
    }
}
