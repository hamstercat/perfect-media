using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Windows.Data;
using PerfectMedia.Music.Artists;

namespace PerfectMedia.UI.Music.Artists.Selection
{
    public class TagListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tags = (IEnumerable<Tag>)value;
            if (tags != null)
            {
                var tagNames = tags.Select(t => t.Name);
                return string.Join(", ", tagNames);
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
