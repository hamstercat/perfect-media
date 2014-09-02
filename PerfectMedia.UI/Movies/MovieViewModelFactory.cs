using System;
using PerfectMedia.Movies;
using PerfectMedia.Sources;
using PerfectMedia.UI.Actors;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Cache;
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
        private readonly IBusyProvider _busyProvider;
        private readonly IDialogViewer _dialogViewer;
        private readonly IActorViewModelFactory _actorViewModelFactory;

        public MovieViewModelFactory(ISourceService sourceService,
            IMovieMetadataService metadataService,
            IFileSystemService fileSystemService,
            IProgressManagerViewModel progressManager,
            IKeyDataStore keyDataStore,
            IBusyProvider busyProvider,
            IDialogViewer dialogViewer,
            IActorViewModelFactory actorViewModelFactory)
        {
            _sourceService = sourceService;
            _fileSystemService = fileSystemService;
            _metadataService = metadataService;
            _progressManager = progressManager;
            _keyDataStore = keyDataStore;
            _busyProvider = busyProvider;
            _dialogViewer = dialogViewer;
            _actorViewModelFactory = actorViewModelFactory;
        }

        public ISourceManagerViewModel GetSourceManager()
        {
            return new SourceManagerViewModel(_sourceService, _fileSystemService, _busyProvider, SourceType.Movie);
        }

        public IMovieViewModel GetMovie(string path)
        {
            return new MovieViewModel(_metadataService, this, _fileSystemService, _progressManager, _busyProvider, _dialogViewer, path);
        }

        public IImageViewModel GetImage()
        {
            return new ImageViewModel(_fileSystemService, _busyProvider, true);
        }

        public IImageViewModel GetImage(IImageStrategy imageStrategy)
        {
            return new ImageViewModel(_fileSystemService, _busyProvider, true, imageStrategy);
        }

        public IMovieSelectionViewModel GetSelection(IMovieViewModel movieViewModel)
        {
            return new MovieSelectionViewModel(_metadataService, movieViewModel, _busyProvider);
        }

        public IMovieSetViewModel GetMovieSet(string setName)
        {
            return new MovieSetViewModel(_fileSystemService, this, _metadataService, _progressManager, _busyProvider, _dialogViewer, setName);
        }

        public ICachedPropertyViewModel<string> GetStringCachedProperty(string key, bool isRequired)
        {
            return new StringCachedPropertyViewModel(_keyDataStore, key, isRequired);
        }

        public IActorManagerViewModel GetActorManager()
        {
            return new ActorManagerViewModel(_actorViewModelFactory);
        }
    }
}
