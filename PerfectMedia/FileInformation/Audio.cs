using System.Xml.Serialization;

namespace PerfectMedia.FileInformation
{
    /// <summary>
    /// Represents an audio stream in a video or audio file.
    /// </summary>
    [Equals]
    public class Audio
    {
        /// <summary>
        /// Gets or sets the language code.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        [XmlElement(ElementName = "language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the number of channels.
        /// </summary>
        /// <value>
        /// The number of channels.
        /// </value>
        [XmlElement(ElementName = "channels")]
        public int NumberOfChannels { get; set; }

        /// <summary>
        /// Gets or sets the codec.
        /// </summary>
        /// <value>
        /// The codec.
        /// </value>
        [XmlElement(ElementName = "codec")]
        public string Codec { get; set; }
    }
}
