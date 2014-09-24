using System;
using System.Runtime.Serialization;

namespace PerfectMedia.Music.Albums
{
    [Serializable]
    public class AlbumNotFoundException : Exception
    {
        public AlbumNotFoundException()
        { }

        public AlbumNotFoundException(string message)
            : base(message)
        { }

        public AlbumNotFoundException(string message, Exception inner)
            : base(message, inner)
        { }

        protected AlbumNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
