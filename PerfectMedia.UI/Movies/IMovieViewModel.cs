using System.ComponentModel;
using PerfectMedia.UI.Movies.Selection;

namespace PerfectMedia.UI.Movies
{
    public interface IMovieViewModel : IMovieItem, INotifyPropertyChanged
    {
        string Path { get; }
        string Id { get; }
        ICachedPropertyViewModel<string> SetName { get; }
        IMovieSelectionViewModel Selection { get; }
        ICachedPropertyViewModel<string> Title { get; }
    }
}
