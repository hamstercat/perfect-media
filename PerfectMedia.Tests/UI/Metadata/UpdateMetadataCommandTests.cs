using NSubstitute;
using PerfectMedia.UI.Metadata;
using Xunit;

namespace PerfectMedia.Tests.UI.Metadata
{
    public class UpdateMetadataCommandTests
    {
        private readonly IMetadataProvider _metadataProvider;
        private readonly UpdateMetadataCommand _command;

        public UpdateMetadataCommandTests()
        {
            _metadataProvider = Substitute.For<IMetadataProvider>();
            _command = new UpdateMetadataCommand(_metadataProvider);
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
        public void Execute_Always_UpdatesMetadata()
        {
            // Act
            _command.Execute(null);

            // Assert
            _metadataProvider.Received().Update();
        }
    }
}
