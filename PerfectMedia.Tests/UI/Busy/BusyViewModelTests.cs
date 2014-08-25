using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.UI.Busy
{
    public class BusyViewModelTests
    {
        private readonly BusyViewModel _viewModel;

        public BusyViewModelTests()
        {
            _viewModel = new BusyViewModel();
        }

        [Fact]
        public void Constructor_RightAfterCreation_StartsBusy()
        {
            // Assert
            Assert.False(_viewModel.IsBusy);
        }

        [Fact]
        public void DoWork_WhenNotBusy_BecomesBusy()
        {
            // Act
            _viewModel.DoWork();

            // Assert
            Assert.True(_viewModel.IsBusy);
        }

        [Fact]
        public void DoWork_WhenAlreadyBusy_StaysBusy()
        {
            // Arrange
            _viewModel.DoWork();

            // Act
            _viewModel.DoWork();

            // Assert
            Assert.True(_viewModel.IsBusy);
        }

        [Fact]
        public void DisposeDoWork_WhenDoWorkWasCalledOnce_BecomesNotBusy()
        {
            // Arrange
            IDisposable disposable = _viewModel.DoWork();

            // Act
            disposable.Dispose();

            // Assert
            Assert.False(_viewModel.IsBusy);
        }

        [Fact]
        public void DisposeDoWork_WhenDoWorkWasCalledTwice_StaysBusy()
        {
            // Arrange
            IDisposable disposable = _viewModel.DoWork();
            _viewModel.DoWork();

            // Act
            disposable.Dispose();

            // Assert
            Assert.True(_viewModel.IsBusy);
        }

        [Fact]
        public void DisposeDoWorkTwice_WhenDoWorkWasCalledTwice_BecomesNotBusy()
        {
            // Arrange
            IDisposable disposable1 = _viewModel.DoWork();
            IDisposable disposable2 = _viewModel.DoWork();

            // Act
            disposable1.Dispose();
            disposable2.Dispose();

            // Assert
            Assert.False(_viewModel.IsBusy);
        }

        [Fact]
        public void Dispose_WhenCalledTwice_ThrowsException()
        {
            // Arrange
            IDisposable disposable = _viewModel.DoWork();
            disposable.Dispose();

            // Act + Assert
            Assert.Throws<InvalidOperationException>(() => disposable.Dispose());
        }
    }
}
