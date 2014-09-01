using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectMedia.Serialization;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;

namespace PerfectMedia.UI
{
    public abstract class MediaViewModel : BaseViewModel, IMetadataProvider, ITreeViewItemViewModel
    {
        public abstract string DisplayName { get; }
        protected abstract Task RefreshInternal();
        protected abstract Task<IEnumerable<ProgressItem>> UpdateInternal();
        protected abstract Task SaveInternal();
        protected abstract Task DeleteInternal();
        protected abstract Task LoadChildrenInternal();

        private readonly IBusyProvider _busyProvider;
        private readonly IDialogViewer _dialogViewer;
        private bool _childrenLoaded;
        private bool _loaded;

        protected MediaViewModel(IBusyProvider busyProvider, IDialogViewer dialogViewer)
        {
            _busyProvider = busyProvider;
            _dialogViewer = dialogViewer;
        }

        public async Task Refresh()
        {
            _loaded = true;
            using (_busyProvider.DoWork())
            {
                await TryRefreshInternal();
            }
        }

        public async Task<IEnumerable<ProgressItem>> Update()
        {
            using (_busyProvider.DoWork())
            {
                return await UpdateInternal();
            }
        }

        public async Task Save()
        {
            using (_busyProvider.DoWork())
            {
                await SaveInternal();
            }
        }

        public async Task Delete()
        {
            using (_busyProvider.DoWork())
            {
                await DeleteInternal();
            }
        }

        public async Task Load()
        {
            if (!_loaded)
            {
                using (_busyProvider.DoWork())
                {
                    await Refresh();
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

        private async Task TryRefreshInternal()
        {
            string title = null;
            string message = null;
            try
            {
                await RefreshInternal();
            }
            catch (InvalidNfoException ex)
            {
                title = "Invalid .nfo file";
                message = string.Format(".nfo file \"{0}\" is invalid. That file has been backed up as a \".bak\" file in the same folder.", ex.NfoFilePath);
            }
            await ShowMessageIfNeeded(title, message);
        }

        private async Task ShowMessageIfNeeded(string title, string message)
        {
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(message))
            {
                await _dialogViewer.ShowMessage(title, message);
            }
        }
    }
}
