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
            VideoFileInformation videoFileInformation = new VideoFileInformation { StreamDetails = new StreamDetails() };
            using (MediaFile mediaFile = new MediaFile(file))
            {
                videoFileInformation.StreamDetails.Audios = GetAudioTracks(mediaFile.Audio).ToList();
                videoFileInformation.StreamDetails.Videos = GetVideoTracks(mediaFile.Video).ToList();
            }
            return videoFileInformation;
        }

        private IEnumerable<Audio> GetAudioTracks(IDictionary<int, AudioStream> audioTracks)
        {
            foreach (var audioTrack in audioTracks)
            {
                AudioStream stream = audioTrack.Value;
                Audio audio = new Audio
                {
                    Language = LanguageHelper.GetLanguageCode(stream.miGetString("Language/String")),
                    Codec = CodecHelper.GetAudioCodecName(stream.codecCommonName, stream.codecId, stream.format),
                    NumberOfChannels = stream.channels
                };

                if (audio.Codec.ToUpper() == "AC-3")
                {
                    audio.Codec = "AC3";
                }
                yield return audio;
            }
        }

        private IEnumerable<Video> GetVideoTracks(IDictionary<int, VideoStream> videoTracks)
        {
            foreach (var videoTrack in videoTracks)
            {
                VideoStream stream = videoTrack.Value;
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
                yield return video;
            }
        }
    }
}
