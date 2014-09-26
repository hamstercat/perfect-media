using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Images.Selection;
using PropertyChanged;

namespace PerfectMedia.UI.Images
{
    [ImplementPropertyChanged]
    public class ImageViewModel : BaseViewModel, IImageViewModel
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IBusyProvider _busyProvider;
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

        public ImageViewModel(IFileSystemService fileSystemService, IBusyProvider busyProvider, bool horizontalAlignement)
            : this(fileSystemService, busyProvider, horizontalAlignement, new NoImageStrategy())
        { }

        public ImageViewModel(IFileSystemService fileSystemService, IBusyProvider busyProvider, bool horizontalAlignement, IImageStrategy imageStrategy)
        {
            _fileSystemService = fileSystemService;
            _busyProvider = busyProvider;
            _imageStrategy = imageStrategy;
            _horizontalAlignement = horizontalAlignement;
        }

        public async Task LoadAvailableImages()
        {
            using (_busyProvider.DoWork())
            {
                ImageSelection = new ImageSelectionViewModel(_fileSystemService, _busyProvider, Path, _horizontalAlignement);
                IEnumerable<Image> images = await _imageStrategy.FindImages();
                ImageSelection.SetAvailableItems(images);
                ImageSelection.PropertyChanged += ImageSelectionPropertyChanged;
            }
        }

        public void RefreshImage()
        {
            RefreshImage(Path);
        }

        public void RefreshImage(string newPath)
        {
            // Force the refresh of the image by WPF Image control by changing it's value
            Path = string.Empty;
            Path = newPath;
        }

        private void ImageSelectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RefreshImage();
        }
    }
}
