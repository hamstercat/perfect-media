using System;
using System.Xml.Serialization;

namespace PerfectMedia.Music.Albums
{
    [XmlType(Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    [XmlRoot("release-group", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class ReleaseGroup
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        // Can be either YYYY-mm-dd or YYYY
        [XmlElement("first-release-date")]
        public string Date { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlElement("primary-type")]
        public string PrimaryType { get; set; }

        public int? Year
        {
            get
            {
                if (!string.IsNullOrEmpty(Date))
                {
                    string substring = Date.Substring(0, 4);
                    int year;
                    if (int.TryParse(substring, out year))
                    {
                        return year;
                    }
                }
                return null;
            }
        }

        public DateTime? DateTime
        {
            get
            {
                DateTime dateTime;
                if (System.DateTime.TryParse(Date, out dateTime))
                {
                    return dateTime;
                }
                return null;
            }
        }
    }
}
