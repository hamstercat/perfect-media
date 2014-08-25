using System.Collections.Generic;
using System.Xml.Serialization;

namespace PerfectMedia.Music
{
    public class Album
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "year")]
        public int Year { get; set; }
    }
}