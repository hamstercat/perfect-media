using System.Collections.Generic;
using System.Xml.Serialization;

namespace PerfectMedia.Music.Artists
{
    [XmlRoot("artist-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class ArtistList : List<ArtistSummary>
    {
        [XmlAttribute("count")]
        public int QueryCount { get; set; }

        [XmlAttribute("offset")]
        public int QueryOffset { get; set; }
    }
}