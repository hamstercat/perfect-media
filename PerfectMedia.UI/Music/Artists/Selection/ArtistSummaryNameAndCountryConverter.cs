using System;
using System.Globalization;
using System.Windows.Data;
using PerfectMedia.Music.Artists;

namespace PerfectMedia.UI.Music.Artists.Selection
{
    public class ArtistSummaryNameAndCountryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var artist = (ArtistSummary)value;
            if (!string.IsNullOrEmpty(artist.ArtistType))
            {
                return string.Format("{0} ({1})", artist.Name, artist.Country);
            }
            return artist.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
