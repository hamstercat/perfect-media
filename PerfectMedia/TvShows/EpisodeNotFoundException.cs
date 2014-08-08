using System;
using System.Runtime.Serialization;

namespace PerfectMedia.TvShows
{
    [Serializable]
    public class EpisodeNotFoundException : Exception
    {
        public EpisodeNotFoundException() { }
        public EpisodeNotFoundException(string message) : base(message) { }
        public EpisodeNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected EpisodeNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
