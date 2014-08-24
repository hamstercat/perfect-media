using System;
using System.ComponentModel;
using System.Windows.Input;

namespace PerfectMedia.UI.Metadata
{
    public class SaveMetadataCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly IMetadataProvider _metadataProvider;

        public SaveMetadataCommand(IMetadataProvider metadataProvider)
        {
            _metadataProvider = metadataProvider;
            _metadataProvider.ErrorsChanged += MetadataProviderErrorsChanged;
        }

        public bool CanExecute(object parameter)
        {
            return !_metadataProvider.HasErrors;
        }

        public async void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                await _metadataProvider.Save();
            }
        }

        private void MetadataProviderErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
