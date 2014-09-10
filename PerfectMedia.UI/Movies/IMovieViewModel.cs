using System.ComponentModel;
using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Movies.Selection;

namespace PerfectMedia.UI.Movies
{
    public interface IMovieViewModel : IMovieItem
    {
        string Path { get; }
        string Id { get; }
        IPropertyViewModel<string> SetName { get; }
        IMovieSelectionViewModel Selection { get; }
        IPropertyViewModel<string> Title { get; }
    }
}
