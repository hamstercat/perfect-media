using System.ComponentModel;
using PerfectMedia.UI.Movies.Selection;

namespace PerfectMedia.UI.Movies
{
    public interface IMovieViewModel : IMovieItem, INotifyPropertyChanged
    {
        string Path { get; }
        string Id { get; }
        string SetName { get; set; }
        IMovieSelectionViewModel Selection { get; }
    }
}
