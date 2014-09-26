using System.Collections.Generic;
using System.Windows.Input;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Selection;
using PerfectMedia.UI.TvShows.Shows;
using PropertyChanged;
using System.Threading.Tasks;

namespace PerfectMedia.UI.TvShows.ShowSelection
{
    [ImplementPropertyChanged]
    public class TvShowSelectionViewModel : SearchableSelectionViewModel<Series>, ITvShowSelectionViewModel
    {
        private readonly ITvShowMetadataService _metadataService;
        private readonly ITvShowViewModel _tvShowMetadata;

        public TvShowSelectionViewModel(ITvShowMetadataService metadataService,
            ITvShowViewModel tvShowMetadata,
            IBusyProvider busyProvider)
            : base(busyProvider, tvShowMetadata.Title.OriginalValue)
        {
            _metadataService = metadataService;
            _tvShowMetadata = tvShowMetadata;
        }

        protected override async Task SaveInternal(Series selectedItem)
        {
            await SaveNewId(selectedItem.SeriesId, _tvShowMetadata.Path);
            await Update(_tvShowMetadata.Path);
        }

        protected override Task<IEnumerable<Series>> SearchInternal(string searchTitle)
        {
            return _metadataService.FindSeries(searchTitle);
        }

        private async Task SaveNewId(string serieId, string path)
        {
            TvShowMetadata metadata = await _metadataService.Get(path);
            metadata.Id = serieId;
            await _metadataService.Save(path, metadata);
        }

        private async Task Update(string path)
        {
            await _metadataService.DeleteImages(path);
            await _metadataService.Update(path);
            await _tvShowMetadata.Refresh();
        }
    }
}
