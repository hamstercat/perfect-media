using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PerfectMedia.FileInformation
{
    [Equals]
    public class Subtitle
    {
        [XmlElement(ElementName = "language")]
        public string Language { get; set; }
    }
}
