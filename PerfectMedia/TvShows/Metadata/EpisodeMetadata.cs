using PerfectMedia.FileInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PerfectMedia.TvShows.Metadata
{
    [XmlRoot(ElementName = "episodedetails")]
    public class EpisodeMetadata
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "rating")]
        public double Rating { get; set; }

        [XmlElement(ElementName = "season")]
        public int SeasonNumber { get; set; }

        [XmlElement(ElementName = "episode")]
        public int EpisodeNumber { get; set; }

        [XmlElement(ElementName = "plot")]
        public string Plot { get; set; }

        [XmlElement(ElementName = "thumb")]
        public string ImageUrl { get; set; }

        [XmlIgnore]
        public string ImagePath { get; set; }

        [XmlElement(ElementName = "playcount")]
        public int Playcount { get; set; }

        [XmlElement(ElementName = "lastplayed", DataType="date")]
        public DateTime? LastPlayed { get; set; }

        [XmlElement(ElementName = "credits")]
        public string Credits { get; set; }

        [XmlElement(ElementName = "director")]
        public string Director { get; set; }

        [XmlElement(ElementName = "aired", DataType="date")]
        public DateTime? AiredDate { get; set; }

        [XmlElement(ElementName = "premiered", DataType="date")]
        public DateTime? PremieredDate { get; set; }

        [XmlElement(ElementName = "studio")]
        public string Studio { get; set; }

        [XmlElement(ElementName = "mpaa")]
        public string MpaaRating { get; set; }

        // For media files containing multiple episodes, where value is the time where the next episode begins in seconds
        [XmlElement(ElementName = "epbookmark")]
        public List<int> EpisodeBookmarks { get; set; }

        [XmlElement(ElementName = "displayseason")]
        public int? DisplaySeason { get; set; }

        // For TV show specials, determines how the episode is sorted in the series
        [XmlElement(ElementName = "displayepisode")]
        public int? DisplayEpisode { get; set; }

        [XmlElement(ElementName = "actor")]
        public List<ActorMetadata> Actors { get; set; }

        [XmlElement(ElementName = "fileinfo")]
        public VideoFileInformation FileInformation { get; set; }

        public EpisodeMetadata()
        {
            EpisodeBookmarks = new List<int>();
            Actors = new List<ActorMetadata>();
        }

        public bool ShouldSerializeLastPlayed()
        {
            return LastPlayed.HasValue;
        }

        public bool ShouldSerializeAiredDate()
        {
            return AiredDate.HasValue;
        }

        public bool ShouldSerializePremieredDate()
        {
            return PremieredDate.HasValue;
        }

        public bool ShouldSerializeEpisodeBookmarks()
        {
            return EpisodeBookmarks != null;
        }

        public bool ShouldSerializeDisplaySeason()
        {
            return DisplayEpisode.HasValue;
        }

        public bool ShouldSerializeDisplayEpisode()
        {
            return DisplayEpisode.HasValue;
        }

        public bool ShouldSerializeActors()
        {
            return Actors != null;
        }

        public bool ShouldSerializeFileInformation()
        {
            return FileInformation != null;
        }
    }
}
