using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace PerfectMedia.UI.Validations
{
    public class LocalizedRequiredAttributeTests
    {
        private readonly LocalizedRequiredAttribute _attribute;

        public LocalizedRequiredAttributeTests()
        {
            _attribute = new LocalizedRequiredAttribute();
        }

        [Theory]
        [InlineData("")]
        [InlineData((string)null)]
        [InlineData(null)]
        public void IsValid_WithEmptyValue_ReturnsFalse(object obj)
        {
            // Act
            bool isValid = _attribute.IsValid(obj);

            // Assert
            Assert.False(isValid);
        }

        [Theory]
        [InlineData("Something")]
        [InlineData(42)]
        [InlineData(-98.5)]
        public void IsValid_WithValue_ReturnsTrue(object obj)
        {
            // Act
            bool isValid = _attribute.IsValid(obj);

            // Assert
            Assert.True(isValid);
        }
    }
}
