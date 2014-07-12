using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;
using PerfectMedia.TvShows.Metadata;

namespace PerfectMedia.UI.TvShows.ShowSelection
{
    public class SeriesNameAndYearConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Series series = (Series)value;
            if (series != null)
            {
                return GetSeriesName(series);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private object GetSeriesName(Series series)
        {
            if (!series.FirstAired.HasValue)
            {
                return series.SeriesName;
            }
            return string.Format("{0} ({1})", series.SeriesName, series.FirstAired.Value.Year);
        }
    }
}
