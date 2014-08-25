using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.Metadata
{
    public class DeleteMetadataCommand : AsyncCommand
    {
        public override event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        private readonly IMetadataProvider _metadataProvider;

        public DeleteMetadataCommand(IMetadataProvider metadataProvider)
        {
            _metadataProvider = metadataProvider;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _metadataProvider.Delete();
        }
    }
}
