using PerfectMedia.UI.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.Tests.UI.Converters
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
    }
}
