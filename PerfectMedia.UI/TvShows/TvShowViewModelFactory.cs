using System;
using PerfectMedia.Sources;
using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Actors;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.Sources;
using PerfectMedia.UI.TvShows.Episodes;
using PerfectMedia.UI.TvShows.Seasons;
using PerfectMedia.UI.TvShows.Shows;
using PerfectMedia.UI.TvShows.ShowSelection;

namespace PerfectMedia.UI.TvShows
{
    public class TvShowViewModelFactory : ITvShowViewModelFactory
    {
        private readonly ISourceService _sourceService;
        private readonly IFileSystemService _fileSystemService;
        private readonly ITvShowFileService _tvShowFileService;
        private readonly ITvShowMetadataService _tvShowMetadataService;
        private readonly IEpisodeMetadataService _episodeMetadataService;
        private readonly IProgressManagerViewModel _progressManagerViewModel;
        private readonly IKeyDataStore _keyDataStore;
        private readonly IBusyProvider _busyProvider;
        private readonly IDialogViewer _dialogViewer;
        private readonly IActorViewModelFactory _actorViewModelFactory;

        public TvShowViewModelFactory(ISourceService sourceService,
            IFileSystemService fileSystemService,
            ITvShowFileService tvShowFileService,
            ITvShowMetadataService tvShowMetadataService,
            IEpisodeMetadataService episodeMetadataService,
            IProgressManagerViewModel progressManagerViewModel,
            IKeyDataStore keyDataStore,
            IBusyProvider busyProvider,
            IDialogViewer dialogViewer,
            IActorViewModelFactory actorViewModelFactory)
        {
            _sourceService = sourceService;
            _fileSystemService = fileSystemService;
            _tvShowFileService = tvShowFileService;
            _tvShowMetadataService = tvShowMetadataService;
            _episodeMetadataService = episodeMetadataService;
            _progressManagerViewModel = progressManagerViewModel;
            _keyDataStore = keyDataStore;
            _busyProvider = busyProvider;
            _dialogViewer = dialogViewer;
            _actorViewModelFactory = actorViewModelFactory;
        }

        public ISourceManagerViewModel GetSourceManager(SourceType sourceType)
        {
            return new SourceManagerViewModel(_sourceService, _fileSystemService, _busyProvider, sourceType);
        }

        public ITvShowViewModel GetTvShow(string path)
        {
            return new TvShowViewModel(this, _tvShowFileService, _tvShowMetadataService, _busyProvider, _dialogViewer, _progressManagerViewModel, path);
        }

        public ITvShowImagesViewModel GetTvShowImages(ITvShowViewModel metadataViewModel, string path)
        {
            return new TvShowImagesViewModel(_tvShowFileService, _tvShowMetadataService, _fileSystemService, metadataViewModel, _busyProvider, path);
        }

        public ISeasonViewModel GetSeason(ITvShowViewModel tvShowMetadata, string path)
        {
            return new SeasonViewModel(this, _tvShowFileService, tvShowMetadata, _tvShowMetadataService, _busyProvider, path);
        }

        public IEpisodeViewModel GetEpisode(ITvShowViewModel tvShowMetadata, string path)
        {
            return new EpisodeViewModel(this, _episodeMetadataService, tvShowMetadata, _progressManagerViewModel, _fileSystemService, _busyProvider, _dialogViewer, path);
        }

        public IImageViewModel GetImage(bool horizontalAlignement)
        {
            return new ImageViewModel(_fileSystemService, _busyProvider, horizontalAlignement);
        }

        public IImageViewModel GetImage(bool horizontalAlignement, IImageStrategy imageStrategy)
        {
            return new ImageViewModel(_fileSystemService, _busyProvider, horizontalAlignement, imageStrategy);
        }

        public ITvShowSelectionViewModel GetTvShowSelection(ITvShowViewModel tvShowMetadata, string path)
        {
            return new TvShowSelectionViewModel(_tvShowMetadataService, tvShowMetadata, _busyProvider, path);
        }

        public ICachedPropertyViewModel<string> GetStringCachedProperty(string key, bool isRequired)
        {
            return new StringCachedPropertyViewModel(_keyDataStore, key, isRequired);
        }

        public ICachedPropertyViewModel<int?> GetIntCachedProperty(string key, bool isRequired)
        {
            return new IntCachedPropertyViewModel(_keyDataStore, key, isRequired);
        }

        public IActorManagerViewModel GetActorManager()
        {
            return new ActorManagerViewModel(_actorViewModelFactory);
        }
    }
}
