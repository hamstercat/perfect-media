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
        private readonly string _tvShowPath;
        private readonly string _seasonPath;

        public SeasonPosterImageStrategy(ITvShowMetadataService metadataService, string tvShowPath, string seasonPath)
        {
            _metadataService = metadataService;
            _tvShowPath = tvShowPath;
            _seasonPath = seasonPath;
        }

        public IEnumerable<Image> FindImages()
        {
            AvailableSeasonImages seasonImages = _metadataService.FindSeasonImages(_seasonPath);
            AvailableTvShowImages images = _metadataService.FindImagesFromPath(_tvShowPath);
            IEnumerable<Image> allSeasonsImages = images.Seasons.SelectMany(s => s.Value.Posters);
            return seasonImages.Posters
                .Union(images.Posters)
                .Union(allSeasonsImages);
        }
    }
}
