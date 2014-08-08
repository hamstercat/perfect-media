using System.Collections.Generic;
using PerfectMedia.Movies;
using PerfectMedia.UI.Images;

namespace PerfectMedia.UI.Movies.Set
{
    public class SetPosterImageStrategy : IImageStrategy
    {
        private readonly IMovieMetadataService _metadataService;
        private readonly IMovieSetViewModel _movieSet;

        public SetPosterImageStrategy(IMovieMetadataService metadataService, IMovieSetViewModel movieSet)
        {
            _metadataService = metadataService;
            _movieSet = movieSet;
        }

        public IEnumerable<Image> FindImages()
        {
            return _metadataService.FindSetImages(_movieSet.DisplayName).Posters;
        }
    }
}
