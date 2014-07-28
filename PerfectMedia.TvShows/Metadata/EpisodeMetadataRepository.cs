using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PerfectMedia.TvShows.Metadata
{
    public class EpisodeMetadataRepository : NfoRepository<EpisodeMetadata>, IEpisodeMetadataRepository
    {
        private readonly IFileSystemService _fileSystemService;

        public EpisodeMetadataRepository(IFileSystemService fileSystemService)
            : base(fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        public override EpisodeMetadata Get(string path)
        {
            EpisodeMetadata metadata = base.Get(path);
            metadata.ImagePath = GetImageFile(path);
            return metadata;
        }

        public override void Save(string path, EpisodeMetadata metadata)
        {
            base.Save(path, metadata);

            if (!string.IsNullOrEmpty(metadata.ImageUrl))
            {
                string imageFile = GetImageFile(path);
                _fileSystemService.DownloadImage(imageFile, metadata.ImageUrl);
            }
        }

        public override void Delete(string path)
        {
            base.Delete(path);
            string imageFile = GetImageFile(path);
            _fileSystemService.DeleteFile(imageFile);
        }

        protected override string GetNfoFile(string path)
        {
            return Path.ChangeExtension(path, ".nfo");
        }

        private string GetImageFile(string path)
        {
            string folder = Path.GetDirectoryName(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            return Path.Combine(folder, fileName + "-thumb.png");
        }
    }
}
