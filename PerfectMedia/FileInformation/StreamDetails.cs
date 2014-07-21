using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PerfectMedia.FileInformation
{
    [Equals]
    public class StreamDetails
    {
        [XmlElement(ElementName = "video")]
        public List<Video> Videos { get; set; }

        [XmlElement(ElementName = "audio")]
        public List<Audio> Audios { get; set; }

        [XmlElement(ElementName = "subtitle")]
        public List<Subtitle> Subtitles { get; set; }

        public bool ShouldSerializeVideos()
        {
            return Videos != null;
        }

        public bool ShouldSerializeAudios()
        {
            return Audios != null;
        }

        public bool ShouldSerializeSubtitles()
        {
            return Subtitles != null;
        }
    }
}
