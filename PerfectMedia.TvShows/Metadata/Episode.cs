using System;

namespace PerfectMedia.TvShows.Metadata
{
    public class Episode
    {
        public string Director { get; set; }
        public string EpisodeName { get; set; }
        public int EpisodeNumber { get; set; }
        public DateTime? FirstAired { get; set; }
        public string Overview { get; set; }
        public double Rating { get; set; }
        public int SeasonNumber { get; set; }
        public string Writer { get; set; }
        public int? AbsoluteNumber { get; set; }
        public int? AirsAfterSeason { get; set; }
        public int? AirsBeforeEpisode { get; set; }
        public int? AirsBeforeSeason { get; set; }
        public string Filename { get; set; }
    }
}
