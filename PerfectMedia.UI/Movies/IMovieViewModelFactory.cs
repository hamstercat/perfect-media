﻿using PerfectMedia.Sources;
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
    }
}
