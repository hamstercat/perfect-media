using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.UI.Images
{
    public class ImageViewModelTests
    {
        private readonly ImageViewModel _viewModel;

        public ImageViewModelTests()
        {
            _viewModel = Substitute.ForPartsOf<ImageViewModel>();
        }
    }
}
