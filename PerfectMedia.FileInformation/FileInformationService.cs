using Anotar.Log4Net;
using MediaInfoDotNet;
using MediaInfoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.FileInformation
{
    public class FileInformationService : IFileInformationService
    {
        public VideoFileInformation GetVideoFileInformation(string file)
        {
            LogTo.Debug("Determining codec for file {0}...", file);
            VideoFileInformation videoFileInformation = new VideoFileInformation { StreamDetails = new StreamDetails() };
            using (MediaFile mediaFile = new MediaFile(file))
            {
                videoFileInformation.StreamDetails.Audios = GetAudioTracks(mediaFile.Audio).ToList();
                videoFileInformation.StreamDetails.Videos = GetVideoTracks(mediaFile.Video).ToList();
                videoFileInformation.StreamDetails.Subtitles = GetSubtitleTracks(mediaFile.Text).ToList();
            }
            return videoFileInformation;
        }

        private IEnumerable<Audio> GetAudioTracks(IDictionary<int, AudioStream> audioTracks)
        {
            foreach (var audioTrack in audioTracks)
            {
                yield return ConvertAudioStream(audioTrack.Value);
            }
        }

        private static Audio ConvertAudioStream(AudioStream stream)
        {
            Audio audio = new Audio
            {
                Language = LanguageHelper.GetLanguageCode(stream.miGetString("Language/String")),
                Codec = CodecHelper.GetAudioCodecName(stream.codecCommonName, stream.codecId, stream.format),
                NumberOfChannels = stream.channels
            };
            return audio;
        }

        private IEnumerable<Video> GetVideoTracks(IDictionary<int, VideoStream> videoTracks)
        {
            foreach (var videoTrack in videoTracks)
            {
                yield return ConvertVideoStream(videoTrack.Value);
            }
        }

        private static Video ConvertVideoStream(VideoStream stream)
        {
            Video video = new Video
            {
                Aspect = stream.pixelAspectRatio.ToString(CultureInfo.InvariantCulture),
                Codec = CodecHelper.GetVideoCodecName(stream.codecCommonName, stream.codecId, stream.format),
                DurationInSeconds = stream.duration / 1000,
                Height = stream.height,
                LongLanguage = stream.miGetString("Language/String"),
                ScanType = stream.miGetString("ScanType"),
                Width = stream.width
            };
            video.Language = LanguageHelper.GetLanguageCode(video.LongLanguage);

            if (video.Aspect == "0")
            {
                video.Aspect = "Unknown";
            }
            return video;
        }

        private static IEnumerable<Subtitle> GetSubtitleTracks(IDictionary<int, TextStream> subtitleTracks)
        {
            foreach (var subtitleTrack in subtitleTracks)
            {
                yield return ConvertSubtitleStream(subtitleTrack.Value);
            }
        }

        private static Subtitle ConvertSubtitleStream(TextStream stream)
        {
            string longLanguage = stream.miGetString("Language/String");
            return new Subtitle
            {
                Language = LanguageHelper.GetLanguageCode(longLanguage)
            };
        }
    }
}
