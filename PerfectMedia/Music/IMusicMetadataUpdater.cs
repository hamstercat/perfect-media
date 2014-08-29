using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectMedia.Music.Artists;

namespace PerfectMedia.Music
{
    public interface IMusicMetadataUpdater
    {
        Task<IEnumerable<ArtistSummary>> FindArtists(string name);
        Task<Artist> GetArtistMetadata(string artistId);
    }
}
