using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.ViewModels
{
    public class TvShowViewModel : BaseViewModel
    {
        public string Path { get; private set; }

        public TvShowViewModel(string path)
        {
            Path = path;
        }
    }
}
