using System.Collections.Generic;
using System.Xml.Serialization;

namespace PerfectMedia.Music.Artists
{
    [XmlRoot("artist-list", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class ArtistList : List<ArtistSummary>
    {
        [XmlAttribute("count")]
        public int TotalCount { get; set; }
    }
}