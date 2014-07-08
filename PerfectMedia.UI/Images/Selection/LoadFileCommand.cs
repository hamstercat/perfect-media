using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PerfectMedia.UI.Images.Selection
{
    public class LoadFileCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly IFileSystemService _fileSystemService;
        private readonly IImageViewModel _imageViewModel;
        private readonly ChooseImageFileViewModel _chooseImageViewModel;

        public LoadFileCommand(IFileSystemService fileSystemService, IImageViewModel imageViewModel, ChooseImageFileViewModel chooseImageViewModel)
        {
            _fileSystemService = fileSystemService;
            _imageViewModel = imageViewModel;
            _chooseImageViewModel = chooseImageViewModel;
            _chooseImageViewModel.PropertyChanged += ChooseImageViewModelPropertyChanged;
        }

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_chooseImageViewModel.Url);
        }

        public void Execute(object parameter)
        {
            _fileSystemService.CopyFile(_chooseImageViewModel.Url, _imageViewModel.Path);
            _chooseImageViewModel.IsClosed = true;
            _imageViewModel.IsClosed = true;
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
