using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.Metadata
{
    public class RefreshMetadataCommand : AsyncCommand
    {
        public override event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        private readonly IMetadataProvider _metadataProvider;

        public RefreshMetadataCommand(IMetadataProvider metadataProvider)
        {
            _metadataProvider = metadataProvider;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _metadataProvider.Refresh();
        }
    }
}
