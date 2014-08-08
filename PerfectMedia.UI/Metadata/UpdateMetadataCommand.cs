using System;
using System.Windows.Input;
using PerfectMedia.UI.Progress;

namespace PerfectMedia.UI.Metadata
{
    public class UpdateMetadataCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        private readonly IMetadataProvider _metadataProvider;
        private readonly IProgressManagerViewModel _progressManager;

        public UpdateMetadataCommand(IMetadataProvider metadataProvider, IProgressManagerViewModel progressManager)
        {
            _metadataProvider = metadataProvider;
            _progressManager = progressManager;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            foreach (ProgressItem item in _metadataProvider.Update())
            {
                _progressManager.AddItem(item);
            }
            _progressManager.Start();
        }
    }
}
