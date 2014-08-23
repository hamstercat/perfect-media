using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using PerfectMedia.Serialization;

namespace PerfectMedia.TvShows.Metadata
{
    [XmlRoot(ElementName = "tvshow", Namespace = "")]
    public class TvShowMetadata
    {
        [XmlElement(ElementName = "state")]
        public int State { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "mpaa")]
        public string MpaaRating { get; set; }

        [XmlElement(ElementName = "genre")]
        public List<string> Genres { get; set; }

        [XmlElement(ElementName = "imdbid")]
        public string ImdbId { get; set; }

        [XmlElement(ElementName = "plot")]
        public string Plot { get; set; }

        [XmlElement(ElementName = "runtime")]
        public int? RuntimeInMinutes { get; set; }

        [XmlElement(ElementName = "rating")]
        public double? Rating { get; set; }

        [XmlElement(ElementName = "premiered")]
        public string PremieredString
        {
            get { return NfoRepository.GetStringFromDateTime(Premiered); }
            set { Premiered = NfoRepository.GetDateTimeFromString(value); }
        }

        [XmlIgnore]
        public DateTime? Premiered { get; set; }

        [XmlElement(ElementName = "studio")]
        public string Studio { get; set; }

        [XmlElement(ElementName = "language")]
        public string Language { get; set; }

        [XmlElement(ElementName = "actor")]
        public List<ActorMetadata> Actors { get; set; }

        public TvShowMetadata()
        {
            Genres = new List<string>();
            Actors = new List<ActorMetadata>();
        }

        public bool ShouldSerializeGenres()
        {
            return Genres != null;
        }

        public bool ShouldSerializeRuntimeInMinutes()
        {
            return RuntimeInMinutes.HasValue;
        }

        public bool ShouldSerializeRating()
        {
            return Rating.HasValue;
        }

        public bool ShouldSerializeActors()
        {
            return Actors != null;
        }
    }
}
