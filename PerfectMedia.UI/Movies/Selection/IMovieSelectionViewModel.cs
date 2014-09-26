using System.Collections.Generic;
using PerfectMedia.Movies;
using PerfectMedia.UI.Selection;

namespace PerfectMedia.UI.Movies.Selection
{
    public interface IMovieSelectionViewModel : ISearchableSelectionViewModel<Movie>
    {
        void SetAvailableItems(IEnumerable<Movie> items);
    }
}
