using Xunit;
using Xunit.Extensions;

namespace PerfectMedia.FileInformation
{
    public class CodecHelperTests
    {
        [Theory]
        [InlineData("", "V_MPEG4/ISO/AVC", "AVC", "H264")]
        [InlineData("XviD", "XVID", "MPEG-4 Visual", "XVID")]
        [InlineData("DivX 5", "DX50", "MPEG-4 Visual", "DIVX")]
        [InlineData("", "avc1", "AVC", "AVC1")]
        [InlineData("DivX 3 Low", "DIV3", "MPEG-4 Visual", "DIVX")]
        [InlineData("XviD", "V_MS/VFW/FOURCC / XVID", "MPEG-4 Visual", "XVID")]
        public void GetVideoCodecName_KnownCodecs_DeterminesGoodCodec(string codecCommonName, string codecId, string format, string expectedCodec)
        {
            // Act
            string result = CodecHelper.GetVideoCodecName(codecCommonName, codecId, format);

            // Assert
            Assert.Equal(expectedCodec, result);
        }

        [Theory]
        [InlineData("", "A_AAC", "AAC", "AAC")]
        [InlineData("MP3", "55", "MPEG Audio", "MP3")]
        [InlineData("", "A_AC3", "AC-3", "AC3")]
        [InlineData("", "40", "AAC", "AAC")]
        [InlineData("", "A_FLAC", "FLAC", "FLAC")]
        [InlineData("", "A_VORBIS", "Vorbis", "VORBIS")]
        [InlineData("", "A_AAC/MPEG4/LC/SBR", "AAC", "AAC")]
        public void GetAudioCodecName_KnownCodecs_DeterminesGoodCodec(string codecCommonName, string codecId, string format, string expectedCodec)
        {
            // Act
            string result = CodecHelper.GetAudioCodecName(codecCommonName, codecId, format);

            // Assert
            Assert.Equal(expectedCodec, result);
        }
    }
}
