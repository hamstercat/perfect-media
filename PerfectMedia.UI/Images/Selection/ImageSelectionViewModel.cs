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
        public bool IsClosed { get; set; }
        public object OriginalContent { get; set; }
        public SelectionViewModel<Image> Selection { get; private set; }
        public IChooseImageFileViewModel Download { get; private set; }

        public ImageSelectionViewModel(IFileSystemService fileSystemService, IImageStrategy imageStrategy, string path)
        {
            Image defaultImage = new Image { Url = path };
            Selection = new SelectionViewModel<Image>(defaultImage, image =>
            {
                fileSystemService.DownloadImage(path, image.Url);
                IsClosed = true;
            });
            Download = new ChooseImageFileViewModel(fileSystemService, this, path);
            LoadAvailableImages(imageStrategy);
        }

        private void LoadAvailableImages(IImageStrategy imageStrategy)
        {
            Selection.AvailableItems.Clear();
            foreach (Image image in imageStrategy.FindImages())
            {
                Selection.AvailableItems.Add(image);
            }
        }
    }
}
