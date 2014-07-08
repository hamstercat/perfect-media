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
        public object OriginalContent { get; set; }
        public bool IsClosed { get; set; }
        public ImageSelectionViewModel ImageSelection { get; private set; }

        public ImageViewModel(IFileSystemService fileSystemService)
            : this(fileSystemService, new NoImageStrategy())
        { }

        public ImageViewModel(IFileSystemService fileSystemService, IImageStrategy imageStrategy)
        {
            _fileSystemService = fileSystemService;
            _imageStrategy = imageStrategy;
            IsClosed = false;
        }

        public void LoadAvailableImages()
        {
            ImageSelection = new ImageSelectionViewModel(_fileSystemService, this, _imageStrategy);
            // Use the current image by default
            ImageSelection.SelectedImage = new Image { Url = Path };
            IsClosed = false;
        }

        public void SaveSelectedImage()
        {
            _fileSystemService.DownloadFile(Path, ImageSelection.SelectedImage.Url);
            OnPropertyChanged("Path");
            IsClosed = true;
        }
    }
}
