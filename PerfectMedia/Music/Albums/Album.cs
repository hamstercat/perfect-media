using System.Xml.Serialization;

namespace PerfectMedia.Music.Albums
{
    public class Album
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "year")]
        public int Year { get; set; }
    }
}