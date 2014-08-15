﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Images;

namespace PerfectMedia.UI.TvShows.Shows
{
    public class PosterImageStrategy : IImageStrategy
    {
        private readonly ITvShowMetadataService _metadataService;
        private readonly ITvShowMetadataViewModel _metadataViewModel;

        public PosterImageStrategy(ITvShowMetadataService metadataService, ITvShowMetadataViewModel metadataViewModel)
        {
            _metadataService = metadataService;
            _metadataViewModel = metadataViewModel;
        }

        public async Task<IEnumerable<Image>> FindImages()
        {
            AvailableTvShowImages images = await _metadataService.FindImages(_metadataViewModel.Id);
            IEnumerable<Image> allSeasonsImages = images.Seasons.SelectMany(s => s.Value.Posters);
            return images.Posters
                .Union(allSeasonsImages);
        }
    }
}
