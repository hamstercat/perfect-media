using System.IO;
using PerfectMedia.Serialization;

namespace PerfectMedia.Music.Artists
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
