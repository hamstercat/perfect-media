using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PerfectMedia
{
    public abstract class NfoRepository<TMetadata>
        where TMetadata : new()
    {
        protected abstract string GetNfoFile(string path);

        private readonly IFileSystemService _fileSystemService;

        protected NfoRepository(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        public virtual TMetadata Get(string path)
        {
            string nfoFileFullPath = GetNfoFile(path);
            if (!_fileSystemService.FileExists(nfoFileFullPath))
            {
                return new TMetadata();
            }
            return Deserialize(nfoFileFullPath);
        }

        public virtual void Save(string path, TMetadata metadata)
        {
            string nfoFileFullPath = GetNfoFile(path);
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };
            using (XmlWriter writer = XmlWriter.Create(nfoFileFullPath, xmlWriterSettings))
            {
                writer.WriteRaw("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>\r\n");

                XmlSerializer serializer = new XmlSerializer(typeof(TMetadata));
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                serializer.Serialize(writer, metadata, namespaces);
            }
        }

        public virtual void Delete(string path)
        {
            string nfoFileFullPath = GetNfoFile(path);
            _fileSystemService.DeleteFile(nfoFileFullPath);
        }

        private static TMetadata Deserialize(string nfoFileFullPath)
        {
            using (XmlReader reader = XmlReader.Create(nfoFileFullPath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TMetadata));
                return (TMetadata)serializer.Deserialize(reader);
            }
        }
    }
}
