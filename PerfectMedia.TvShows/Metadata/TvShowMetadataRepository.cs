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
    public class TvShowMetadataRepository : ITvShowMetadataRepository
    {
        private const string NfoFile = "tvshow.nfo";
        private readonly IFileSystemService _fileSystemService;

        public TvShowMetadataRepository(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        public TvShowMetadata Get(string path)
        {
            string nfoFileFullPath = Path.Combine(path, NfoFile);
            if (!_fileSystemService.FileExists(nfoFileFullPath))
            {
                return new TvShowMetadata();
            }
            return Deserialize(nfoFileFullPath);
        }

        public void Save(string path, TvShowMetadata metadata)
        {
            string nfoFileFullPath = Path.Combine(path, NfoFile);
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };
            using (XmlWriter writer = XmlWriter.Create(nfoFileFullPath, xmlWriterSettings))
            {
                writer.WriteRaw("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>\r\n");

                XmlSerializer serializer = new XmlSerializer(typeof(TvShowMetadata));
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                serializer.Serialize(writer, metadata, namespaces);
            }
            SaveActorsThumbnails(path, metadata.Actors);
        }

        public void Delete(string path)
        {
            string nfoFileFullPath = Path.Combine(path, NfoFile);
            _fileSystemService.DeleteFile(nfoFileFullPath);
        }

        private static TvShowMetadata Deserialize(string nfoFileFullPath)
        {
            using (XmlReader reader = XmlReader.Create(nfoFileFullPath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TvShowMetadata));
                return (TvShowMetadata)serializer.Deserialize(reader);
            }
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
