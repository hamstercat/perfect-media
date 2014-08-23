using NSubstitute;
using PerfectMedia.UI.Cache;
using Xunit;

namespace PerfectMedia.UI
{
    public class CachedPropertyViewModelTests
    {
        private readonly CachedPropertyViewModel<string> _viewModel;
        private readonly IKeyDataStore _keyDataStore;
        private readonly string _filePath;

        public CachedPropertyViewModelTests()
        {
            _filePath = @"C:\Folder\TV Shows\Game of Thrones";
            _keyDataStore = Substitute.For<IKeyDataStore>();
            _viewModel = new StringCachedPropertyViewModel(_keyDataStore, _filePath);
        }

        [Fact]
        public void Value_SetProperty_SavesIt()
        {
            // Act
            _viewModel.Value = "Game of Thrones";

            // Assert
            _keyDataStore.Received()
                .SetValue(_filePath, "Game of Thrones");
        }

        [Fact]
        public void Value_GetPropertyWithValueSet_RetursIt()
        {
            // Arrange
            _keyDataStore.GetValue(_filePath)
                .Returns("Game of Thrones");

            // Act
            string value = _viewModel.Value;

            // Assert
            Assert.Equal("Game of Thrones", value);
        }

        [Fact]
        public void Value_WithoutSettingTheValue_ReturnsTheSavedOne()
        {
            // Arrange
            _keyDataStore.GetValue(_filePath)
                .Returns("Game of Thrones");

            // Act
            string value = _viewModel.Value;

            // Assert
            Assert.Equal("Game of Thrones", value);
        }
    }
}
