using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;

namespace PerfectMedia.UI.Converters
{
    public class IsEmptyToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                ICollection collection = (ICollection)value;
                return collection.Count != 0;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
