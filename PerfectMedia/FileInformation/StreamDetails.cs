using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PerfectMedia.FileInformation
{
    public class StreamDetails
    {
        [XmlElement(ElementName = "audio")]
        public Audio Audio { get; set; }

        [XmlElement(ElementName = "video")]
        public Video Video { get; set; }

        public bool ShouldSerializeAudio()
        {
            return Audio != null;
        }

        public bool ShouldSerializeVideo()
        {
            return Video != null;
        }
    }
}
