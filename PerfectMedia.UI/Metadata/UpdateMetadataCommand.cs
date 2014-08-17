using System;
using System.Windows.Input;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Progress;

namespace PerfectMedia.UI.Metadata
{
    public class UpdateMetadataCommand : ICommand
    {
        private readonly IMetadataProvider _metadataProvider;
        private readonly IProgressManagerViewModel _progressManager;
        private readonly IBusyProvider _busyProvider;

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public UpdateMetadataCommand(IMetadataProvider metadataProvider, IProgressManagerViewModel progressManager, IBusyProvider busyProvider)
        {
            _metadataProvider = metadataProvider;
            _progressManager = progressManager;
            _busyProvider = busyProvider;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            using (_busyProvider.DoWork())
            {
                foreach (ProgressItem item in await _metadataProvider.Update())
                {
                    _progressManager.AddItem(item);
                }
                await _progressManager.Start();
            }
        }
    }
}
