using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.TvShows.Shows;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
            Selection = new SelectionViewModel<Series>(serie =>
            {
                SaveNewId(metadataService, serie.SeriesId, path);
                Update(metadataService, tvShowMetadata, path);
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

        private void SaveNewId(ITvShowMetadataService metadataService, string serieId, string path)
        {
            TvShowMetadata metadata = metadataService.Get(path);
            metadata.Id = serieId;
            metadataService.Save(path, metadata);
        }

        private void Update(ITvShowMetadataService metadataService, ITvShowMetadataViewModel tvShowMetadata, string path)
        {
            metadataService.DeleteImages(path);
            metadataService.Update(path);
            tvShowMetadata.Refresh();
        }
    }
}
