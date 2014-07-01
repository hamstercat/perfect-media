using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.TvShows.Shows
{
    public interface ITvShowMetadataViewModel
    {
        string Id { get; }
        string Path { get; }
        void Update();
    }
}
