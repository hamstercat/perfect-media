using Xunit;
using Xunit.Extensions;

namespace PerfectMedia.UI.Converters
{
    public class NotZeroConverterTests
    {
        private readonly NotZeroConverter _converter;

        public NotZeroConverterTests()
        {
            _converter = new NotZeroConverter();
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(56, true)]
        [InlineData(991, true)]
        public void Convert_IfDifferentThanZero_ReturnsTrue(int value, bool expectedResult)
        {
            // Act
            object result = _converter.Convert(value, null, null, null);

            // Assert
            Assert.IsType<bool>(result);
            Assert.Equal(expectedResult, (bool)result);
        }
    }
}
