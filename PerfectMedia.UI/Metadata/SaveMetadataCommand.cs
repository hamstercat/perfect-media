using System;
using System.Windows.Input;

namespace PerfectMedia.UI.Metadata
{
    public class SaveMetadataCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        private readonly IMetadataProvider _metadataProvider;

        public SaveMetadataCommand(IMetadataProvider metadataProvider)
        {
            _metadataProvider = metadataProvider;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _metadataProvider.Save();
        }
    }
}
