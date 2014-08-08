using System;
using Xunit;
using Xunit.Extensions;

namespace PerfectMedia
{
    public class NfoRepositoryTests
    {
        [Fact]
        public void GetStringFromDateTime_DateTimeIsNull_ReturnsNull()
        {
            // Act
            string result = NfoRepository.GetStringFromDateTime(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetStringFromDateTime_DateTimeIsNotNull_ReturnsXmlStringRepresentation()
        {
            // Arrange
            DateTime dateTime = new DateTime(2014, 5, 27);

            // Act
            string result = NfoRepository.GetStringFromDateTime(dateTime);

            // Assert
            Assert.Equal("2014-05-27", result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GetDateTimeFromString_StringIsNullOrEmpty_ReturnsNull(string str)
        {
            // Act
            DateTime? result = NfoRepository.GetDateTimeFromString(str);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetDateTimeFromString_StringContainsDate_ParsesAndReturnsIt()
        {
            // Act
            DateTime? result = NfoRepository.GetDateTimeFromString("2014-05-27");

            // Assert
            DateTime expectedDateTime = new DateTime(2014, 5, 27);
            Assert.Equal(expectedDateTime, result);
        }
    }
}
