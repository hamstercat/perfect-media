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
            string actorsFolder = GetActorsFolder(path);
            foreach (ActorMetadata actor in actors)
            {
                SaveActorMetadata(actorsFolder, actor);
            }
        }

        private string GetActorsFolder(string path)
        {
            string folderName = Path.Combine(path, ".actors");
            if (!_fileSystemService.FolderExists(folderName))
            {
                _fileSystemService.CreateFolder(folderName);
            }
            return folderName;
        }

        private void SaveActorMetadata(string actorsFolder, ActorMetadata actor)
        {
            string fileName = actor.Name.Replace(" ", "_") + ".jpg";
            string fullFileName = Path.Combine(actorsFolder, fileName);
            if (!_fileSystemService.FileExists(fullFileName))
            {
                _fileSystemService.DownloadFile(fullFileName, actor.Thumb);
            }
        }
    }
}
