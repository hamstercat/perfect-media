using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PerfectMedia.Serialization
{
    /// <summary>
    /// Provides utility methods when working with .nfo files.
    /// </summary>
    public abstract class NfoRepository
    {
        /// <summary>
        /// Gets the string from date time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string GetStringFromDateTime(DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return dateTime.Value.ToString("yyyy-MM-dd");
            return null;
        }

        /// <summary>
        /// Gets the date time from string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DateTime? GetDateTimeFromString(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;
            return DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
    }

    /// <summary>
    /// Base class for repositories based on XBMC's .nfo files.
    /// </summary>
    public abstract class NfoRepository<TMetadata> : NfoRepository
        where TMetadata : new()
    {
        /// <summary>
        /// Gets the path to the .nfo file.
        /// </summary>
        /// <param name="path">The path to the media.</param>
        /// <returns></returns>
        protected abstract string GetNfoFile(string path);

        private readonly IFileSystemService _fileSystemService;
        private readonly IXmlSerializerFactory _xmlSerializerFactory;

        private static XmlSerializerNamespaces NoNamespaces
        {
            get
            {
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);
                return namespaces;
            }
        }

        protected NfoRepository(IFileSystemService fileSystemService, IXmlSerializerFactory xmlSerializerFactory)
        {
            _fileSystemService = fileSystemService;
            _xmlSerializerFactory = xmlSerializerFactory;
        }

        /// <summary>
        /// Gets the metadata associated with the media located at the specified path.
        /// </summary>
        /// <param name="path">The path of the media.</param>
        /// <returns></returns>
        public virtual async Task<TMetadata> Get(string path)
        {
            string nfoFileFullPath = GetNfoFile(path);
            if (!await _fileSystemService.FileExists(nfoFileFullPath))
            {
                return new TMetadata();
            }
            return Deserialize(nfoFileFullPath);
        }

        /// <summary>
        /// Saves the metadata associated with the media located at the specified path.
        /// </summary>
        /// <param name="path">The path of the media.</param>
        /// <param name="metadata">The metadata.</param>
        public virtual Task Save(string path, TMetadata metadata)
        {
            return Task.Run(() =>
            {
                string nfoFileFullPath = GetNfoFile(path);
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };
                using (XmlWriter writer = XmlWriter.Create(nfoFileFullPath, xmlWriterSettings))
                {
                    Serialize(writer, metadata);
                }
            });
        }

        /// <summary>
        /// Deletes the metadata associated with the media located at the specified path.
        /// </summary>
        /// <param name="path">The path of the media.</param>
        public virtual async Task Delete(string path)
        {
            string nfoFileFullPath = GetNfoFile(path);
            await _fileSystemService.DeleteFile(nfoFileFullPath);
        }

        private TMetadata Deserialize(string nfoFileFullPath)
        {
            using (XmlReader reader = XmlReader.Create(nfoFileFullPath))
            {
                XmlSerializer serializer = _xmlSerializerFactory.GetXmlSerializer<TMetadata>();
                return (TMetadata)serializer.Deserialize(reader);
            }
        }

        private void Serialize(XmlWriter writer, TMetadata metadata)
        {
            WriteXmlDeclaration(writer);
            XmlSerializer serializer = _xmlSerializerFactory.GetXmlSerializer<TMetadata>();
            serializer.Serialize(writer, metadata, NoNamespaces);
        }

        private static void WriteXmlDeclaration(XmlWriter writer)
        {
            writer.WriteRaw("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>\r\n");
        }
    }
}
