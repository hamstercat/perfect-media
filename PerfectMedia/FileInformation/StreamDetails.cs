using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PerfectMedia.FileInformation
{
    public class StreamDetails
    {
        [XmlElement(ElementName = "video")]
        public List<Video> Videos { get; set; }

        [XmlElement(ElementName = "audio")]
        public List<Audio> Audios { get; set; }

        public bool ShouldSerializeVideos()
        {
            return Videos != null;
        }

        public bool ShouldSerializeAudios()
        {
            return Audios != null;
        }
    }
}
