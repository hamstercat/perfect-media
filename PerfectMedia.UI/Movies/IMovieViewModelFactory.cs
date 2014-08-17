using System;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Movies.Selection;
using PerfectMedia.UI.Movies.Set;
using PerfectMedia.UI.Sources;

namespace PerfectMedia.UI.Movies
{
    public interface IMovieViewModelFactory
    {
        ISourceManagerViewModel GetSourceManager();
        IMovieViewModel GetMovie(string path);
        IImageViewModel GetImage();
        IImageViewModel GetImage(IImageStrategy imageStrategy);
        IMovieSelectionViewModel GetSelection(IMovieViewModel movieViewModel);
        IMovieSetViewModel GetMovieSet(string setName);
        ICachedPropertyViewModel<T> GetCachedProperty<T>(string key, Func<T, string> converter, Func<string, T> otherConverter);
    }
}
