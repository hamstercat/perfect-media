using System;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Progress;

namespace PerfectMedia.UI.Metadata
{
    public class UpdateMetadataCommand : AsyncCommand
    {
        private readonly IMetadataProvider _metadataProvider;
        private readonly IProgressManagerViewModel _progressManager;
        private readonly IBusyProvider _busyProvider;

        public override event EventHandler CanExecuteChanged
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

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override async Task ExecuteAsync(object parameter)
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
