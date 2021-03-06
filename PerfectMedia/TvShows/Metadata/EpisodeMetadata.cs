﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using PerfectMedia.FileInformation;
using PerfectMedia.Serialization;

namespace PerfectMedia.TvShows.Metadata
{
    [Equals]
    [XmlRoot(ElementName = "episodedetails")]
    public class EpisodeMetadata
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "rating")]
        public double? Rating { get; set; }

        [XmlElement(ElementName = "season")]
        public int? SeasonNumber { get; set; }

        [XmlElement(ElementName = "episode")]
        public int? EpisodeNumber { get; set; }

        [XmlElement(ElementName = "plot")]
        public string Plot { get; set; }

        [XmlElement(ElementName = "thumb")]
        public string ImageUrl { get; set; }

        [XmlIgnore]
        public string ImagePath { get; set; }

        [XmlElement(ElementName = "playcount")]
        public int? PlayCount { get; set; }

        [XmlElement(ElementName = "lastplayed")]
        public string LastPlayedString
        {
            get { return NfoRepository.GetStringFromDateTime(LastPlayed); }
            set { LastPlayed = NfoRepository.GetDateTimeFromString(value); }
        }

        [XmlIgnore]
        public DateTime? LastPlayed { get; set; }

        [XmlElement(ElementName = "credits")]
        public List<string> Credits { get; set; }

        [XmlElement(ElementName = "director")]
        public List<string> Director { get; set; }

        [XmlElement(ElementName = "aired")]
        public string AiredDateString
        {
            get { return NfoRepository.GetStringFromDateTime(AiredDate); }
            set { AiredDate = NfoRepository.GetDateTimeFromString(value); }
        }

        [XmlIgnore]
        public DateTime? AiredDate { get; set; }

        // For media files containing multiple episodes, where value is the time where the next episode begins in seconds
        [XmlElement(ElementName = "epbookmark")]
        public double? EpisodeBookmarks { get; set; }

        // For TV show specials, determines how the episode is sorted in the seasons
        [XmlElement(ElementName = "displayseason")]
        public int? DisplaySeason { get; set; }

        // For TV show specials, determines how the episode is sorted in the series
        [XmlElement(ElementName = "displayepisode")]
        public int? DisplayEpisode { get; set; }

        [XmlElement(ElementName = "fileinfo")]
        public VideoFileInformation FileInformation { get; set; }

        public EpisodeMetadata()
        {
            Credits = new List<string>();
            Director = new List<string>();
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

        public bool ShouldSerializeRating()
        {
            return Rating.HasValue;
        }

        public bool ShouldSerializeSeasonNumber()
        {
            return SeasonNumber.HasValue;
        }

        public bool ShouldSerializeEpisodeNumber()
        {
            return EpisodeNumber.HasValue;
        }

        public bool ShouldSerializePlayCount()
        {
            return PlayCount.HasValue;
        }

        public bool ShouldSerializeFileInformation()
        {
            return FileInformation != null;
        }
    }
}
