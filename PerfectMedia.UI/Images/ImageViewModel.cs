using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Images.Selection;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.Images
{
    [ImplementPropertyChanged]
    public class ImageViewModel : BaseViewModel, IImageViewModel
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IImageStrategy _imageStrategy;

        public string Path { get; set; }
        public ImageSelectionViewModel ImageSelection { get; private set; }

        public object OriginalContent
        {
            get
            {
                return ImageSelection.OriginalContent;
            }
            set
            {
                ImageSelection.OriginalContent = value;
            }
        }

        public ImageViewModel(IFileSystemService fileSystemService)
            : this(fileSystemService, new NoImageStrategy())
        { }

        public ImageViewModel(IFileSystemService fileSystemService, IImageStrategy imageStrategy)
        {
            _fileSystemService = fileSystemService;
            _imageStrategy = imageStrategy;
        }

        public void LoadAvailableImages()
        {
            ImageSelection = new ImageSelectionViewModel(_fileSystemService, _imageStrategy, Path);
            ImageSelection.PropertyChanged += ImageSelectionPropertyChanged;
        }

        private void ImageSelectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("Path");
        }
    }
}
