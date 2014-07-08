using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Images
{
    public class ImageViewModelFactory : IImageViewModelFactory
    {
        private readonly IFileSystemService _fileSystemService;

        public ImageViewModelFactory(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        public ChooseImageFileViewModel GetChooseImageFile(IImageSelectionViewModel imageSelectionViewModel)
        {
            return new ChooseImageFileViewModel(_fileSystemService, imageSelectionViewModel);
        }
    }
}
