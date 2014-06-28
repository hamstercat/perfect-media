using PerfectMedia.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace PerfectMedia.Tests.UI.TvShows
{
    public class DashDelimitedCollectionViewModelTests
    {
        private readonly DashDelimitedCollectionViewModel<int> _viewModel;

        public DashDelimitedCollectionViewModelTests()
        {
            _viewModel = new DashDelimitedCollectionViewModel<int>(int.Parse);
        }

        [Theory]
        [InlineData("7 / 12 / 42 / 1984", 7, 12, 42, 1984)]
        [InlineData("94 / 56 / 74", 94, 56, 74, null)]
        [InlineData("", null, null, null, null)]
        public void Collection_WhenItemsAreAdded_ModifiesString(string expectedString, int? i1, int? i2, int? i3, int? i4)
        {
            // Arrange
            List<int?> collection = new List<int?> { i1, i2, i3, i4 };

            // Act
            foreach (int i in collection.Where(i => i.HasValue))
            {
                _viewModel.Collection.Add(i);
            }

            // Assert
            Assert.Equal(expectedString, _viewModel.String);
        }

        [Fact]
        public void Collection_WhenItemsAreAdded_NotifyStringChanged()
        {
            // Arrange
            bool stringChanged = false;
            _viewModel.PropertyChanged += (s, e) => stringChanged = e.PropertyName == "String";

            // Act
            _viewModel.Collection.Add(42);

            // Assert
            Assert.True(stringChanged);
        }

        [Theory]
        [InlineData("7/12 / 42 / 1984", 7, 12, 42, 1984)]
        [InlineData("94/56/74", 94, 56, 74, null)]
        [InlineData("", null, null, null, null)]
        public void String_WhenItemsAreAdded_ModifiesString(string str, int? i1, int? i2, int? i3, int? i4)
        {
            // Arrange
            IEnumerable<int> expectedCollection = new List<int?> { i1, i2, i3, i4 }
                .Where(i => i.HasValue)
                .Select(i => i.Value);

            // Act
            _viewModel.String = str;

            // Assert
            Assert.Equal(expectedCollection, _viewModel.Collection);
        }

        [Fact]
        public void String_WhenSettingAnEmptyString_ClearsCollection()
        {
            // Arrange
            _viewModel.Collection.Add(54);

            // Act
            _viewModel.String = string.Empty;

            // Assert
            Assert.Empty(_viewModel.Collection);
        }
    }
}
