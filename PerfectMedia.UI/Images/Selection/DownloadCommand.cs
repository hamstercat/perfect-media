using System;
using System.ComponentModel;
using System.Windows.Input;

namespace PerfectMedia.UI.Images.Selection
{
    public class DownloadCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly IChooseImageFileViewModel _chooseImageViewModel;

        public DownloadCommand(IChooseImageFileViewModel chooseImageViewModel)
        {
            _chooseImageViewModel = chooseImageViewModel;
            _chooseImageViewModel.PropertyChanged += ChooseImageViewModelPropertyChanged;
        }

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_chooseImageViewModel.Url);
        }

        public void Execute(object parameter)
        {
            _chooseImageViewModel.DownloadFile();
        }

        private void ChooseImageViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
