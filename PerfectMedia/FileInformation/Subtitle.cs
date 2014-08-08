using System.Xml.Serialization;

namespace PerfectMedia.FileInformation
{
    /// <summary>
    /// Represents a subtitle stream in a video file.
    /// </summary>
    [Equals]
    public class Subtitle
    {
        /// <summary>
        /// Gets or sets the language code.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        [XmlElement(ElementName = "language")]
        public string Language { get; set; }
    }
}
