using NSubstitute;

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
