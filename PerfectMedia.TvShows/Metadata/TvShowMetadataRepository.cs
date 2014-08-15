using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    /// <summary>
    /// Repository for TV shows metadata based on XBMC .nfo files.
    /// </summary>
    public class TvShowMetadataRepository : NfoRepository<TvShowMetadata>, ITvShowMetadataRepository
    {
        private const string NfoFile = "tvshow.nfo";
        private readonly IFileSystemService _fileSystemService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TvShowMetadataRepository"/> class.
        /// </summary>
        /// <param name="fileSystemService">The file system service.</param>
        public TvShowMetadataRepository(IFileSystemService fileSystemService)
            : base(fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        /// <summary>
        /// Gets the metadata associated with the TV show located at the specified path.
        /// </summary>
        /// <param name="path">The TV show folder path.</param>
        /// <param name="metadata">The metadata.</param>
        public override async Task Save(string path, TvShowMetadata metadata)
        {
            await base.Save(path, metadata);
            await SaveActorsThumbnails(path, metadata.Actors);
        }

        protected override string GetNfoFile(string path)
        {
            return Path.Combine(path, NfoFile);
        }

        private async Task SaveActorsThumbnails(string path, IEnumerable<ActorMetadata> actors)
        {
            string actorFolder = ActorMetadata.GetActorsFolder(path);
            if (!_fileSystemService.FolderExists(actorFolder))
            {
                _fileSystemService.CreateFolder(actorFolder);
            }

            foreach (ActorMetadata actor in actors)
            {
                await SaveActorMetadata(actor);
            }
        }

        private async Task SaveActorMetadata(ActorMetadata actor)
        {
            if (!await _fileSystemService.FileExists(actor.ThumbPath) && !string.IsNullOrEmpty(actor.Thumb))
            {
                await _fileSystemService.DownloadImage(actor.ThumbPath, actor.Thumb);
            }
        }
    }
}
