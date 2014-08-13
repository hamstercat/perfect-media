using PropertyChanged;

namespace PerfectMedia.UI.Images.Selection
{
    [ImplementPropertyChanged]
    public class ImageSelectionViewModel : BaseViewModel, IImageSelectionViewModel
    {
        public bool HorizontalAlignement { get; private set; }
        public bool IsClosed { get; set; }
        public object OriginalContent { get; set; }
        public SelectionViewModel<Image> Selection { get; private set; }
        public IChooseImageFileViewModel Download { get; private set; }

        public ImageSelectionViewModel(IFileSystemService fileSystemService, IImageStrategy imageStrategy, string path, bool horizontalAlignement)
        {
            HorizontalAlignement = horizontalAlignement;
            Image defaultImage = new Image { Url = path };
            Selection = new SelectionViewModel<Image>(defaultImage, async image =>
            {
                await fileSystemService.DownloadImage(path, image.Url);
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
