using PerfectMedia.TvShows;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.Images
{
    [ImplementPropertyChanged]
    public class ImageSelectionViewModel : IImageSelectionViewModel
    {
        public Image SelectedImage { get; set; }
        public SmartObservableCollection<Image> AvailableImages { get; private set; }
        public ChooseImageFileViewModel Download { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public ImageSelectionViewModel(IImageViewModelFactory viewModelFactory, IImageViewModel imageViewModel, IImageStrategy imageStrategy)
        {
            Download = viewModelFactory.GetChooseImageFile(this);
            foreach (Image image in imageStrategy.FindImages())
            {
                AvailableImages.Add(image);
            }
        }
    }
}
