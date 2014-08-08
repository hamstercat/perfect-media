using System;
using System.Runtime.Serialization;

namespace PerfectMedia
{
    [Serializable]
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() { }
        public ItemNotFoundException(string message) : base(message) { }
        public ItemNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected ItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
