using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Images
{
    [ImplementPropertyChanged]
    public class ImageViewModel : IImageViewModel
    {
        private readonly IImageStrategy _imageStrategy;

        public string Path { get; set; }
        public ObservableCollection<Image> AvailableImages { get; private set; }
        public Image SelectedImage { get; set; }

        public ImageViewModel()
            : this(new NoImageStrategy())
        { }

        public ImageViewModel(IImageStrategy imageStrategy)
        {
            _imageStrategy = imageStrategy;
            AvailableImages = new ObservableCollection<Image>();
        }

        public void LoadAvailableImages()
        {
            // Use the current image by default
            SelectedImage = new Image { Url = Path };
            AvailableImages.Clear();
            foreach (Image image in _imageStrategy.FindImages())
            {
                AvailableImages.Add(image);
            }
        }
    }
}
