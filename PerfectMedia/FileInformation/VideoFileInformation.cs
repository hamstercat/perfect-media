using System.Xml.Serialization;

namespace PerfectMedia.FileInformation
{
    /// <summary>
    /// Contains details about the streams of a video file.
    /// </summary>
    [Equals]
    public class VideoFileInformation
    {
        /// <summary>
        /// Gets or sets the stream details.
        /// </summary>
        /// <value>
        /// The stream details.
        /// </value>
        [XmlElement(ElementName = "streamdetails")]
        public StreamDetails StreamDetails { get; set; }

        /// <summary>
        /// Shoulds the serialize stream details (used by XmlSerializer).
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeStreamDetails()
        {
            return StreamDetails != null;
        }
    }
}
