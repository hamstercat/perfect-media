using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.UI.Busy;
using PropertyChanged;

namespace PerfectMedia.UI.Selection
{
    [ImplementPropertyChanged]
    public abstract class SearchableSelectionViewModel<T> : SelectionViewModel<T>, ISearchableSelectionViewModel<T>
        where T : class
    {
        private readonly IBusyProvider _busyProvider;

        public string SearchTitle { get; set; }
        public ICommand SearchCommand { get; private set; }

        protected SearchableSelectionViewModel(IBusyProvider busyProvider, string searchTitle)
            : base(busyProvider)
        {
            _busyProvider = busyProvider;
            SearchTitle = searchTitle;
            SearchCommand = new SearchCommand<T>(this);
        }

        public async Task Search()
        {
            using (_busyProvider.DoWork())
            {
                IEnumerable<T> items = await SearchInternal(SearchTitle);
                SetAvailableItems(items);
            }
        }

        protected abstract Task<IEnumerable<T>> SearchInternal(string searchTitle);
    }
}
