using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Seasons;
using PerfectMedia.UI.TvShows.ShowSelection;

namespace PerfectMedia.UI.TvShows.Shows
{
    public interface ITvShowViewModel : IMetadataProvider
    {
        string Path { get; }
        string Id { get; }
        string DisplayName { get; }
        ICachedPropertyViewModel<string> Title { get; }
        ITvShowSelectionViewModel Selection { get; }
        ObservableCollection<ISeasonViewModel> Seasons { get; }
        Task<IEnumerable<ProgressItem>> FindNewEpisodes();
    }
}
