using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectMedia.Serialization;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PropertyChanged;

namespace PerfectMedia.UI
{
    [ImplementPropertyChanged]
    public abstract class MediaViewModel<TChild> : TreeViewItemViewModel<TChild>, IMetadataProvider
        where TChild : class
    {
        protected abstract Task RefreshInternal();
        protected abstract Task<IEnumerable<ProgressItem>> UpdateInternal();
        protected abstract Task SaveInternal();
        protected abstract Task DeleteInternal();

        private readonly IBusyProvider _busyProvider;
        private readonly IDialogViewer _dialogViewer;

        protected MediaViewModel(IBusyProvider busyProvider, IDialogViewer dialogViewer)
            : this(busyProvider, dialogViewer, null)
        { }

        protected MediaViewModel(IBusyProvider busyProvider, IDialogViewer dialogViewer, TChild dummyChild)
            : base(busyProvider, dummyChild)
        {
            _busyProvider = busyProvider;
            _dialogViewer = dialogViewer;
        }

        public async Task Refresh()
        {
            LazyLoaded();
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

        protected override async Task LoadInternal()
        {
            await Refresh();
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
