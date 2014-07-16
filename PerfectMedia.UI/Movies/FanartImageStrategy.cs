using PerfectMedia.Movies;
using PerfectMedia.UI.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<Image> FindImages()
        {
            AvailableMovieImages images = _metadataService.FindImages(_movieViewModel.Id);
            return images.Fanarts;
        }
    }
}
