using System.Collections.Generic;
using System.Collections.ObjectModel;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Seasons;
using PerfectMedia.UI.TvShows.ShowSelection;

namespace PerfectMedia.UI.TvShows.Shows
{
    public interface ITvShowViewModel : IMetadataProvider
    {
        string Path { get; }
        string DisplayName { get; }
        ITvShowSelectionViewModel Selection { get; }
        ObservableCollection<ISeasonViewModel> Seasons { get; }
        IEnumerable<ProgressItem> FindNewEpisodes();
    }
}
