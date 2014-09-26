using System;
using System.Globalization;
using System.Windows.Data;
using PerfectMedia.Music.Albums;

namespace PerfectMedia.UI.Music.Albums.Selection
{
    public class AlbumTitleAndYearConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var album = (ReleaseGroup)value;
            if (album.Year.HasValue)
            {
                return string.Format("{0} ({1})", album.Title, album.Year);
            }
            return album.Title;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
