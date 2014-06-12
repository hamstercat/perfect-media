using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.ViewModels
{
    public class SeasonViewModel : BaseViewModel
    {
        public string Path { get; private set; }

        public SeasonViewModel(string path)
        {
            Path = path;
        }
    }
}
