﻿using PerfectMedia.UI.Progress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.TvShows.Seasons
{
    public interface ISeasonViewModel
    {
        IEnumerable<ProgressItem> FindNewEpisodes();
    }
}