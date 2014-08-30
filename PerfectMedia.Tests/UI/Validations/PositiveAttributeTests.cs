using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace PerfectMedia.UI.Validations
{
    public class PositiveAttributeTests
    {
        private readonly PositiveAttribute _attributes;

        public PositiveAttributeTests()
        {
            _attributes = new PositiveAttribute();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-54)]
        [InlineData(-9846485)]
        public void IsValid_NegativeValues_ReturnsFalse(int i)
        {
            // Act
            bool isValid = _attributes.IsValid(i);

            // Assert
            Assert.False(isValid);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void IsValid_PositiveValuesOrZero_ReturnsTrue(int i)
        {
            // Act
            bool isValid = _attributes.IsValid(i);

            // Assert
            Assert.True(isValid);
        }
    }
}
