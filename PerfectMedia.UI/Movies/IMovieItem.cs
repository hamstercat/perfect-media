using PerfectMedia.UI.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Movies
{
    public interface IMovieItem : IMetadataProvider
    {
        IEnumerable<IMovieViewModel> FindMovie(string path);
    }
}
