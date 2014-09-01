using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectMedia.UI.Busy;
using PropertyChanged;

namespace PerfectMedia.UI
{
    [ImplementPropertyChanged]
    public abstract class TreeViewItemViewModel : BaseViewModel, ITreeViewItemViewModel
    {
        public abstract string DisplayName { get; }
        protected abstract Task LoadInternal();
        protected abstract Task LoadChildrenInternal();

        private readonly IBusyProvider _busyProvider;
        private bool _childrenLoaded;
        private bool _loaded;

        public TreeViewItemViewModel(IBusyProvider busyProvider)
        {
            _busyProvider = busyProvider;
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
