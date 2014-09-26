using System;
using System.Globalization;
using System.Windows.Data;
using PerfectMedia.Music.Albums;

namespace PerfectMedia.UI.Music.Albums.Selection
{
    public class AlbumTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO: when secondary types are supported, show them here too
            var album = (ReleaseGroup)value;
            if (string.IsNullOrEmpty(album.PrimaryType))
            {
                return string.Format("{0} ({1})", album.Type, album.PrimaryType);
            }
            return album.Type;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
