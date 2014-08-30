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
    public class ImageSelectionViewModelTests
    {
        private readonly ImageSelectionViewModel _viewModel;
        private readonly IFileSystemService _fileSystemService;
        private readonly IImageStrategy _imageStrategy;
        private readonly IBusyProvider _busyProvider;
        private readonly string _path;

        public ImageSelectionViewModelTests()
        {
            _fileSystemService = Substitute.For<IFileSystemService>();
            _imageStrategy = Substitute.For<IImageStrategy>();
            _busyProvider = Substitute.For<IBusyProvider>();
            _path = @"C:\Folder\image.jpg";
            _viewModel = new ImageSelectionViewModel(_fileSystemService, _imageStrategy, _busyProvider, _path, true);
        }

        [Fact]
        public async Task LoadAvailableImages_WithoutImages_ClearsExistingImages()
        {
            // Arrange
            _viewModel.Selection.AvailableItems.Add(new Image());

            // Act
            await _viewModel.LoadAvailableImages();

            // Assert
            Assert.Empty(_viewModel.Selection.AvailableItems);
        }

        [Fact]
        public async Task LoadAvailableImages_WithImages_AddsThoseImages()
        {
            // Arrange
            Image image1 = new Image { Description = "First image" };
            Image image2 = new Image { Description = "Second image" };
            IEnumerable<Image> images = new List<Image> { image1, image2 };
            _imageStrategy.FindImages()
                .Returns(images.ToTask());

            // Act
            await _viewModel.LoadAvailableImages();

            // Assert
            Assert.NotEmpty(_viewModel.Selection.AvailableItems);
            Assert.Equal(images, _viewModel.Selection.AvailableItems);
        }
    }
}
