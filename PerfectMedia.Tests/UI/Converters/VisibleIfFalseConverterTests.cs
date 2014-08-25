using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xunit;

namespace PerfectMedia.UI.Converters
{
    public class VisibleIfFalseConverterTests
    {
        private readonly VisibleIfFalseConverter _converter;

        public VisibleIfFalseConverterTests()
        {
            _converter = new VisibleIfFalseConverter();
        }

        [Fact]
        public void Convert_False_ReturnsVisible()
        {
            // Act
            Visibility visibility = (Visibility)_converter.Convert(false, null, null, null);

            // Assert
            Assert.Equal(Visibility.Visible, visibility);
        }

        [Fact]
        public void Convert_True_ReturnsCollapsed()
        {
            // Act
            Visibility visibility = (Visibility)_converter.Convert(true, null, null, null);

            // Assert
            Assert.Equal(Visibility.Collapsed, visibility);
        }
    }
}
