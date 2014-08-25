using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using PerfectMedia.UI.Busy;
using Xunit;

namespace PerfectMedia.UI.Images.Selection
{
    public class ChooseImageFileViewModelTests
    {
        private readonly ChooseImageFileViewModel _viewModel;
        private readonly IFileSystemService _fileSystemService;
        private readonly IImageSelectionViewModel _imageSelectionViewModel;
        private readonly IBusyProvider _busyProvider;
        private readonly string _path;

        public ChooseImageFileViewModelTests()
        {
            _fileSystemService = Substitute.For<IFileSystemService>();
            _imageSelectionViewModel = Substitute.For<IImageSelectionViewModel>();
            _busyProvider = Substitute.For<IBusyProvider>();
            _path = @"C:\TV Shows\Adventure Time\fanart.jpg";
            _viewModel = new ChooseImageFileViewModel(_fileSystemService, _imageSelectionViewModel, _busyProvider, _path);
        }

        [Fact]
        public async Task SaveLocalFile_Always_CopiesFile()
        {
            // Arrange
            _viewModel.Url = @"C:\Users\Me\Pictures\some image.jpg";

            // Act
            await _viewModel.SaveLocalFile();

            // Assert
            _fileSystemService.Received()
                .CopyFile(@"C:\Users\Me\Pictures\some image.jpg", _path).Async();
        }

        [Fact]
        public async Task DownloadFile_Always_DownloadsImage()
        {
            // Arrange
            _viewModel.Url = "http://google.ca/image.jpg";

            // Act
            await _viewModel.DownloadFile();

            // Assert
            _fileSystemService.Received()
                .DownloadImage(_path, "http://google.ca/image.jpg").Async();
        }
    }
}
