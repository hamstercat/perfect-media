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
        private readonly bool _horizontalAlignement;

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

        public ImageViewModel(IFileSystemService fileSystemService, bool horizontalAlignement)
            : this(fileSystemService, horizontalAlignement, new NoImageStrategy())
        { }

        public ImageViewModel(IFileSystemService fileSystemService, bool horizontalAlignement, IImageStrategy imageStrategy)
        {
            _fileSystemService = fileSystemService;
            _imageStrategy = imageStrategy;
            _horizontalAlignement = horizontalAlignement;
        }

        public void LoadAvailableImages()
        {
            ImageSelection = new ImageSelectionViewModel(_fileSystemService, _imageStrategy, Path, _horizontalAlignement);
            ImageSelection.PropertyChanged += ImageSelectionPropertyChanged;
        }

        public void RefreshImage()
        {
            OnPropertyChanged("Path");
        }

        private void ImageSelectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RefreshImage();
        }
    }
}
