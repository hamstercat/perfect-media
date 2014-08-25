using NSubstitute;
using Xunit;

namespace PerfectMedia.UI.Cache
{
    public class StringCachedPropertyViewModelTests
    {
        private readonly IKeyDataStore _keyDataStore;
        private readonly string _key;

        public StringCachedPropertyViewModelTests()
        {
            _keyDataStore = Substitute.For<IKeyDataStore>();
            _key = @"C:\Folder\TV Shows\Game of Thrones (Complete)";
        }

        [Fact]
        public void Constructor_WhenValueIsCached_SetsValue()
        {
            // Arrange
            _keyDataStore.GetValue(_key)
                .Returns("Game of Thrones");

            // Act
            var viewModel = new StringCachedPropertyViewModel(_keyDataStore, _key, true);

            // Assert
            Assert.Equal("Game of Thrones", viewModel.Value);
            Assert.Equal("Game of Thrones", viewModel.CachedValue);
        }

        [Fact]
        public void Constructor_WhenValueIsntCached_DoesNothing()
        {
            // Act
            var viewModel = new StringCachedPropertyViewModel(_keyDataStore, _key, true);

            // Assert
            Assert.True(string.IsNullOrEmpty(viewModel.Value));
            Assert.True(string.IsNullOrEmpty(viewModel.CachedValue));
        }

        [Fact]
        public void SetValue_Never_ChangesCachedValue()
        {
            // Arrange
            var viewModel = new StringCachedPropertyViewModel(_keyDataStore, _key, true);

            // Act
            viewModel.Value = "Game of Thrones";

            // Assert
            Assert.True(string.IsNullOrEmpty(viewModel.CachedValue));
        }

        [Fact]
        public void Save_Always_SavesTheValueInTheCache()
        {
            // Arrange
            var viewModel = new StringCachedPropertyViewModel(_keyDataStore, _key, true);
            viewModel.Value = "Game of Thrones";

            // Act
            viewModel.Save();

            // Assert
            _keyDataStore.Received()
                .SetValue(_key, "Game of Thrones");
        }

        [Fact]
        public void Save_Always_SetsValueToCachedValue()
        {
            // Arrange
            var viewModel = new StringCachedPropertyViewModel(_keyDataStore, _key, true);
            viewModel.Value = "Game of Thrones";

            // Act
            viewModel.Save();

            // Assert
            Assert.Equal("Game of Thrones", viewModel.CachedValue);
        }

        [Fact]
        public void HasErrors_WhenPropertyIsRequiredAndMissing_ReturnsTrue()
        {
            // Arrange
            var viewModel = new StringCachedPropertyViewModel(_keyDataStore, _key, true);
            viewModel.Value = string.Empty;

            // Act
            bool hasErrors = viewModel.HasErrors;

            // Assert
            Assert.True(hasErrors);
        }

        [Fact]
        public void HasErrors_WhenPropertyIsntRequiredAndMissing_ReturnsFalse()
        {
            // Arrange
            var viewModel = new StringCachedPropertyViewModel(_keyDataStore, _key, false);
            viewModel.Value = string.Empty;

            // Act
            bool hasErrors = viewModel.HasErrors;

            // Assert
            Assert.False(hasErrors);
        }
    }
}
