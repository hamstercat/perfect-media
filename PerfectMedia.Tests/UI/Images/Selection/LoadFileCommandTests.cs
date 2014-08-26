using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace PerfectMedia.UI.Images.Selection
{
    public class LoadFileCommandTests
    {
        private readonly LoadFileCommand _command;
        private readonly IChooseImageFileViewModel _chooseImageViewModel;

        public LoadFileCommandTests()
        {
            _chooseImageViewModel = Substitute.For<IChooseImageFileViewModel>();
            _command = new LoadFileCommand(_chooseImageViewModel);
        }

        [Fact]
        public void CanExecute_WhenUrlIsEmpty_ReturnsFalse()
        {
            // Arrange
            _chooseImageViewModel.Url
                .Returns("");

            // Act
            bool canExecute = _command.CanExecute(null);

            // Assert
            Assert.False(canExecute);
        }

        [Fact]
        public void CanExecute_WhenUrlHasValue_ReturnsTrue()
        {
            // Arrange
            _chooseImageViewModel.Url
                .Returns(@"C:\Users\Finn\Pictures\image.jpg");

            // Act
            bool canExecute = _command.CanExecute(null);

            // Assert
            Assert.True(canExecute);
        }

        [Fact]
        public void CanExecuteChanged_WhenUrlChanges_IsRaised()
        {
            // Arrange
            bool canExecuteChangedCalled = false;
            _command.CanExecuteChanged += (s, e) => canExecuteChangedCalled = true;

            // Act
            _chooseImageViewModel.PropertyChanged += Raise.Event<PropertyChangedEventHandler>(_chooseImageViewModel, new PropertyChangedEventArgs("Url"));

            // Assert
            Assert.True(canExecuteChangedCalled);
        }

        [Fact]
        public async Task ExecuteAsync_Always_DownloadFile()
        {
            // Act
            await _command.ExecuteAsync(true);

            // Assert
            _chooseImageViewModel.Received()
                .SaveLocalFile().Async();
        }
    }
}
