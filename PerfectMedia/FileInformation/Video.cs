using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PerfectMedia.FileInformation
{
    public class Video
    {
        [XmlElement(ElementName = "aspect")]
        public string Aspect { get; set; }

        [XmlElement(ElementName = "codec")]
        public string Codec { get; set; }

        [XmlElement(ElementName = "durationinseconds")]
        public int DurationInSeconds { get; set; }

        [XmlElement(ElementName = "height")]
        public int Height { get; set; }

        [XmlElement(ElementName = "language")]
        public string Language { get; set; }

        [XmlElement(ElementName = "longlanguage")]
        public string LongLanguage { get; set; }

        [XmlElement(ElementName = "scantype")]
        public string ScanType { get; set; }

        [XmlElement(ElementName = "width")]
        public int Width { get; set; }
    }
}
