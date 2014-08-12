using System.Collections.Generic;
using System.IO;

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
        public override void Save(string path, MovieMetadata metadata)
        {
            base.Save(path, metadata);
            SaveActorsThumbnails(path, metadata.Actors);
        }

        protected override string GetNfoFile(string path)
        {
            return Path.ChangeExtension(path, ".nfo");
        }

        private void SaveActorsThumbnails(string path, IEnumerable<ActorMetadata> actors)
        {
            string movieFolder = _fileSystemService.GetParentFolder(path, 1);
            string actorFolder = ActorMetadata.GetActorsFolder(movieFolder);
            if (!_fileSystemService.FolderExists(actorFolder))
            {
                _fileSystemService.CreateFolder(actorFolder);
            }

            foreach (ActorMetadata actor in actors)
            {
                SaveActorMetadata(actor);
            }
        }

        private void SaveActorMetadata(ActorMetadata actor)
        {
            if (!_fileSystemService.FileExists(actor.ThumbPath) && !string.IsNullOrEmpty(actor.Thumb))
            {
                _fileSystemService.DownloadImage(actor.ThumbPath, actor.Thumb);
            }
        }
    }
}
