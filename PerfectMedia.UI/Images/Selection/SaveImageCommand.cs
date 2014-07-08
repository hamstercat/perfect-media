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
        private readonly IImageSelectionViewModel _imageSelectionViewModel;
        private readonly string _path;

        public SaveImageCommand(IImageSelectionViewModel imageSelectionViewModel, string path)
        {
            _imageSelectionViewModel = imageSelectionViewModel;
            _imageSelectionViewModel.PropertyChanged += ImageViewModelPropertyChanged;
            _path = path;
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
            return _imageSelectionViewModel.SelectedImage != null && _imageSelectionViewModel.SelectedImage.Url != _path;
        }

        public void Execute(object parameter)
        {
            _imageSelectionViewModel.SaveSelectedImage();
        }
    }
}
