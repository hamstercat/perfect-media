﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Images;

namespace PerfectMedia.UI.TvShows.Seasons
{
    public class SeasonBannerImageStrategy : IImageStrategy
    {
        private readonly ITvShowMetadataService _metadataService;
        private readonly string _tvShowPath;
        private readonly string _seasonPath;

        public SeasonBannerImageStrategy(ITvShowMetadataService metadataService, string tvShowPath, string seasonPath)
        {
            _metadataService = metadataService;
            _tvShowPath = tvShowPath;
            _seasonPath = seasonPath;
        }

        public async Task<IEnumerable<Image>> FindImages()
        {
            AvailableSeasonImages seasonImages = await _metadataService.FindSeasonImages(_seasonPath);
            AvailableTvShowImages images = _metadataService.FindImagesFromPath(_tvShowPath);
            IEnumerable<Image> allSeasonsImages = images.Seasons.SelectMany(s => s.Value.Banners);
            return seasonImages.Banners
                .Union(images.Banners)
                .Union(allSeasonsImages);
        }
    }
}
