using System;
using Xunit;

namespace PerfectMedia.UI
{
    // We're testing protected methods here, but they are used by the UI so they better work
    public class BaseViewModelTests
    {
        private readonly BaseViewModelExtended _viewModel;

        public BaseViewModelTests()
        {
            _viewModel = new BaseViewModelExtended();
        }

        [Fact]
        public void OnPropertyChanged_WithExistingProperty_RaisesPropertyChangedEvent()
        {
            // Arrange
            string raisedPropertyName = null;
            _viewModel.PropertyChanged += (s, e) => raisedPropertyName = e.PropertyName;

            // Act
            _viewModel.CallOnPropertyChanged("MyProperty");

            // Assert
            Assert.Equal("MyProperty", raisedPropertyName);
        }

        [Fact]
        public void OnPropertyChanged_InDebugWithUnknownProperty_ThrowsArgumentException()
        {
#if DEBUG
            // Act + Assert
            Assert.Throws<ArgumentException>(() => _viewModel.CallOnPropertyChanged("Banana"));
#endif
        }

        private class BaseViewModelExtended : BaseViewModel
        {
            public string MyProperty { get; set; }

            public void CallOnPropertyChanged(string propertyName)
            {
                OnPropertyChanged(propertyName);
            }
        }
    }
}
