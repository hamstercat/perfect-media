using System.Collections.Generic;
using System.Threading.Tasks;
using PerfectMedia.Music;
using PerfectMedia.Music.Albums;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Selection;
using PropertyChanged;

namespace PerfectMedia.UI.Music.Albums.Selection
{
    [ImplementPropertyChanged]
    public class AlbumSelectionViewModel : SearchableSelectionViewModel<ReleaseGroup>, IAlbumSelectionViewModel
    {
        private const int DefaultPageSize = 100;
        private readonly IAlbumMetadataService _metadataService;
        private readonly IMusicImageService _imageService;
        private readonly IAlbumViewModel _albumViewModel;

        public AlbumSelectionViewModel(IAlbumMetadataService metadataService,
            IMusicImageService imageService,
            IBusyProvider busyProvider,
            IAlbumViewModel albumViewModel)
            : base(busyProvider, albumViewModel.Title.OriginalValue)
        {
            _metadataService = metadataService;
            _imageService = imageService;
            _albumViewModel = albumViewModel;
        }

        protected override async Task SaveInternal(ReleaseGroup selectedItem)
        {
            await SaveNewId(selectedItem.Id, _albumViewModel.Path);
            await Update(_albumViewModel.Path);
        }

        protected override Task<IEnumerable<ReleaseGroup>> SearchInternal(string searchTitle)
        {
            return _metadataService.FindAlbums(searchTitle, DefaultPageSize, 0);
        }

        private async Task SaveNewId(string id, string path)
        {
            AlbumMetadata metadata = await _metadataService.Get(path);
            metadata.Mbid = id;
            await _metadataService.Save(path, metadata);
        }

        private async Task Update(string path)
        {
            await _imageService.DeleteArtist(path);
            await _metadataService.Update(path, _albumViewModel.ArtistId);
            await _albumViewModel.Refresh();
        }
    }
}
