using System.Collections.Generic;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Images;

namespace PerfectMedia.UI.TvShows.Shows
{
    public class FanartImageStrategy : IImageStrategy
    {
        private readonly ITvShowMetadataService _metadataService;
        private readonly ITvShowMetadataViewModel _metadataViewModel;

        public FanartImageStrategy(ITvShowMetadataService metadataService, ITvShowMetadataViewModel metadataViewModel)
        {
            _metadataService = metadataService;
            _metadataViewModel = metadataViewModel;
        }

        public IEnumerable<Image> FindImages()
        {
            AvailableTvShowImages images = _metadataService.FindImages(_metadataViewModel.Id);
            return images.Fanarts;
        }
    }
}
