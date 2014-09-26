using System.Collections.Generic;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Selection;

namespace PerfectMedia.UI.TvShows.ShowSelection
{
    public interface ITvShowSelectionViewModel : ISearchableSelectionViewModel<Series>
    {
        void SetAvailableItems(IEnumerable<Series> items);
    }
}
