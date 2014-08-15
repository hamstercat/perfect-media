using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PerfectMedia.Sources
{
    /// <summary>
    /// Repository that allows the persistance of sources to XML files located around the .exe file.
    /// </summary>
    public class SourceRepository : ISourceRepository
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly string _basePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceRepository"/> class.
        /// </summary>
        /// <param name="fileSystemService">The file system service.</param>
        public SourceRepository(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
            // Save the file in an XML located in the same folder as the executable
            string assemblyFolder = Assembly.GetExecutingAssembly().Location;
            _basePath = Path.GetDirectoryName(assemblyFolder);
        }

        /// <summary>
        /// Gets all the sources.
        /// </summary>
        /// <param name="sourceType">Type of the source.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Source>> GetSources(SourceType sourceType)
        {
            string file = await GetSourceTypeFile(sourceType);
            if (await _fileSystemService.FileExists(file))
            {
                return Deserialize(file);
            }
            return Enumerable.Empty<Source>();
        }

        /// <summary>
        /// Saves the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        public async Task Save(Source source)
        {
            string file = await GetSourceTypeFile(source.SourceType);
            string serializedSource = GetSerializedSource(source);
            File.AppendAllLines(file, new List<string> { serializedSource });
        }

        /// <summary>
        /// Deletes the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        public async Task Delete(Source source)
        {
            IEnumerable<Source> sources = await GetSources(source.SourceType);
            IEnumerable<Source> newSources = sources.Where(src => src.Folder != source.Folder);
            await ReplaceSources(newSources, source.SourceType);
        }

        private async Task<string> GetSourceTypeFile(SourceType sourceType)
        {
            string fileName = sourceType.ToString() + ".xml";
            string folder = await GetFolder();
            return Path.Combine(folder, fileName);
        }

        private async Task<string> GetFolder()
        {
            string folder = Path.Combine(_basePath, "Sources");
            if (!await _fileSystemService.FolderExists(folder))
            {
                await _fileSystemService.CreateFolder(folder);
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

        private async Task ReplaceSources(IEnumerable<Source> newSources, SourceType sourceType)
        {
            string file = await GetSourceTypeFile(sourceType);
            IEnumerable<string> serializedSources = newSources.Select(GetSerializedSource);
            await _fileSystemService.DeleteFile(file);
            await _fileSystemService.CreateFile(file, serializedSources);
        }
    }
}
