using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectMedia.Serialization;

namespace PerfectMedia.Music
{
    public class ArtistMetadataRepository : NfoRepository<ArtistMetadata>, IArtistMetadataRepository
    {
        private const string NfoFile = "artist.nfo";

        public ArtistMetadataRepository(IFileSystemService fileSystemService, IXmlSerializerFactory xmlSerializerFactory)
            : base(fileSystemService, xmlSerializerFactory)
        {
        }

        protected override string GetNfoFile(string path)
        {
            return Path.Combine(path, NfoFile);
        }
    }
}
