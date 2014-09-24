using System.IO;
using PerfectMedia.Serialization;

namespace PerfectMedia.Music.Albums
{
    public class ArtistMetadataRepository : NfoRepository<AlbumMetadata>, IAlbumMetadataRepository
    {
        private const string NfoFile = "album.nfo";

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
