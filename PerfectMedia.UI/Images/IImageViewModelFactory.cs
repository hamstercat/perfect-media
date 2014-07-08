using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Images
{
    public interface IImageViewModelFactory
    {
        ChooseImageFileViewModel GetChooseImageFile(IImageSelectionViewModel imageSelectionViewModel);
    }
}
