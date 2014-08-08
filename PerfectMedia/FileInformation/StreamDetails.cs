using System.Collections.Generic;
using System.Xml.Serialization;

namespace PerfectMedia.FileInformation
{
    /// <summary>
    /// Contains all the different streams (audio, video and subtitles) of a video or audio file.
    /// </summary>
    [Equals]
    public class StreamDetails
    {
        /// <summary>
        /// Gets or sets the video streams.
        /// </summary>
        /// <value>
        /// The video streams.
        /// </value>
        [XmlElement(ElementName = "video")]
        public List<Video> Videos { get; set; }

        /// <summary>
        /// Gets or sets the audio streams.
        /// </summary>
        /// <value>
        /// The audio streams.
        /// </value>
        [XmlElement(ElementName = "audio")]
        public List<Audio> Audios { get; set; }

        /// <summary>
        /// Gets or sets the subtitle streams.
        /// </summary>
        /// <value>
        /// The subtitle streams.
        /// </value>
        [XmlElement(ElementName = "subtitle")]
        public List<Subtitle> Subtitles { get; set; }

        /// <summary>
        /// Shoulds the serialize videos (used by XmlSerializer).
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeVideos()
        {
            return Videos != null;
        }

        /// <summary>
        /// Shoulds the serialize audios (used by XmlSerializer).
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeAudios()
        {
            return Audios != null;
        }

        /// <summary>
        /// Shoulds the serialize subtitles (used by XmlSerializer).
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeSubtitles()
        {
            return Subtitles != null;
        }
    }
}
