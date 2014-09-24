using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using PerfectMedia.Serialization;

namespace PerfectMedia.Music.Albums
{
    [XmlRoot(ElementName = "album")]
    public class AlbumMetadata
    {
        [XmlElement(ElementName = "id")]
        public string Mbid { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "artist")]
        public List<string> Artists { get; set; }

        [XmlElement(ElementName = "genre")]
        public List<string> Genres { get; set; }

        [XmlElement(ElementName = "style")]
        public List<string> Styles { get; set; }

        [XmlElement(ElementName = "mood")]
        public List<string> Moods { get; set; }

        [XmlElement(ElementName = "theme")]
        public List<string> Themes { get; set; }

        [XmlElement(ElementName = "review")]
        public string Review { get; set; }

        [XmlElement(ElementName = "releasedate")]
        public string ReleaseDateString
        {
            get { return NfoRepository.GetStringFromDateTime(ReleaseDate); }
            set { ReleaseDate = NfoRepository.GetDateTimeFromString(value); }
        }

        [XmlIgnore]
        public DateTime? ReleaseDate { get; set; }

        [XmlElement(ElementName = "label")]
        public string Label { get; set; }

        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "year")]
        public int? Year { get; set; }

        [XmlElement(ElementName = "rating")]
        public double? Rating { get; set; }

        [XmlElement(ElementName = "thumb")]
        public string Thumb { get; set; }

        [XmlElement(ElementName = "track")]
        public List<Track> Tracks { get; set; }

        public AlbumMetadata()
        {
            Artists = new List<string>();
            Genres = new List<string>();
            Styles = new List<string>();
            Moods = new List<string>();
            Themes = new List<string>();
            Tracks = new List<Track>();
        }

        public bool ShouldSerializeYear()
        {
            return Year.HasValue;
        }

        public bool ShouldSerializeRating()
        {
            return Rating.HasValue;
        }
    }
}
