using System;
using System.ComponentModel;
using System.Windows.Input;

namespace PerfectMedia.UI.Images.Selection
{
    public class LoadFileCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly IChooseImageFileViewModel _chooseImageViewModel;

        public LoadFileCommand(IChooseImageFileViewModel chooseImageViewModel)
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
            _chooseImageViewModel.SaveLocalFile();
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
