using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace PerfectMedia.FileInformation
{
    public class CodecHelperTests
    {
        [Theory]
        [InlineData("WMV3", "WMV3", "VC-1", "WMV3")]
        [InlineData("", "avc1", "AVC", "H264")]
        [InlineData("XviD", "XVID", "MPEG-4 Visual", "XVID")]
        [InlineData("", "V_MPEG4/ISO/AVC", "AVC", "H264")]
        public void GetVideoCodecName_KnownCodecs_DeterminesGoodCodec(string codecCommonName, string codecId, string format, string expectedCodec)
        {
            // Act
            string result = CodecHelper.GetVideoCodecName(codecCommonName, codecId, format);

            // Assert
            Assert.Equal(expectedCodec, result);
        }

        [Theory]
        [InlineData("", "A_AAC", "AAC", "AAC")]
        public void GetAudioCodecName_KnownCodecs_DeterminesGoodCodec(string codecCommonName, string codecId, string format, string expectedCodec)
        {
            // Act
            string result = CodecHelper.GetAudioCodecName(codecCommonName, codecId, format);

            // Assert
            Assert.Equal(expectedCodec, result);
        }
    }
}
