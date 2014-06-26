using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.FileInformation
{
    internal static class CodecHelper
    {
        private static readonly string[] _knownVideoCodecs;
        private static readonly string[] _knownAudioCodecs;

        static CodecHelper()
        {
            _knownVideoCodecs = ConfigurationManager.AppSettings["KnownVideoCodecs"].Split(',');
            _knownAudioCodecs = ConfigurationManager.AppSettings["KnownAudioCodecs"].Split(',');
        }

        internal static string GetVideoCodecName(string codecCommonName, string codecId, string format)
        {
            string codec = DetermineVideoCodec(codecCommonName.ToLower(), codecId.ToLower(), format.ToLower());
            if (!_knownVideoCodecs.Contains(codec.ToLower()))
            {
                throw new UnknownCodecException(codecCommonName, codecId, format);
            }
            return codec.ToUpper();
        }

        internal static string GetAudioCodecName(string codecCommonName, string codecId, string format)
        {
            string codec = string.IsNullOrEmpty(codecCommonName) ? format : codecCommonName;
            if (!_knownAudioCodecs.Contains(codec.ToLower()))
            {
                throw new UnknownCodecException(codecCommonName, codecId, format);
            }
            return codec.ToUpper();
        }

        private static string DetermineVideoCodec(string codecCommonName, string codecId, string format)
        {
            // TODO: finish up codec
            switch (format)
            {
                case "avc":
                    return "H264";
                default:
                    return codecId;
            }
        }
    }
}
