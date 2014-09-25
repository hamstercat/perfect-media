using System.Xml.Serialization;

namespace PerfectMedia.Music.Artists
{
    [XmlType(Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    [XmlRoot("life-span", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class LifeSpan
    {
        // Can be either YYYY-mm-dd or YYYY
        [XmlElement("begin")]
        public string Begin { get; set; }
        // Can be either YYYY-mm-dd or YYYY
        [XmlElement("end")]
        public string End { get; set; }
        [XmlElement("Ended")]
        public bool Ended { get; set; }
    }
}