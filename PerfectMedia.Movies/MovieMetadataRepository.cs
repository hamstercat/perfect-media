using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    /// <summary>
    /// Repository for movie metadata based on XBMC .nfo files.
    /// </summary>
    public class MovieMetadataRepository : NfoRepository<MovieMetadata>, IMovieMetadataRepository
    {
        private readonly IFileSystemService _fileSystemService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieMetadataRepository"/> class.
        /// </summary>
        /// <param name="fileSystemService">The file system service.</param>
        public MovieMetadataRepository(IFileSystemService fileSystemService)
            : base(fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        /// <summary>
        /// Gets the metadata associated with the movie located at the specified path.
        /// </summary>
        /// <param name="path">The movie file path.</param>
        /// <param name="metadata">The metadata.</param>
        public override async Task Save(string path, MovieMetadata metadata)
        {
            await base.Save(path, metadata);
            await SaveActorsThumbnails(path, metadata.Actors);
        }

        protected override string GetNfoFile(string path)
        {
            return Path.ChangeExtension(path, ".nfo");
        }

        private async Task SaveActorsThumbnails(string path, IEnumerable<ActorMetadata> actors)
        {
            string movieFolder = _fileSystemService.GetParentFolder(path, 1);
            string actorFolder = ActorMetadata.GetActorsFolder(movieFolder);
            await _fileSystemService.CreateFolder(actorFolder);

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
