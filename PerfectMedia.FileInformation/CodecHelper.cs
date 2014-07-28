using Anotar.Log4Net;
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
            LogUnknownCodec(_knownVideoCodecs, codec, codecCommonName, codecId, format);
            return codec.ToUpper();
        }

        internal static string GetAudioCodecName(string codecCommonName, string codecId, string format)
        {
            string codec = DetermineAudioCodec(codecCommonName, codecId, format);
            LogUnknownCodec(_knownAudioCodecs, codec, codecCommonName, codecId, format);
            return codec.ToUpper();
        }

        private static string DetermineVideoCodec(string codecCommonName, string codecId, string format)
        {
            // TODO: finish up codec
            switch (format)
            {
                case "avc":
                    return "H264";
            }
            switch (codecCommonName)
            {
                case "xvid":
                    return "xvid";
            }
            if (codecCommonName.StartsWith("divx"))
                return "divx";
            return codecCommonName;
        }

        private static string DetermineAudioCodec(string codecCommonName, string codecId, string format)
        {
            // TODO: finish up codec
            switch (format.ToLower())
            {
                case "wma":
                    return "wmav2";
                case "mpeg audio":
                    return "mp2";
                case "pcm":
                    if (codecId == "sowt")
                        return "pcm_s16le";
                    break;
                case "ac-3":
                    return "ac3";
            }

            if (string.IsNullOrEmpty(codecCommonName))
                return format;
            return codecCommonName;
        }

        private static void LogUnknownCodec(IEnumerable<string> knownCodecs, string codec, string codecCommonName, string codecId, string format)
        {
            if (!_knownVideoCodecs.Contains(codec.ToLower()))
            {
                LogTo.Warn("Unknown codec was found: " + codec); ;
                LogTo.Warn("    -codecCommonName: " + codecCommonName);
                LogTo.Warn("    -codecId: " + codecId);
                LogTo.Warn("    -format: " + format);
            }
        }
    }
}
