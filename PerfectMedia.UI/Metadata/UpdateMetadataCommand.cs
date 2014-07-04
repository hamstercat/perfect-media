using PerfectMedia.UI.Progress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.Metadata
{
    public class UpdateMetadataCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

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
