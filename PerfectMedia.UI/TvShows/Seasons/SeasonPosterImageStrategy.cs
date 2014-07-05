using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.TvShows.Seasons
{
    public class SeasonPosterImageStrategy : IImageStrategy
    {
        private readonly ITvShowMetadataService _metadataService;
        private readonly string _seasonPath;

        public SeasonPosterImageStrategy(ITvShowMetadataService metadataService, string seasonPath)
        {
            _metadataService = metadataService;
            _seasonPath = seasonPath;
        }

        public IEnumerable<Image> FindImages()
        {
            AvailableSeasonImages images = _metadataService.FindSeasonImages(_seasonPath);
            return images.Posters;
        }
    }
}
