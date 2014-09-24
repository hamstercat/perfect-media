using System;
using System.Collections.Generic;

namespace PerfectMedia.Music.Artists
{
    public class ArtistSummary
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ArtistType Type { get; set; }
        public LifeSpan LifeSpan { get; set; }
        public List<Tag> TagList { get; set; }
    }

    public enum ArtistType
    {
        Group,
        Person
    }
}