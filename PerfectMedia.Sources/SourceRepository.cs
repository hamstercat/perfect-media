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
        /// <param name="sourceType">Type of the sources.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Source>> GetSources(SourceType sourceType)
        {
            string file = await GetSourceTypeFile(sourceType);
            if (await _fileSystemService.FileExists(file))
            {
                return await Task.Run(() => Deserialize(file));
            }
            return Enumerable.Empty<Source>();
        }

        /// <summary>
        /// Saves the specified sources.
        /// </summary>
        /// <param name="sourceType">Type of the sources.</param>
        /// <param name="sources">The sources.</param>
        /// <returns></returns>
        public void Save(SourceType sourceType, IEnumerable<Source> sources)
        {
            string serializedSources = GetSerializedSource(sources.ToList());
            string file = GetSourceTypeFileSynchrnously(sourceType);
            _fileSystemService.CreateFileSynchronously(file, serializedSources);
        }

        private async Task<string> GetSourceTypeFile(SourceType sourceType)
        {
            string fileName = sourceType.ToString() + ".xml";
            string folder = await GetFolder();
            return Path.Combine(folder, fileName);
        }

        private string GetSourceTypeFileSynchrnously(SourceType sourceType)
        {
            string fileName = sourceType.ToString() + ".xml";
            string folder = GetFolderSynchronously();
            return Path.Combine(folder, fileName);
        }

        private async Task<string> GetFolder()
        {
            string folder = Path.Combine(_basePath, "Sources");
            await _fileSystemService.CreateFolder(folder);
            return folder;
        }

        private string GetFolderSynchronously()
        {
            string folder = Path.Combine(_basePath, "Sources");
            _fileSystemService.CreateFolderSynchronously(folder);
            return folder;
        }

        private static IEnumerable<Source> Deserialize(string path)
        {
            using (XmlReader reader = XmlReader.Create(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Source>));
                return (List<Source>)serializer.Deserialize(reader);
            }
        }

        private static string GetSerializedSource(List<Source> sources)
        {
            StringBuilder str = new StringBuilder();
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };
            using (XmlWriter writer = XmlWriter.Create(str, xmlWriterSettings))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Source>));
                serializer.Serialize(writer, sources);
            }
            return str.ToString();
        }
    }
}
