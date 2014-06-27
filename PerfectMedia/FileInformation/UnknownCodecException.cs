using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.FileInformation
{
    [Serializable]
    public class UnknownCodecException : Exception
    {
        public string CodecCommonName { get; private set; }
        public string CodecId { get; private set; }
        public string Format { get; private set; }

        public UnknownCodecException(string codecCommonName, string codecId, string format)
            : base(string.Format("Couldn't determine the codec based on these information: {{ codecCommonName: {0}, codecId: {1}, format: {2} }}", codecCommonName, codecId, format))
        {
            CodecCommonName = codecCommonName;
            CodecId = codecId;
            Format = format;
        }
    }
}
