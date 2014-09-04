using System;
using System.Globalization;
using System.Windows.Data;

namespace PerfectMedia.UI.Converters
{
    public class RequiredLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value + " *";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
