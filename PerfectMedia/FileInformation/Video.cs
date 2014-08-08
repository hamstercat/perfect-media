using System.Xml.Serialization;

namespace PerfectMedia.FileInformation
{
    /// <summary>
    /// Represents a video stream in a video file.
    /// </summary>
    [Equals]
    public class Video
    {
        /// <summary>
        /// Gets or sets the aspect ratio.
        /// </summary>
        /// <value>
        /// The aspect.
        /// </value>
        [XmlElement(ElementName = "aspect")]
        public string Aspect { get; set; }

        /// <summary>
        /// Gets or sets the codec.
        /// </summary>
        /// <value>
        /// The codec.
        /// </value>
        [XmlElement(ElementName = "codec")]
        public string Codec { get; set; }

        /// <summary>
        /// Gets or sets the duration in seconds.
        /// </summary>
        /// <value>
        /// The duration in seconds.
        /// </value>
        [XmlElement(ElementName = "durationinseconds")]
        public int DurationInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        [XmlElement(ElementName = "height")]
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the language code.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        [XmlElement(ElementName = "language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the long language.
        /// </summary>
        /// <value>
        /// The long language.
        /// </value>
        [XmlElement(ElementName = "longlanguage")]
        public string LongLanguage { get; set; }

        /// <summary>
        /// Gets or sets the scan type.
        /// </summary>
        /// <value>
        /// Scan type.
        /// </value>
        [XmlElement(ElementName = "scantype")]
        public string ScanType { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        [XmlElement(ElementName = "width")]
        public int Width { get; set; }
    }
}
