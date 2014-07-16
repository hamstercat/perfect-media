using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    public class MovieMetadataRepository : NfoRepository<MovieMetadata>, IMovieMetadataRepository
    {
        private readonly IFileSystemService _fileSystemService;

        public MovieMetadataRepository(IFileSystemService fileSystemService)
            : base(fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

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
                _fileSystemService.DownloadFile(actor.ThumbPath, actor.Thumb);
            }
        }
    }
}
