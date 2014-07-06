using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PerfectMedia.UI.Images
{
    public class SaveImageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private IImageViewModel _imageViewModel;

        public SaveImageCommand(IImageViewModel imageViewModel)
        {
            _imageViewModel = imageViewModel;
            _imageViewModel.PropertyChanged += ImageViewModelPropertyChanged;
        }

        private void ImageViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "SelectedImage" && CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }

        public bool CanExecute(object parameter)
        {
            return _imageViewModel.SelectedImage != null && _imageViewModel.SelectedImage.Url != _imageViewModel.Path;
        }

        public void Execute(object parameter)
        {
            _imageViewModel.SaveSelectedImage();
        }
    }
}
