using PerfectMedia.UI.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xunit;
using Xunit.Extensions;

namespace PerfectMedia.Tests.UI.Converters
{
    public class ShowIfNotEmptyConverterTests
    {
        private readonly ShowIfNotEmptyConverter _converter;

        public ShowIfNotEmptyConverterTests()
        {
            _converter = new ShowIfNotEmptyConverter();
        }

        [Theory]
        [InlineData("", Visibility.Collapsed)]
        [InlineData(null, Visibility.Collapsed)]
        [InlineData("something", Visibility.Visible)]
        [InlineData("a", Visibility.Visible)]
        public void Convert_SeasonNumber_ToVisibility(string str, Visibility expectedVisibility)
        {
            // Act
            object result = _converter.Convert(str, null, null, null);

            // Assert
            Assert.IsType<Visibility>(result);
            Assert.Equal(expectedVisibility, (Visibility)result);
        }
    }
}
