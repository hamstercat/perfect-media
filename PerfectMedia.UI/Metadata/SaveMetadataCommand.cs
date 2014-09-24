using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Metadata
{
    public class SaveMetadataCommand : AsyncCommand
    {
        public override event EventHandler CanExecuteChanged;

        private readonly IMetadataProvider _metadataProvider;

        public SaveMetadataCommand(IMetadataProvider metadataProvider)
        {
            _metadataProvider = metadataProvider;
            _metadataProvider.ErrorsChanged += MetadataProviderErrorsChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !_metadataProvider.HasErrors;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (CanExecute(parameter))
            {
                await _metadataProvider.Save();
            }
        }

        private void MetadataProviderErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
