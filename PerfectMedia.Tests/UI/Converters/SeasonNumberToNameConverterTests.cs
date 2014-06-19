using PerfectMedia.UI.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace PerfectMedia.Tests.UI.Converters
{
    public class SeasonNumberToNameConverterTests
    {
        private readonly SeasonNumberToNameConverter _converter;

        public SeasonNumberToNameConverterTests()
        {
            _converter = new SeasonNumberToNameConverter();
        }

        [Theory]
        [InlineData(0, "Specials")]
        [InlineData(1, "Season 1")]
        [InlineData(9, "Season 9")]
        [InlineData(42, "Season 42")]
        public void Convert_SeasonNumber_ReturnsSeasonName(int seasonNumber, string seasonName)
        {
            // Act
            object result = _converter.Convert(seasonNumber, null, null, null);

            // Assert
            Assert.IsType<string>(result);
            Assert.Equal(seasonName, (string)result);
        }

        [Fact]
        public void ConvertBack_Always_ThrowsNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                // Act
                _converter.ConvertBack(null, null, null, null);
            });
        }
    }
}
