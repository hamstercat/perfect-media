using System.Xml.Serialization;

namespace PerfectMedia.Music.Albums
{
    [XmlType(Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    [XmlRoot("metadata", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class AlbumQueryMetadata
    {
        [XmlArray("release-group-list")]
        [XmlArrayItem("release-group")]
        public ReleaseGroupList Collection { get; set; }
    }
}
