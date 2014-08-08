
namespace PerfectMedia.UI.Movies.Set
{
    public interface IMovieSetViewModel : IMovieItem
    {
        bool IsEmpty { get; }
        void AddMovie(IMovieViewModel movie);
        void RemoveMovie(IMovieViewModel movie);
    }
}
