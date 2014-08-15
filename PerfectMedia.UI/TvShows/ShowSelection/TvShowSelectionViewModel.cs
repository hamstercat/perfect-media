using System.Collections.Generic;
using System.Windows.Input;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.TvShows.Shows;
using PropertyChanged;
using System.Threading.Tasks;

namespace PerfectMedia.UI.TvShows.ShowSelection
{
    [ImplementPropertyChanged]
    public class TvShowSelectionViewModel : BaseViewModel, ITvShowSelectionViewModel
    {
        public string SearchTitle { get; set; }
        public bool IsClosed { get; set; }
        public object OriginalContent { get; set; }
        public SelectionViewModel<Series> Selection { get; private set; }
        public ICommand SearchCommand { get; private set; }

        public TvShowSelectionViewModel(ITvShowMetadataService metadataService, ITvShowMetadataViewModel tvShowMetadata, string path)
        {
            SearchCommand = new SearchCommand(metadataService, this);
            Selection = new SelectionViewModel<Series>(async serie =>
            {
                await SaveNewId(metadataService, serie.SeriesId, path);
                await Update(metadataService, tvShowMetadata, path);
                IsClosed = true;
            });
        }

        public void ReplaceSeries(IEnumerable<Series> series)
        {
            Selection.AvailableItems.Clear();
            foreach (Series serie in series)
            {
                Selection.AvailableItems.Add(serie);
            }
        }

        private async Task SaveNewId(ITvShowMetadataService metadataService, string serieId, string path)
        {
            TvShowMetadata metadata = await metadataService.Get(path);
            metadata.Id = serieId;
            metadataService.Save(path, metadata);
        }

        private async Task Update(ITvShowMetadataService metadataService, ITvShowMetadataViewModel tvShowMetadata, string path)
        {
            await metadataService.DeleteImages(path);
            await metadataService.Update(path);
            await tvShowMetadata.Refresh();
        }
    }
}
