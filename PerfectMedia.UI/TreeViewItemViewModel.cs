using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.TvShows.Episodes;
using PropertyChanged;

namespace PerfectMedia.UI
{
    [ImplementPropertyChanged]
    public abstract class TreeViewItemViewModel<TChild> : BaseViewModel, ITreeViewItemViewModel
        where TChild : class
    {
        public abstract string DisplayName { get; }
        protected abstract Task LoadInternal();
        protected abstract Task LoadChildrenInternal();

        private readonly IBusyProvider _busyProvider;
        private bool _childrenLoaded;
        private bool _loaded;

        public ObservableCollection<TChild> Children { get; private set; }

        protected TreeViewItemViewModel(IBusyProvider busyProvider)
            : this(busyProvider, null)
        { }

        protected TreeViewItemViewModel(IBusyProvider busyProvider, TChild dummyChild)
        {
            _busyProvider = busyProvider;
            // We need to set a "dummy" item in the collection for an arrow to appear in the TreeView since we're lazy-loading the items under it
            Children = new ObservableCollection<TChild>();

            if (dummyChild != null)
            {
                Children.Add(dummyChild);
            }
        }

        public async Task Load()
        {
            if (!_loaded)
            {
                _loaded = true;
                using (_busyProvider.DoWork())
                {
                    await LoadInternal();
                }
            }
        }

        public async Task LoadChildren()
        {
            if (!_childrenLoaded)
            {
                using (_busyProvider.DoWork())
                {
                    _childrenLoaded = true;
                    // Delete the dummy object
                    Children.Clear();
                    await LoadChildrenInternal();
                }
            }
        }

        protected void LazyLoaded()
        {
            _loaded = true;
        }
    }
}
