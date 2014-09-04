using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using PerfectMedia.Serialization;

namespace PerfectMedia.Sources
{
    /// <summary>
    /// Repository that allows the persistance of sources to XML files located around the .exe file.
    /// </summary>
    public class SourceRepository : ISourceRepository
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IXmlSerializerFactory _xmlSerializerFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceRepository" /> class.
        /// </summary>
        /// <param name="fileSystemService">The file system service.</param>
        /// <param name="xmlSerializerFactory">The XML serializer factory.</param>
        public SourceRepository(IFileSystemService fileSystemService, IXmlSerializerFactory xmlSerializerFactory)
        {
            _fileSystemService = fileSystemService;
            _xmlSerializerFactory = xmlSerializerFactory;
        }

        /// <summary>
        /// Gets all the sources.
        /// </summary>
        /// <param name="sourceType">Type of the sources.</param>
        /// <returns></returns>
        public IEnumerable<Source> GetSources(SourceType sourceType)
        {
            string file = GetSourceTypeFile(sourceType);
            if (_fileSystemService.FileExistsSynchronously(file))
            {
                return Deserialize(file);
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
            string file = GetSourceTypeFile(sourceType);
            _fileSystemService.CreateFile(file, serializedSources);
        }

        private string GetSourceTypeFile(SourceType sourceType)
        {
            string fileName = sourceType.ToString() + ".xml";
            string folder = GetFolder();
            return Path.Combine(folder, fileName);
        }

        private string GetFolder()
        {
            string folder = SettingsHelper.GetAppDataFilePath("Sources");
            _fileSystemService.CreateFolderSynchronously(folder);
            return folder;
        }

        private IEnumerable<Source> Deserialize(string path)
        {
            using (XmlReader reader = XmlReader.Create(path))
            {
                XmlSerializer serializer = _xmlSerializerFactory.GetXmlSerializer<List<Source>>();
                return (List<Source>)serializer.Deserialize(reader);
            }
        }

        private string GetSerializedSource(List<Source> sources)
        {
            StringBuilder str = new StringBuilder();
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };
            using (XmlWriter writer = XmlWriter.Create(str, xmlWriterSettings))
            {
                XmlSerializer serializer = _xmlSerializerFactory.GetXmlSerializer<List<Source>>();
                serializer.Serialize(writer, sources);
            }
            return str.ToString();
        }
    }
}
