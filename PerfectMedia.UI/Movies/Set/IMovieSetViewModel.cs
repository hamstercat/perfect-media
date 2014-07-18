using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.Movies.Set
{
    public interface IMovieSetViewModel : IMovieItem
    {
        string DisplayName { get; }
        bool IsEmpty { get; }
        void AddMovie(IMovieViewModel movie);
        void RemoveMovie(IMovieViewModel movie);
    }
}
