using System.Collections.Generic;
using System.Threading.Tasks;
using PerfectMedia.Movies;
using PerfectMedia.UI.Images;

namespace PerfectMedia.UI.Movies.Set
{
    public class SetFanartImageStrategy : IImageStrategy
    {
        private readonly IMovieMetadataService _metadataService;
        private readonly IMovieSetViewModel _movieSet;

        public SetFanartImageStrategy(IMovieMetadataService metadataService, IMovieSetViewModel movieSet)
        {
            _metadataService = metadataService;
            _movieSet = movieSet;
        }

        public async Task<IEnumerable<Image>> FindImages()
        {
            AvailableMovieImages images = await _metadataService.FindSetImages(_movieSet.DisplayName);
            return images.Fanarts;
        }
    }
}
