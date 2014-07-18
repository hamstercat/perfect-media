using PerfectMedia.Sources;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Movies.Selection;
using PerfectMedia.UI.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
