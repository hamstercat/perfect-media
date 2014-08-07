using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia
{
    [Serializable]
    public class ApiException : Exception
    {
        public ApiException() { }
        public ApiException(string message) : base(message) { }
        public ApiException(string message, Exception inner) : base(message, inner) { }
        protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
