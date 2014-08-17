using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Progress;
using Xunit;

namespace PerfectMedia.UI.Metadata
{
    public class UpdateMetadataCommandTests
    {
        private readonly IMetadataProvider _metadataProvider;
        private readonly IProgressManagerViewModel _progressManager;
        private readonly UpdateMetadataCommand _command;
        private readonly IBusyProvider _busyProvider;

        public UpdateMetadataCommandTests()
        {
            _metadataProvider = Substitute.For<IMetadataProvider>();
            _progressManager = Substitute.For<IProgressManagerViewModel>();
            _busyProvider = Substitute.For<IBusyProvider>();
            _command = new UpdateMetadataCommand(_metadataProvider, _progressManager, _busyProvider);
        }

        [Fact]
        public void CanExecute_Always_ReturnsTrue()
        {
            // Act
            bool canExecute = _command.CanExecute(null);

            // Assert
            Assert.True(canExecute);
        }

        [Fact]
        public void Execute_Always_QueuesCallToUpdate()
        {
            // Arrange
            IEnumerable<ProgressItem> items = new List<ProgressItem> { CreateProgressItem() };
            _metadataProvider.Update()
                .Returns(items.ToTask());

            // Act
            _command.Execute(null);

            // Assert
            _progressManager.Received()
                .AddItem(Arg.Any<ProgressItem>());
            _progressManager.Received()
                .Start().Async();
        }

        private ProgressItem CreateProgressItem()
        {
            return new ProgressItem(null, null);
        }
    }
}
