using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PerfectMedia.UI.Images.Selection
{
    public class SaveImageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly IImageViewModel _imageViewModel;
        private readonly IImageSelectionViewModel _imageSelectionViewModel;

        public SaveImageCommand(IImageViewModel imageViewModel, IImageSelectionViewModel imageSelectionViewModel)
        {
            _imageViewModel = imageViewModel;
            _imageSelectionViewModel = imageSelectionViewModel;
            _imageSelectionViewModel.PropertyChanged += ImageViewModelPropertyChanged;
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
            return _imageSelectionViewModel.SelectedImage != null && _imageSelectionViewModel.SelectedImage.Url != _imageViewModel.Path;
        }

        public void Execute(object parameter)
        {
            _imageViewModel.SaveSelectedImage();
        }
    }
}
