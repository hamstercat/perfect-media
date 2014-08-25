using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Music
{
    public interface IArtistMetadataRepository
    {
        Task<ArtistMetadata> Get(string path);
        Task Save(string path, ArtistMetadata metadata);
        Task Delete(string path);
    }
}
