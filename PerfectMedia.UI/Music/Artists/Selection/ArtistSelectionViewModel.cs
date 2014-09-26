using System.Collections.Generic;
using System.Threading.Tasks;
using PerfectMedia.Music;
using PerfectMedia.Music.Artists;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Selection;
using PropertyChanged;

namespace PerfectMedia.UI.Music.Artists.Selection
{
    [ImplementPropertyChanged]
    public class ArtistSelectionViewModel : SearchableSelectionViewModel<ArtistSummary>, IArtistSelectionViewModel
    {
        private const int DefaultPageSize = 100;
        private readonly IArtistViewModel _artistViewModel;
        private readonly IArtistMetadataService _metadataService;
        private readonly IMusicImageService _imageService;

        public ArtistSelectionViewModel(IArtistMetadataService metadataService,
            IMusicImageService imageService,
            IBusyProvider busyProvider,
            IArtistViewModel artistViewModel)
            : base(busyProvider, artistViewModel.Name.OriginalValue)
        {
            _metadataService = metadataService;
            _imageService = imageService;
            _artistViewModel = artistViewModel;
        }

        protected override async Task SaveInternal(ArtistSummary selectedItem)
        {
            await SaveNewId(selectedItem.Id, _artistViewModel.Path);
            await Update(_artistViewModel.Path);
        }

        protected override Task<IEnumerable<ArtistSummary>> SearchInternal(string searchTitle)
        {
            return _metadataService.FindArtists(searchTitle, DefaultPageSize, 0);
        }

        private async Task SaveNewId(string id, string path)
        {
            ArtistMetadata metadata = await _metadataService.Get(path);
            metadata.Mbid = id;
            await _metadataService.Save(path, metadata);
        }

        private async Task Update(string path)
        {
            await _imageService.DeleteArtist(path);
            await _metadataService.Update(path);
            await _artistViewModel.Refresh();
        }
    }
}
