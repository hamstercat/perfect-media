using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PerfectMedia.Metadata
{
    public class TvShowMetadataService : ITvShowMetadataService
    {
        private const string NfoFile = "tvshow.nfo";

        public TvShowMetadata GetLocalMetadata(string path)
        {
            string nfoFileFullPath = Path.Combine(path, NfoFile);
            using (XmlReader reader = XmlReader.Create(nfoFileFullPath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TvShowMetadata));
                return (TvShowMetadata)serializer.Deserialize(reader);
            }
        }
    }
}
