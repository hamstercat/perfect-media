using System;
using System.Globalization;
using System.Windows.Data;
using PerfectMedia.Music.Artists;

namespace PerfectMedia.UI.Music.Artists.Selection
{
    public class LifeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var lifeSpan = (LifeSpan)value;
            string begin = !string.IsNullOrEmpty(lifeSpan.Begin) ? lifeSpan.Begin : "???";
            string end = lifeSpan.Ended && !string.IsNullOrEmpty(lifeSpan.End) ? lifeSpan.End : MusicResources.Present;
            return string.Format("{0} - {1}", begin, end);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
