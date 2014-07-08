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
        public Image SelectedImage { get; set; }
        public SmartObservableCollection<Image> AvailableImages { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ChooseImageFileViewModel Download { get; private set; }

        public ImageSelectionViewModel(IFileSystemService fileSystemService, IImageViewModel imageViewModel, IImageStrategy imageStrategy)
        {
            AvailableImages = new SmartObservableCollection<Image>();
            SaveCommand = new SaveImageCommand(imageViewModel, this);
            Download = new ChooseImageFileViewModel(fileSystemService, imageViewModel);
            foreach (Image image in imageStrategy.FindImages())
            {
                AvailableImages.Add(image);
            }
        }
    }
}
