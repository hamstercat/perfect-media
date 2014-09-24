using System.Collections.Generic;
using System.Xml.Serialization;

namespace PerfectMedia.Music.Artists
{
    public class ArtistList : List<ArtistSummary>
    {
        public int QueryCount { get; set; }
    }
}