using System.Collections.Generic;
using System.IO;

namespace PerfectMedia.TvShows.Metadata
{
    public class TvShowMetadataRepository : NfoRepository<TvShowMetadata>, ITvShowMetadataRepository
    {
        private const string NfoFile = "tvshow.nfo";
        private readonly IFileSystemService _fileSystemService;

        public TvShowMetadataRepository(IFileSystemService fileSystemService)
            : base(fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        public override void Save(string path, TvShowMetadata metadata)
        {
            base.Save(path, metadata);
            SaveActorsThumbnails(path, metadata.Actors);
        }

        protected override string GetNfoFile(string path)
        {
            return Path.Combine(path, NfoFile);
        }

        private void SaveActorsThumbnails(string path, IEnumerable<ActorMetadata> actors)
        {
            string actorFolder = ActorMetadata.GetActorsFolder(path);
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
