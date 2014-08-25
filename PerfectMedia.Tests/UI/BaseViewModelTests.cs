using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using NSubstitute;
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

        [Fact]
        public void OnPropertyChanged_WithExistingProperty_ValidatesThatProperty()
        {
            // Act
            _viewModel.CallOnPropertyChanged("RequiredProperty");

            // Assert
            Assert.True(_viewModel.HasErrors);
        }

        [Fact]
        public void OnPropertyChanged_WithExistingProperty_RaisesErrorsChangedEvent()
        {
            // Arrange
            string raisedPropertyName = null;
            _viewModel.ErrorsChanged += (s, e) => raisedPropertyName = e.PropertyName;

            // Act
            _viewModel.CallOnPropertyChanged("RequiredProperty");

            // Assert
            Assert.Equal("RequiredProperty", raisedPropertyName);
        }

        [Fact]
        public void HasErrors_WhenRequiredFieldIsMissing_ReturnsTrue()
        {
            // Arrange
            _viewModel.CallOnPropertyChanged("RequiredProperty");

            // Act
            bool hasErrors = _viewModel.HasErrors;

            // Assert
            Assert.True(hasErrors);
        }

        [Fact]
        public void HasErrors_WhenNoRequiredFieldAreMissing_ReturnsFalse()
        {
            // Arrange
            _viewModel.RequiredProperty = "Dinosaur";
            _viewModel.CallOnPropertyChanged("RequiredProperty");

            // Act
            bool hasErrors = _viewModel.HasErrors;

            // Assert
            Assert.False(hasErrors);
        }

        [Fact]
        public void GetErrors_WhenRequiredFieldIsMissing_ReturnsRequiredFieldMessage()
        {
            // Arrange
            _viewModel.CallOnPropertyChanged("RequiredProperty");

            // Act
            IEnumerable errors = _viewModel.GetErrors("RequiredProperty");

            // Assert
            Assert.NotEmpty(errors);
        }

        [Fact]
        public void GetErrors_WhenNoRequiredFieldAreMissing_ReturnsNothing()
        {
            // Arrange
            _viewModel.RequiredProperty = "Dinosaur";
            _viewModel.CallOnPropertyChanged("RequiredProperty");

            // Act
            IEnumerable errors = _viewModel.GetErrors("RequiredProperty");

            // Assert
            Assert.Empty(errors);
        }

        private class BaseViewModelExtended : BaseViewModel
        {
            public string MyProperty { get; set; }

            [Required]
            public string RequiredProperty { get; set; }

            public void CallOnPropertyChanged(string propertyName)
            {
                OnPropertyChanged(propertyName);
            }
        }
    }
}
