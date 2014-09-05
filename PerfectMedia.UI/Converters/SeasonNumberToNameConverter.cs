using System;
using System.Globalization;
using System.Windows.Data;
using PerfectMedia.UI.TvShows;

namespace PerfectMedia.UI.Converters
{
    public class SeasonNumberToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int seasonNumber = (int)value;
            if (seasonNumber == 0)
            {
                return TvShowResources.Specials;
            }
            return string.Format("{0} {1}", TvShowResources.Season, seasonNumber);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
