using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PerfectMedia.UI.Converters
{
    public class ShowIfNotEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = (string)value;
            if (string.IsNullOrEmpty(str))
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
