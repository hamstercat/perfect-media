using PerfectMedia.TvShows;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.Images.Selection
{
    [ImplementPropertyChanged]
    public class ImageSelectionViewModel : BaseViewModel, IImageSelectionViewModel
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly string _path;

        public Image SelectedImage { get; set; }
        public SmartObservableCollection<Image> AvailableImages { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public IChooseImageFileViewModel Download { get; private set; }
        public bool IsClosed { get; set; }
        public object OriginalContent { get; set; }

        public ImageSelectionViewModel(IFileSystemService fileSystemService, IImageStrategy imageStrategy, string path)
        {
            _fileSystemService = fileSystemService;
            _path = path;
            SelectedImage = new Image { Url = _path };
            AvailableImages = new SmartObservableCollection<Image>();
            SaveCommand = new SaveImageCommand(this, _path);
            Download = new ChooseImageFileViewModel(fileSystemService, this, _path);
            LoadAvailableImages(imageStrategy);
        }

        public void SaveSelectedImage()
        {
            _fileSystemService.DownloadFile(_path, SelectedImage.Url);
            IsClosed = true;
        }

        private void LoadAvailableImages(IImageStrategy imageStrategy)
        {
            foreach (Image image in imageStrategy.FindImages())
            {
                AvailableImages.Add(image);
            }
        }
    }
}
