﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace PerfectMedia.Music.Artists
{
    public class ArtistQueryMetadata
    {
        public List<ArtistSummary> ArtistList { get; set; }
    }
}
