using System.Collections.Generic;
using System.ComponentModel;
using PerfectMedia.Movies;

namespace PerfectMedia.UI.Movies.Selection
{
    public interface IMovieSelectionViewModel : INotifyPropertyChanged
    {
        string SearchTitle { get; set; }
        bool IsClosed { get; set; }
        object OriginalContent { get; set; }
        void ReplaceMovies(IEnumerable<Movie> movies);
    }
}
