using PerfectMedia.Music;
using PerfectMedia.Music.Albums;
using PerfectMedia.Music.Artists;
using PerfectMedia.Sources;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Music.Albums;
using PerfectMedia.UI.Music.Albums.Selection;
using PerfectMedia.UI.Music.Artists;
using PerfectMedia.UI.Music.Artists.Selection;
using PerfectMedia.UI.Music.Tracks;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.Sources;

namespace PerfectMedia.UI.Music
{
    public class MusicViewModelFactory : IMusicViewModelFactory
    {
        private readonly IArtistMetadataService _artistMetadataService;
        private readonly IAlbumMetadataService _albumMetadataService;
        private readonly ISourceService _sourceService;
        private readonly IFileSystemService _fileSystemService;
        private readonly IMusicFileService _musicFileService;
        private readonly IMusicImageService _imageService;
        private readonly IMusicImageUpdater _imageUpdater;
        private readonly IBusyProvider _busyProvider;
        private readonly IKeyDataStore _keyDataStore;
        private readonly IProgressManagerViewModel _progressManager;
        private readonly IDialogViewer _dialogViewer;

        public MusicViewModelFactory(IArtistMetadataService artistMetadataService,
            IAlbumMetadataService albumMetadataService,
            ISourceService sourceService,
            IFileSystemService fileSystemService,
            IMusicFileService musicFileService,
            IMusicImageService imageService,
            IMusicImageUpdater imageUpdater,
            IBusyProvider busyProvider,
            IKeyDataStore keyDataStore,
            IProgressManagerViewModel progressManager,
            IDialogViewer dialogViewer)
        {
            _artistMetadataService = artistMetadataService;
            _albumMetadataService = albumMetadataService;
            _sourceService = sourceService;
            _fileSystemService = fileSystemService;
            _musicFileService = musicFileService;
            _imageService = imageService;
            _imageUpdater = imageUpdater;
            _busyProvider = busyProvider;
            _keyDataStore = keyDataStore;
            _progressManager = progressManager;
            _dialogViewer = dialogViewer;
        }

        public ISourceManagerViewModel GetSourceManager()
        {
            return new SourceManagerViewModel(_sourceService, _fileSystemService, _busyProvider, SourceType.Music);
        }

        public IArtistViewModel GetArtist(string path)
        {
            return new ArtistViewModel(_artistMetadataService, this, _musicFileService, _imageUpdater, _progressManager, _busyProvider, _dialogViewer, _keyDataStore, path);
        }

        public IAlbumViewModel GetAlbum(string path, IArtistViewModel artistViewModel)
        {
            return new AlbumViewModel(_musicFileService, _albumMetadataService, _imageUpdater, this, _busyProvider, _dialogViewer, _progressManager, _keyDataStore, artistViewModel, path);
        }

        public ITrackViewModel GetTrack(string path)
        {
            return new TrackViewModel(_busyProvider, _dialogViewer, path);
        }

        public IImageViewModel GetImage(bool horizontalAlignement)
        {
            return new ImageViewModel(_fileSystemService, _busyProvider, horizontalAlignement);
        }

        public IImageViewModel GetImage(bool horizontalAlignement, IImageStrategy imageStrategy)
        {
            return new ImageViewModel(_fileSystemService, _busyProvider, horizontalAlignement, imageStrategy);
        }

        public IArtistSelectionViewModel GetArtistSelection(IArtistViewModel artistViewModel)
        {
            return new ArtistSelectionViewModel(_artistMetadataService, _imageService, _busyProvider, artistViewModel);
        }

        public IAlbumSelectionViewModel GetAlbumSelection(IAlbumViewModel albumViewModel)
        {
            return new AlbumSelectionViewModel(_albumMetadataService, _imageService, _busyProvider, albumViewModel);
        }
    }
}