using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace PerfectMedia.UI.Validations
{
    public class RatingAttributeTests
    {
        private readonly RatingAttribute _attributes;

        public RatingAttributeTests()
        {
            _attributes = new RatingAttribute();
        }

        [Theory]
        [InlineData(0d)]
        [InlineData(0.1d)]
        [InlineData(5d)]
        [InlineData(7.8d)]
        [InlineData(10d)]
        [InlineData(null)]
        public void IsValid_ValidRatings_ReturnsTrue(double? rating)
        {
            // Act
            bool isValid = _attributes.IsValid(rating);

            // Arrange
            Assert.True(isValid);
        }

        [Theory]
        [InlineData(-1d)]
        [InlineData(-0.1d)]
        [InlineData(-65d)]
        [InlineData(10.1d)]
        [InlineData(67d)]
        public void IsValid_InvalidRatings_ReturnsFalse(double rating)
        {
            // Act
            bool isValid = _attributes.IsValid(rating);

            // Arrange
            Assert.False(isValid);
        }
    }
}
