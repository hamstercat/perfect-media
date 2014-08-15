using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectMedia.Movies;
using PerfectMedia.UI.Images;

namespace PerfectMedia.UI.Movies
{
    public class FanartImageStrategy : IImageStrategy
    {
        private readonly IMovieMetadataService _metadataService;
        private readonly IMovieViewModel _movieViewModel;

        public FanartImageStrategy(IMovieMetadataService metadataService, IMovieViewModel movieViewModel)
        {
            _metadataService = metadataService;
            _movieViewModel = movieViewModel;
        }

        public async Task<IEnumerable<Image>> FindImages()
        {
            if (!string.IsNullOrEmpty(_movieViewModel.Id))
            {
                AvailableMovieImages images = await _metadataService.FindImages(_movieViewModel.Id);
                return images.Fanarts;
            }
            return Enumerable.Empty<Image>();
        }
    }
}
