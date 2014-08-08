using System;
using Xunit;

namespace PerfectMedia.UI.Converters
{
    public class NullToBooleanConverterTests
    {
        private readonly NullToBooleanConverter _converter;

        public NullToBooleanConverterTests()
        {
            _converter = new NullToBooleanConverter();
        }

        [Fact]
        public void Convert_Null_ReturnsFalse()
        {
            // Act
            object result = _converter.Convert(null, null, null, null);

            // Assert
            Assert.IsType<bool>(result);
            Assert.False((bool)result);
        }

        [Fact]
        public void Convert_Object_ReturnsTrue()
        {
            // Arrange
            object o = new object();

            // Act
            object result = _converter.Convert(o, null, null, null);

            // Assert
            Assert.IsType<bool>(result);
            Assert.True((bool)result);
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
