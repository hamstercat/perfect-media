using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace PerfectMedia.UI.Converters
{
    public class PathFolderNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string fullDirectory = (string)value;
            if (!string.IsNullOrEmpty(fullDirectory))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(fullDirectory);
                return directoryInfo.Name;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
