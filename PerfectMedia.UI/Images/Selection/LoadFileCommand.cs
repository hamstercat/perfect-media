using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.Images.Selection
{
    public class LoadFileCommand : AsyncCommand
    {
        public override event EventHandler CanExecuteChanged;
        private readonly IChooseImageFileViewModel _chooseImageViewModel;

        public LoadFileCommand(IChooseImageFileViewModel chooseImageViewModel)
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
            await _chooseImageViewModel.SaveLocalFile();
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
