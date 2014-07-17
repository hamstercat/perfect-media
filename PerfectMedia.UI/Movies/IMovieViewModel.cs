using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Movies.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.Movies
{
    public interface IMovieViewModel : IMetadataProvider
    {
        string Path { get; }
        string Id { get; }
        IMovieSelectionViewModel Selection { get; }
    }
}
