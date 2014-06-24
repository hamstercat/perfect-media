using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
        public int RuntimeInMinutes { get; set; }

        [XmlElement(ElementName = "rating")]
        public double Rating { get; set; }

        [XmlElement(ElementName = "premiered", DataType = "date")]
        public DateTime? PremieredDate { get; set; }

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
    }

    public class ActorMetadata
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "role")]
        public string Role { get; set; }

        [XmlElement(ElementName = "thumb")]
        public string Thumb { get; set; }
    }
}
