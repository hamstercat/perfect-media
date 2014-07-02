using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PerfectMedia.Sources
{
    public class SourceRepository : ISourceRepository
    {
        private readonly string _basePath;

        public SourceRepository()
        {
            // Save the file in an XML located in the same folder as the executable
            string assemblyFolder = Assembly.GetExecutingAssembly().Location;
            _basePath = Path.GetDirectoryName(assemblyFolder);
        }

        public IEnumerable<Source> GetSources(SourceType sourceType)
        {
            XmlFile file = GetSourceTypeFile(sourceType);
            if (file.Exists)
            {
                return Deserialize(file.Path);
            }
            return Enumerable.Empty<Source>();
        }

        public void Save(Source source)
        {
            XmlFile file = GetSourceTypeFile(source.SourceType);
            string serializedSource = GetSerializedSource(source);
            File.AppendAllLines(file.Path, new List<string> { serializedSource });
        }

        public void Delete(Source source)
        {
            IEnumerable<Source> sources = GetSources(source.SourceType);
            IEnumerable<Source> newSources = sources.Where(src => src.Folder != source.Folder);
            ReplaceSources(newSources, source.SourceType);
        }

        private XmlFile GetSourceTypeFile(SourceType sourceType)
        {
            string fileName = sourceType.ToString() + ".xml";
            string folder = GetFolder();
            string fullFilePath = Path.Combine(folder, fileName);

            return new XmlFile(fullFilePath);
        }

        private string GetFolder()
        {
            string folder = Path.Combine(_basePath, "Sources");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            return folder;
        }

        private IEnumerable<Source> Deserialize(string path)
        {
            // For simplicity sake each sources are appended at the end of the file, so there are multiple root elements in the "XML document"
            // This isn't supported, except for XmlReader
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

        private string GetSerializedSource(Source source)
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
            XmlFile file = GetSourceTypeFile(sourceType);
            List<string> serializedSources = new List<string>();
            foreach (Source source in newSources)
            {
                string currentSerializedSource = GetSerializedSource(source);
                serializedSources.Add(currentSerializedSource);
            }
            File.Delete(file.Path);
            File.WriteAllLines(file.Path, serializedSources);
        }
    }
}
