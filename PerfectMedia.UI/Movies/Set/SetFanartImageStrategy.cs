using PerfectMedia.Movies;
using PerfectMedia.UI.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public IEnumerable<Image> FindImages()
        {
            return _metadataService.FindSetImages(_movieSet.DisplayName).Fanarts;
        }
    }
}
