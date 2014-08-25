using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace PerfectMedia.UI.Cache
{
    public class IntCachedPropertyViewModelTests
    {
        private IntCachedPropertyViewModel _viewModel;
        private readonly IKeyDataStore _keyDataStore;
        private readonly string _key;

        public IntCachedPropertyViewModelTests()
        {
            _keyDataStore = Substitute.For<IKeyDataStore>();
            _key = @"C:\Folder\TV Shows\Adventure Time\Season 1\1x01.mkv?episodeNumber";
            _viewModel = new IntCachedPropertyViewModel(_keyDataStore, _key, true);
        }

        [Fact]
        public void Constructor_WhenValueIsntCached_DoesntSetValue()
        {
            // Assert
            Assert.Null(_viewModel.Value);
        }

        [Fact]
        public void Constructor_WhenValueIsCached_ParsesTheValueIntoAnInt()
        {
            // Arrange
            _keyDataStore.GetValue(_key)
                .Returns("1");

            // Act
            _viewModel = new IntCachedPropertyViewModel(_keyDataStore, _key, true);

            // Assert
            Assert.Equal(1, _viewModel.Value);
        }

        [Fact]
        public void Save_WhenNoValueIsSet_SavesEmptyStringInTheCache()
        {
            // Act
            _viewModel.Save();

            // Assert
            _keyDataStore.Received()
                .SetValue(_key, Arg.Is<string>(value => string.IsNullOrEmpty(value)));
        }

        [Fact]
        public void Save_WhenValueIsSet_SavesTheCorrectStringInTheCache()
        {
            // Arrange
            _viewModel.Value = 42;

            // Act
            _viewModel.Save();

            // Assert
            _keyDataStore.Received()
                .SetValue(_key, "42");
        }
    }
}
