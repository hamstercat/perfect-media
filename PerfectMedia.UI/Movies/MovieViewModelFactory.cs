using System;
using PerfectMedia.Movies;
using PerfectMedia.Sources;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Movies.Selection;
using PerfectMedia.UI.Movies.Set;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.Sources;

namespace PerfectMedia.UI.Movies
{
    public class MovieViewModelFactory : IMovieViewModelFactory
    {
        private readonly ISourceService _sourceService;
        private readonly IFileSystemService _fileSystemService;
        private readonly IMovieMetadataService _metadataService;
        private readonly IProgressManagerViewModel _progressManager;
        private readonly IKeyDataStore _keyDataStore;

        public MovieViewModelFactory(ISourceService sourceService,
            IMovieMetadataService metadataService,
            IFileSystemService fileSystemService,
            IProgressManagerViewModel progressManager,
            IKeyDataStore keyDataStore)
        {
            _sourceService = sourceService;
            _fileSystemService = fileSystemService;
            _metadataService = metadataService;
            _progressManager = progressManager;
            _keyDataStore = keyDataStore;
        }

        public ISourceManagerViewModel GetSourceManager()
        {
            return new SourceManagerViewModel(_sourceService, _fileSystemService, SourceType.Movie);
        }

        public IMovieViewModel GetMovie(string path)
        {
            return new MovieViewModel(_metadataService, this, _fileSystemService, _progressManager, path);
        }

        public IImageViewModel GetImage()
        {
            return new ImageViewModel(_fileSystemService, true);
        }

        public IImageViewModel GetImage(IImageStrategy imageStrategy)
        {
            return new ImageViewModel(_fileSystemService, true, imageStrategy);
        }

        public IMovieSelectionViewModel GetSelection(IMovieViewModel movieViewModel)
        {
            return new MovieSelectionViewModel(_metadataService, movieViewModel);
        }

        public IMovieSetViewModel GetMovieSet(string setName)
        {
            return new MovieSetViewModel(_fileSystemService, this, _metadataService, _progressManager, setName);
        }

        public ICachedPropertyViewModel<T> GetCachedProperty<T>(string key, Func<T, string> converter, Func<string, T> otherConverter)
        {
            return new CachedPropertyViewModel<T>(_keyDataStore, key, converter, otherConverter);
        }
    }
}
