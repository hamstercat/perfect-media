using PerfectMedia.Movies;
using PerfectMedia.Sources;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Movies
{
    public class MovieViewModelFactory : IMovieViewModelFactory
    {
        private readonly ISourceService _sourceService;
        private readonly IFileSystemService _fileSystemService;
        private readonly IMovieMetadataService _metadataService;
        private readonly IProgressManagerViewModel _progressManager;

        public MovieViewModelFactory(ISourceService sourceService,
            IMovieMetadataService metadataService,
            IFileSystemService fileSystemService,
            IProgressManagerViewModel progressManager)
        {
            _sourceService = sourceService;
            _fileSystemService = fileSystemService;
            _metadataService = metadataService;
            _progressManager = progressManager;
        }

        public ISourceManagerViewModel GetSourceManager()
        {
            return new SourceManagerViewModel(_sourceService, _fileSystemService, SourceType.Movie);
        }

        public IMovieViewModel GetMovie(string path)
        {
            return new MovieViewModel(_metadataService, this, _progressManager, path);
        }

        public IImageViewModel GetImage()
        {
            return new ImageViewModel(_fileSystemService);
        }

        public IImageViewModel GetImage(IImageStrategy imageStrategy)
        {
            return new ImageViewModel(_fileSystemService, imageStrategy);
        }
    }
}
