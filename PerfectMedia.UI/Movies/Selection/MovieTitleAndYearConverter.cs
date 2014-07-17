using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;
using PerfectMedia.Movies;

namespace PerfectMedia.UI.Movies.Selection
{
    public class MovieTitleAndYearConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Movie movie = (Movie)value;
            if (movie != null)
            {
                return GetMovieName(movie);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private object GetMovieName(Movie movie)
        {
            if (!movie.ReleaseDate.HasValue)
            {
                return movie.Title;
            }
            return string.Format("{0} ({1})", movie.Title, movie.ReleaseDate.Value.Year);
        }
    }
}
