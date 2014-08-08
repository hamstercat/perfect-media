using System;
using System.Windows.Input;

namespace PerfectMedia.UI.Metadata
{
    public class RefreshMetadataCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        private readonly IMetadataProvider _metadataProvider;

        public RefreshMetadataCommand(IMetadataProvider metadataProvider)
        {
            _metadataProvider = metadataProvider;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _metadataProvider.Refresh();
        }
    }
}
