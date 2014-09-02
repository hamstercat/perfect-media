﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Images;

namespace PerfectMedia.UI.TvShows.Shows
{
    public class BannerImageStrategy : IImageStrategy
    {
        private readonly ITvShowMetadataService _metadataService;
        private readonly ITvShowViewModel _metadataViewModel;

        public BannerImageStrategy(ITvShowMetadataService metadataService, ITvShowViewModel metadataViewModel)
        {
            _metadataService = metadataService;
            _metadataViewModel = metadataViewModel;
        }

        public async Task<IEnumerable<Image>> FindImages()
        {
            if (!string.IsNullOrEmpty(_metadataViewModel.Id))
            {
                AvailableTvShowImages images = await _metadataService.FindImages(_metadataViewModel.Id);
                IEnumerable<Image> allSeasonsImages = images.Seasons.SelectMany(s => s.Value.Banners);
                return images.Banners
                    .Union(allSeasonsImages);
            }
            return Enumerable.Empty<Image>();
        }
    }
}
