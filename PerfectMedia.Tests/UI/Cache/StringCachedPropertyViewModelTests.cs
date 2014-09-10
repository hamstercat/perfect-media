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
            var viewModel = new StringCachedPropertyDecorator(_keyDataStore, _key);

            // Assert
            Assert.Equal("Game of Thrones", viewModel.Value);
            Assert.Equal("Game of Thrones", viewModel.OriginalValue);
        }

        [Fact]
        public void Constructor_WhenValueIsntCached_DoesNothing()
        {
            // Act
            var viewModel = new StringCachedPropertyDecorator(_keyDataStore, _key);

            // Assert
            Assert.True(string.IsNullOrEmpty(viewModel.Value));
            Assert.True(string.IsNullOrEmpty(viewModel.OriginalValue));
        }

        [Fact]
        public void SetValue_Never_ChangesCachedValue()
        {
            // Arrange
            var viewModel = new StringCachedPropertyDecorator(_keyDataStore, _key);

            // Act
            viewModel.Value = "Game of Thrones";

            // Assert
            Assert.True(string.IsNullOrEmpty(viewModel.OriginalValue));
        }

        [Fact]
        public void Save_Always_SavesTheValueInTheCache()
        {
            // Arrange
            var viewModel = new StringCachedPropertyDecorator(_keyDataStore, _key);
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
            var viewModel = new StringCachedPropertyDecorator(_keyDataStore, _key);
            viewModel.Value = "Game of Thrones";

            // Act
            viewModel.Save();

            // Assert
            Assert.Equal("Game of Thrones", viewModel.OriginalValue);
        }

        [Fact]
        public void HasErrors_WhenPropertyIsntRequiredAndMissing_ReturnsFalse()
        {
            // Arrange
            var viewModel = new StringCachedPropertyDecorator(_keyDataStore, _key);
            viewModel.Value = string.Empty;

            // Act
            bool hasErrors = viewModel.HasErrors;

            // Assert
            Assert.False(hasErrors);
        }
    }
}
