using NSubstitute;
using PerfectMedia.UI.Progress;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.UI.Metadata
{
    public class UpdateMetadataCommandTests
    {
        private readonly IMetadataProvider _metadataProvider;
        private readonly IProgressManagerViewModel _progressManager;
        private readonly UpdateMetadataCommand _command;

        public UpdateMetadataCommandTests()
        {
            _metadataProvider = Substitute.For<IMetadataProvider>();
            _progressManager = Substitute.For<IProgressManagerViewModel>();
            _command = new UpdateMetadataCommand(_metadataProvider, _progressManager);
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
            _metadataProvider.Update()
                .Returns(new List<ProgressItem> { CreateProgressItem() });

            // Act
            _command.Execute(null);

            // Assert
            _progressManager.Received()
                .AddItem(Arg.Any<ProgressItem>());
            _progressManager.Received()
                .Start();
        }

        private ProgressItem CreateProgressItem()
        {
            Lazy<string> displayName = new Lazy<string>(() => "Dinosaur");
            Task task = new Task(() =>
            {
                throw new Exception();
            });
            return new ProgressItem(null, null);
        }
    }
}
