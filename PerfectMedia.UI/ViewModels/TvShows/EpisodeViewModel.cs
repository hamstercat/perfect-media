using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.ViewModels.TvShows
{
    class EpisodeViewModel
    {
        public string Path { get; private set; }

        public EpisodeViewModel(string path)
        {
            Path = path;
        }
    }
}
