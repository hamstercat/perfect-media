using System.Collections.Generic;
using System.Linq;
using PerfectMedia.Movies;
using PerfectMedia.UI.Images;

namespace PerfectMedia.UI.Movies
{
    public class PosterImageStrategy : IImageStrategy
    {
        private readonly IMovieMetadataService _metadataService;
        private readonly IMovieViewModel _movieViewModel;

        public PosterImageStrategy(IMovieMetadataService metadataService, IMovieViewModel movieViewModel)
        {
            _metadataService = metadataService;
            _movieViewModel = movieViewModel;
        }

        public IEnumerable<Image> FindImages()
        {
            if (!string.IsNullOrEmpty(_movieViewModel.Id))
            {
                AvailableMovieImages images = _metadataService.FindImages(_movieViewModel.Id);
                return images.Posters;
            }
            return Enumerable.Empty<Image>();
        }
    }
}
