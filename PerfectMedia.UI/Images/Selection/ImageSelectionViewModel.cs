﻿using System.Threading.Tasks;
using PropertyChanged;

namespace PerfectMedia.UI.Images.Selection
{
    [ImplementPropertyChanged]
    public class ImageSelectionViewModel : BaseViewModel, IImageSelectionViewModel
    {
        private readonly IImageStrategy _imageStrategy;

        public bool HorizontalAlignement { get; private set; }
        public bool IsClosed { get; set; }
        public object OriginalContent { get; set; }
        public SelectionViewModel<Image> Selection { get; private set; }
        public IChooseImageFileViewModel Download { get; private set; }

        public ImageSelectionViewModel(IFileSystemService fileSystemService, IImageStrategy imageStrategy, string path, bool horizontalAlignement)
        {
            _imageStrategy = imageStrategy;
            HorizontalAlignement = horizontalAlignement;
            Image defaultImage = new Image { Url = path };
            Selection = new SelectionViewModel<Image>(defaultImage, async image =>
            {
                await fileSystemService.DownloadImage(path, image.Url);
                IsClosed = true;
            });
            Download = new ChooseImageFileViewModel(fileSystemService, this, path);
        }

        public async Task LoadAvailableImages()
        {
            Selection.AvailableItems.Clear();
            foreach (Image image in await _imageStrategy.FindImages())
            {
                Selection.AvailableItems.Add(image);
            }
        }
    }
}
