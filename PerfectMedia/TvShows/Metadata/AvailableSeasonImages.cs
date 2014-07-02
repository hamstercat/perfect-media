﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.TvShows.Metadata
{
    public class AvailableSeasonImages
    {
        public List<Image> Posters { get; set; }
        public List<Image> Banners { get; set; }

        public AvailableSeasonImages()
        {
            Posters = new List<Image>();
            Banners = new List<Image>();
        }
    }
}
