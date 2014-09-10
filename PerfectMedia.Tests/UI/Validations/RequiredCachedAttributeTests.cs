using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using PerfectMedia.UI.Cache;
using Xunit;
using Xunit.Extensions;

namespace PerfectMedia.UI.Validations
{
    public class RequiredCachedAttributeTests
    {
        private readonly RequiredCachedAttribute _attributes;

        public RequiredCachedAttributeTests()
        {
            _attributes = new RequiredCachedAttribute();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void IsValid_WhenCachePropertyDoesntHaveValue_ReturnsFalse(string value)
        {
            // Arrange
            var cachedProperty = Substitute.For<IPropertyViewModel<string>>();

            // Act
            bool isValid = _attributes.IsValid(cachedProperty);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValid_WhenCachePropertyHasValue_ReturnsTrue()
        {
            // Arrange
            var cachedProperty = Substitute.For<IPropertyViewModel<string>>();
            cachedProperty.Value
                .Returns("Dinosaur");

            // Act
            bool isValid = _attributes.IsValid(cachedProperty);

            // Assert
            Assert.True(isValid);
        }
    }
}
