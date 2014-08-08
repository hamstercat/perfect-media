using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Anotar.Log4Net;

namespace PerfectMedia.FileInformation
{
    internal static class CodecHelper
    {
        private static readonly string[] KnownVideoCodecs;
        private static readonly string[] KnownAudioCodecs;

        static CodecHelper()
        {
            KnownVideoCodecs = ConfigurationManager.AppSettings["KnownVideoCodecs"].Split(',');
            KnownAudioCodecs = ConfigurationManager.AppSettings["KnownAudioCodecs"].Split(',');
        }

        internal static string GetVideoCodecName(string codecCommonName, string codecId, string format)
        {
            string codec = DetermineVideoCodec(codecCommonName.ToLower(), codecId.ToLower(), format.ToLower());
            LogUnknownCodec(KnownVideoCodecs, "video", codec, codecCommonName, codecId, format);
            return codec.ToUpper();
        }

        internal static string GetAudioCodecName(string codecCommonName, string codecId, string format)
        {
            string codec = DetermineAudioCodec(codecCommonName, codecId, format);
            LogUnknownCodec(KnownAudioCodecs, "audio", codec, codecCommonName, codecId, format);
            return codec.ToUpper();
        }

        private static string DetermineVideoCodec(string codecCommonName, string codecId, string format)
        {
            // TODO: finish up codec
            switch (format)
            {
                case "avc":
                    switch (codecId)
	                {
                        case "avc1":
                            return "avc1";
                        default:
                            return "h264";
	                }
            }
            switch (codecCommonName)
            {
                case "xvid":
                    return "xvid";
            }

            if (codecCommonName.StartsWith("divx"))
                return "divx";
            return codecCommonName.ToLower();
        }

        private static string DetermineAudioCodec(string codecCommonName, string codecId, string format)
        {
            // TODO: finish up codec
            switch (format.ToLower())
            {
                case "wma":
                    return "wmav2";
                case "pcm":
                    if (codecId == "sowt")
                        return "pcm_s16le";
                    break;
                case "ac-3":
                    return "ac3";
            }

            if (string.IsNullOrEmpty(codecCommonName))
                return format.ToLower();
            return codecCommonName.ToLower();
        }

        private static void LogUnknownCodec(IEnumerable<string> knownCodecs, string codecType, string codec, string codecCommonName, string codecId, string format)
        {
            LogTo.Debug("    -> codecCommonName = {0}, codecId = {1}, format = {2}", codecCommonName, codecId, format);
            if (!knownCodecs.Contains(codec.ToLower()))
            {
                LogTo.Warn("Unknown codec was found for codec type {0}: {1}", codecType, codec);
                LogTo.Warn("    -codecCommonName: " + codecCommonName);
                LogTo.Warn("    -codecId: " + codecId);
                LogTo.Warn("    -format: " + format);
            }
        }
    }
}
