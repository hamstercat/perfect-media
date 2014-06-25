using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PerfectMedia.TvShows.Metadata
{
    public class ActorMetadata
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "role")]
        public string Role { get; set; }

        [XmlElement(ElementName = "thumb")]
        public string Thumb { get; set; }
    }
}
