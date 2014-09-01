using PerfectMedia.Music;
using PerfectMedia.Music.Artists;
using PerfectMedia.Sources;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Music.Artists;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.Sources;

namespace PerfectMedia.UI.Music
{
    public class MusicViewModelFactory : IMusicViewModelFactory
    {
        private readonly IArtistMetadataService _metadataService;
        private readonly ISourceService _sourceService;
        private readonly IFileSystemService _fileSystemService;
        private readonly IBusyProvider _busyProvider;
        private readonly IKeyDataStore _keyDataStore;
        private readonly IProgressManagerViewModel _progressManager;
        private readonly IDialogViewer _dialogViewer;

        public MusicViewModelFactory(IArtistMetadataService metadataService,
            ISourceService sourceService,
            IFileSystemService fileSystemService,
            IBusyProvider busyProvider,
            IKeyDataStore keyDataStore,
            IProgressManagerViewModel progressManager,
            IDialogViewer dialogViewer)
        {
            _metadataService = metadataService;
            _sourceService = sourceService;
            _fileSystemService = fileSystemService;
            _busyProvider = busyProvider;
            _keyDataStore = keyDataStore;
            _progressManager = progressManager;
            _dialogViewer = dialogViewer;
        }

        public ISourceManagerViewModel GetSourceManager()
        {
            return new SourceManagerViewModel(_sourceService, _fileSystemService, _busyProvider, SourceType.Music);
        }

        public IArtistViewModel GetArtistViewModel(string path)
        {
            return new ArtistViewModel(_metadataService, this, _progressManager, _busyProvider, _dialogViewer, path);
        }

        public ICachedPropertyViewModel<string> GetStringCachedProperty(string key, bool isRequired)
        {
            return new StringCachedPropertyViewModel(_keyDataStore, key, isRequired);
        }
    }
}