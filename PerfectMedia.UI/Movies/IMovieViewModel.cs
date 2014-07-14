using PerfectMedia.UI.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.Movies
{
    public interface IMovieViewModel : IMetadataProvider
    {
        string Path { get; }
    }
}
