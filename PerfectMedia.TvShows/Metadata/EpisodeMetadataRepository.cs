﻿using System.IO;
using System.Threading.Tasks;
using PerfectMedia.Serialization;

namespace PerfectMedia.TvShows.Metadata
{
    /// <summary>
    /// Repository for TV show episodes metadata based on XBMC .nfo files.
    /// </summary>
    public class EpisodeMetadataRepository : NfoRepository<EpisodeMetadata>, IEpisodeMetadataRepository
    {
        private readonly IFileSystemService _fileSystemService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EpisodeMetadataRepository" /> class.
        /// </summary>
        /// <param name="fileSystemService">The file system service.</param>
        /// <param name="xmlSerializerFactory">The XML serializer factory.</param>
        public EpisodeMetadataRepository(IFileSystemService fileSystemService, IXmlSerializerFactory xmlSerializerFactory)
            : base(fileSystemService, xmlSerializerFactory)
        {
            _fileSystemService = fileSystemService;
        }

        /// <summary>
        /// Gets the path to the .nfo file.
        /// </summary>
        /// <param name="path">The episode file path.</param>
        /// <returns></returns>
        public override async Task<EpisodeMetadata> Get(string path)
        {
            EpisodeMetadata metadata = await base.Get(path);
            metadata.ImagePath = GetImageFile(path);
            return metadata;
        }

        /// <summary>
        /// Gets the metadata associated with the episode located at the specified path.
        /// </summary>
        /// <param name="path">The episode file path.</param>
        /// <param name="metadata">The metadata.</param>
        public override async Task Save(string path, EpisodeMetadata metadata)
        {
            await base.Save(path, metadata);

            if (!string.IsNullOrEmpty(metadata.ImageUrl))
            {
                string imageFile = GetImageFile(path);
                await _fileSystemService.DownloadImage(imageFile, metadata.ImageUrl);
            }
        }

        /// <summary>
        /// Deletes the metadata associated with the episode located at the specified path.
        /// </summary>
        /// <param name="path">The episode file path.</param>
        public override async Task Delete(string path)
        {
            await base.Delete(path);
            string imageFile = GetImageFile(path);
            await _fileSystemService.DeleteFile(imageFile);
        }

        protected override string GetNfoFile(string path)
        {
            return Path.ChangeExtension(path, ".nfo");
        }

        private string GetImageFile(string path)
        {
            string folder = Path.GetDirectoryName(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            return Path.Combine(folder, fileName + "-thumb.jpg");
        }
    }
}
