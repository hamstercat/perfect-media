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
    public class SpecialsSeasonVisibilityConverterTests
    {
        private readonly SpecialsSeasonVisibilityConverter _converter;

        public SpecialsSeasonVisibilityConverterTests()
        {
            _converter = new SpecialsSeasonVisibilityConverter();
        }

        [Theory]
        [InlineData(0, Visibility.Visible)]
        [InlineData(1, Visibility.Collapsed)]
        [InlineData(42, Visibility.Collapsed)]
        public void Convert_SeasonNumber_ToVisibility(int seasonNumber, Visibility expectedVisibility)
        {
            // Act
            object result = _converter.Convert(seasonNumber, null, null, null);

            // Assert
            Assert.IsType<Visibility>(result);
            Assert.Equal(expectedVisibility, (Visibility)result);
        }
    }
}
