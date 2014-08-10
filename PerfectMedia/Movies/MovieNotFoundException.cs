using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    [Serializable]
    public class MovieNotFoundException : Exception
    {
        public MovieNotFoundException() { }
        public MovieNotFoundException(string message) : base(message) { }
        public MovieNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected MovieNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
