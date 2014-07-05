﻿using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Images;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.TvShows.Seasons
{
    [ImplementPropertyChanged]
    public class SeasonImagesViewModel
    {
        public ImageViewModel PosterUrl { get; private set; }
        public ImageViewModel BannerUrl { get; private set; }
        public int SeasonNumber { get; set; }

        public SeasonImagesViewModel(ITvShowMetadataService metadataService, string seasonPath)
        {
            PosterUrl = new ImageViewModel(new SeasonPosterImageStrategy(metadataService, seasonPath));
            BannerUrl = new ImageViewModel(new SeasonBannerImageStrategy(metadataService, seasonPath));
        }
    }
}
