using System.Collections.Generic;
using System.Xml.Serialization;

namespace PerfectMedia.Music.Artists
{
    [XmlType(Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    [XmlRoot("metadata", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class ArtistQueryMetadata
    {
        [XmlArray("artist-list")]
        [XmlArrayItem("artist")]
        public ArtistList Collection { get; set; }
    }
}
