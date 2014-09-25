using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PerfectMedia.Music.Artists
{
    [XmlType(Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    [XmlRoot("artist", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class ArtistSummary
    {
        [XmlAttribute("type")]
        public string ArtistType { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("sort-name")]
        public string SortName { get; set; }

        [XmlElement("life-span")]
        public LifeSpan LifeSpan { get; set; }

        [XmlElement("country")]
        public string Country { get; set; }

        [XmlAttribute("score", Namespace = "http://musicbrainz.org/ns/ext#-2.0")]
        public int Score { get; set; }

        [XmlElement("disambiguation")]
        public string Disambiguation { get; set; }

        [XmlIgnore]
        public List<Tag> TagList { get; set; }
    }
}