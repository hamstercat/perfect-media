using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia
{
    [Serializable]
    public class ScrapperException : Exception
    {
        public ScrapperException() { }
        public ScrapperException(string message) : base(message) { }
        public ScrapperException(string message, Exception inner) : base(message, inner) { }
        protected ScrapperException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
