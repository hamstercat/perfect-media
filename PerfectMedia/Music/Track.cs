using System;
using System.Globalization;
using System.Xml.Serialization;

namespace PerfectMedia.Music
{
    public class Track
    {
        private const string TrackDurationFormat = "%m min, mm:ss";

        [XmlElement(ElementName = "position")]
        public int Position { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "duration")]
        public string DurationString
        {
            get
            {
                if (Duration.HasValue)
                {
                    return Duration.Value.ToString(TrackDurationFormat);
                }
                return null;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Duration = TimeSpan.ParseExact(value, TrackDurationFormat, CultureInfo.InvariantCulture);
                }
                Duration = null;
            }
        }

        [XmlIgnore]
        public TimeSpan? Duration { get; set; }
    }
}