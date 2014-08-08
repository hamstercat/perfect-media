using System.Collections.Generic;
using System.Collections.ObjectModel;
using PerfectMedia.UI.Metadata;

namespace PerfectMedia.UI.Movies
{
    public interface IMovieItem : IMetadataProvider
    {
        IEnumerable<IMovieViewModel> FindMovie(string path);
        string DisplayName { get; }
        ObservableCollection<IMovieViewModel> Children { get; }
    }
}
