using System.Collections.Generic;
using System.Xml.Serialization;

namespace PerfectMedia.Music.Albums
{
    [XmlRoot("release-group-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class ReleaseGroupList : List<ReleaseGroup>
    {
        [XmlAttribute("count")]
        public int TotalCount { get; set; }
    }
}