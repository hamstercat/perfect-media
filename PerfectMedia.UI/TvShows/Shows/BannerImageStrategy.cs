using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.TvShows.Shows
{
    public class BannerImageStrategy : IImageStrategy
    {
        private readonly ITvShowMetadataService _metadataService;
        private readonly ITvShowMetadataViewModel _metadataViewModel;

        public BannerImageStrategy(ITvShowMetadataService metadataService, ITvShowMetadataViewModel metadataViewModel)
        {
            _metadataService = metadataService;
            _metadataViewModel = metadataViewModel;
        }

        public IEnumerable<Image> FindImages()
        {
            AvailableTvShowImages images = _metadataService.FindImages(_metadataViewModel.Id);
            return images.Banners;
        }
    }
}
