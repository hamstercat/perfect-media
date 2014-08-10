using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows
{
    [Serializable]
    public class TvShowNotFoundException : Exception
    {
        public TvShowNotFoundException() { }
        public TvShowNotFoundException(string message) : base(message) { }
        public TvShowNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected TvShowNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
