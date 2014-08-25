using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using PerfectMedia.Serialization;

namespace PerfectMedia.Music
{
    [XmlRoot(ElementName = "artist")]
    public class ArtistMetadata
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "genre")]
        public List<string> Genres { get; set; }

        [XmlElement(ElementName = "style")]
        public List<string> Styles { get; set; }

        [XmlElement(ElementName = "mood")]
        public List<string> Moods { get; set; }

        [XmlElement(ElementName = "yearsactive")]
        public List<int> YearsActive { get; set; }

        [XmlElement(ElementName = "born")]
        public string BornString
        {
            get { return NfoRepository.GetStringFromDateTime(BornOn); }
            set { BornOn = NfoRepository.GetDateTimeFromString(value); }
        }

        [XmlIgnore]
        public DateTime? BornOn { get; set; }

        [XmlElement(ElementName = "formed")]
        public string FormedOnString
        {
            get { return NfoRepository.GetStringFromDateTime(FormedOn); }
            set { FormedOn = NfoRepository.GetDateTimeFromString(value); }
        }

        [XmlIgnore]
        public DateTime? FormedOn { get; set; }

        [XmlElement(ElementName = "instruments")]
        public string Instruments { get; set; }

        [XmlElement(ElementName = "biography")]
        public string Biography { get; set; }

        [XmlElement(ElementName = "died")]
        public string DiedOnString
        {
            get { return NfoRepository.GetStringFromDateTime(DiedOn); }
            set { DiedOn = NfoRepository.GetDateTimeFromString(value); }
        }

        [XmlIgnore]
        public DateTime? DiedOn { get; set; }

        [XmlElement(ElementName = "disbanded")]
        public string DisbandedOnString
        {
            get { return NfoRepository.GetStringFromDateTime(DiedOn); }
            set { DiedOn = NfoRepository.GetDateTimeFromString(value); }
        }

        [XmlIgnore]
        public DateTime? DisbandedOn { get; set; }

        [XmlElement(ElementName = "album")]
        public List<Album> Albums { get; set; }

        public ArtistMetadata()
        {
            Genres = new List<string>();
            Styles = new List<string>();
            Moods = new List<string>();
            YearsActive = new List<int>();
            Albums = new List<Album>();
        }
    }
}
