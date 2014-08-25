using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.Images.Selection
{
    public class DownloadCommand : AsyncCommand
    {
        public override event EventHandler CanExecuteChanged;
        private readonly IChooseImageFileViewModel _chooseImageViewModel;

        public DownloadCommand(IChooseImageFileViewModel chooseImageViewModel)
        {
            _chooseImageViewModel = chooseImageViewModel;
            _chooseImageViewModel.PropertyChanged += ChooseImageViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_chooseImageViewModel.Url);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _chooseImageViewModel.DownloadFile();
        }

        private void ChooseImageViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
