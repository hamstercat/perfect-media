using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PerfectMedia.UI.Converters
{
    public class SpecialsSeasonVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int seasonNumber = (int)value;
            if (seasonNumber == 0)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
