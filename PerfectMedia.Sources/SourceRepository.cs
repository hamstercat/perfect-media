using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace PerfectMedia.Sources
{
    public class SourceRepository : ISourceRepository
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly string _basePath;

        public SourceRepository(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
            // Save the file in an XML located in the same folder as the executable
            string assemblyFolder = Assembly.GetExecutingAssembly().Location;
            _basePath = Path.GetDirectoryName(assemblyFolder);
        }

        public IEnumerable<Source> GetSources(SourceType sourceType)
        {
            string file = GetSourceTypeFile(sourceType);
            if (_fileSystemService.FileExists(file))
            {
                return Deserialize(file);
            }
            return Enumerable.Empty<Source>();
        }

        public void Save(Source source)
        {
            string file = GetSourceTypeFile(source.SourceType);
            string serializedSource = GetSerializedSource(source);
            File.AppendAllLines(file, new List<string> { serializedSource });
        }

        public void Delete(Source source)
        {
            IEnumerable<Source> sources = GetSources(source.SourceType);
            IEnumerable<Source> newSources = sources.Where(src => src.Folder != source.Folder);
            ReplaceSources(newSources, source.SourceType);
        }

        private string GetSourceTypeFile(SourceType sourceType)
        {
            string fileName = sourceType.ToString() + ".xml";
            string folder = GetFolder();
            return Path.Combine(folder, fileName);
        }

        private string GetFolder()
        {
            string folder = Path.Combine(_basePath, "Sources");
            if (!_fileSystemService.FolderExists(folder))
            {
                _fileSystemService.CreateFolder(folder);
            }
            return folder;
        }

        private IEnumerable<Source> Deserialize(string path)
        {
            // For simplicity sake each sources are appended at the end of the file, so there are multiple root elements in the "XML document"
            // This isn't supported in the XML specification, but XmlReader allows it
            XmlReaderSettings readerSettings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
            using (XmlReader reader = XmlReader.Create(path, readerSettings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element) {
                        using (XmlReader fragmentReader = reader.ReadSubtree())
                        {
                            if (fragmentReader.Read())
                            {
                                XmlSerializer serializer = new XmlSerializer(typeof(Source));
                                yield return (Source)serializer.Deserialize(fragmentReader);
                            }
                        }
                    }
                }
            }
        }

        private static string GetSerializedSource(Source source)
        {
            StringBuilder str = new StringBuilder();
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };
            using (XmlWriter writer = XmlWriter.Create(str, xmlWriterSettings))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Source));
                serializer.Serialize(writer, source);
            }
            return str.ToString();
        }

        private void ReplaceSources(IEnumerable<Source> newSources, SourceType sourceType)
        {
            string file = GetSourceTypeFile(sourceType);
            IEnumerable<string> serializedSources = newSources.Select(GetSerializedSource);
            _fileSystemService.DeleteFile(file);
            _fileSystemService.CreateFile(file, serializedSources);
        }
    }
}
