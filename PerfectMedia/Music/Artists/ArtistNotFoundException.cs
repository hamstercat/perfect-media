using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Music.Artists
{
    [Serializable]
    public class ArtistNotFoundException : Exception
    {
        public ArtistNotFoundException()
        { }

        public ArtistNotFoundException(string message)
            : base(message)
        { }

        public ArtistNotFoundException(string message, Exception inner)
            : base(message, inner)
        { }

        protected ArtistNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
