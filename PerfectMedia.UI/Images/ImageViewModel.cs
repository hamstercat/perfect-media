using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
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
    public class ImageViewModel : IImageViewModel
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IImageStrategy _imageStrategy;

        public event PropertyChangedEventHandler PropertyChanged;
        public string Path { get; set; }
        public object OriginalContent { get; set; }
        public ChooseImageFileViewModel Download { get; private set; }
        public bool IsClosed { get; set; }
        public ObservableCollection<Image> AvailableImages { get; private set; }
        public Image SelectedImage { get; set; }
        public ICommand SaveCommand { get; private set; }

        public ImageViewModel(IFileSystemService fileSystemService)
            : this(fileSystemService, new NoImageStrategy())
        { }

        public ImageViewModel(IFileSystemService fileSystemService, IImageStrategy imageStrategy)
        {
            _fileSystemService = fileSystemService;
            _imageStrategy = imageStrategy;
            IsClosed = false;
            AvailableImages = new ObservableCollection<Image>();
            SaveCommand = new SaveImageCommand(this);
        }

        public void LoadAvailableImages()
        {
            // Use the current image by default
            SelectedImage = new Image { Url = Path };
            IsClosed = false;
            AvailableImages.Clear();
            Download = new ChooseImageFileViewModel(_fileSystemService, this);
            foreach (Image image in _imageStrategy.FindImages())
            {
                AvailableImages.Add(image);
            }
        }

        public void SaveSelectedImage()
        {
            // Force a UI refresh
            string path = Path;
            Path = null;
            _fileSystemService.DownloadFile(path, SelectedImage.Url);
            Path = path;
            IsClosed = true;
        }
    }
}
