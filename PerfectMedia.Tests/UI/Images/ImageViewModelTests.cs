using System.Threading.Tasks;
using NSubstitute;
using PerfectMedia.UI.Busy;
using Xunit;

namespace PerfectMedia.UI.Images
{
    public class ImageViewModelTests
    {
        private readonly ImageViewModel _viewModel;
        private readonly IFileSystemService _fileSystemService;
        private readonly IBusyProvider _busyProvider;

        public ImageViewModelTests()
        {
            _fileSystemService = Substitute.For<IFileSystemService>();
            _busyProvider = Substitute.For<IBusyProvider>();
            _viewModel = new ImageViewModel(_fileSystemService, _busyProvider, true);
        }
    }
}
