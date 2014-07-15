using PerfectMedia.FileInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PerfectMedia.Movies
{
    [XmlRoot(ElementName = "movie")]
    public class MovieMetadata
    {
        // TODO: <trailer></trailer>

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "originaltitle")]
        public string OriginalTitle { get; set; }

        [XmlElement(ElementName = "set")]
        public string SetName { get; set; }

        [XmlElement(ElementName = "rating")]
        public double? Rating { get; set; }

        [XmlElement(ElementName = "year")]
        public int? Year { get; set; }

        [XmlElement(ElementName = "premiered", DataType = "date")]
        public DateTime? Premiered { get; set; }

        [XmlElement(ElementName = "outline")]
        public string Outline { get; set; }

        [XmlElement(ElementName = "plot")]
        public string Plot { get; set; }

        [XmlElement(ElementName = "tagline")]
        public string Tagline { get; set; }

        [XmlElement(ElementName = "runtime")]
        public int RuntimeInMinutes { get; set; }

        [XmlElement(ElementName = "playcount")]
        public int PlayCount { get; set; }

        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "genre")]
        public List<string> Genres { get; set; }

        [XmlElement(ElementName = "fileinfo")]
        public VideoFileInformation FileInformation { get; set; }

        [XmlElement(ElementName = "studio")]
        public string Studio { get; set; }

        [XmlElement(ElementName = "actor")]
        public List<ActorMetadata> Actors { get; set; }

        public MovieMetadata()
        {
            Genres = new List<string>();
            Actors = new List<ActorMetadata>();
        }

        public bool ShouldSerializeRating()
        {
            return Rating.HasValue;
        }

        public bool ShouldSerializePremiered()
        {
            return Premiered.HasValue;
        }

        public bool ShouldSerializeYear()
        {
            return Year.HasValue;
        }

        public bool ShouldSerializeGenres()
        {
            return Genres != null;
        }

        public bool ShouldSerializeFileInformation()
        {
            return FileInformation != null;
        }

        public bool ShouldSerializeActors()
        {
            return Actors.Any();
        }
    }
}
