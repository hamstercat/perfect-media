using System.ComponentModel;
using System.Threading.Tasks;
using PerfectMedia.UI.Images.Selection;
using PropertyChanged;

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

        public async Task LoadAvailableImages()
        {
            ImageSelection = new ImageSelectionViewModel(_fileSystemService, _imageStrategy, Path, _horizontalAlignement);
            await ImageSelection.LoadAvailableImages();
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
