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
            _metadataProvider.PropertyChanged += MetadataProviderPropertyChanged;
        }

        public bool CanExecute(object parameter)
        {
            return _metadataProvider.IsValid;
        }

        public async void Execute(object parameter)
        {
            await _metadataProvider.Save();
        }

        private void MetadataProviderPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsValid" && CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
