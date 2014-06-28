using NSubstitute;
using PerfectMedia.UI.Metadata;
using Xunit;

namespace PerfectMedia.Tests.UI.Metadata
{
    public class RefreshMetadataCommandTests
    {
        private readonly IMetadataProvider _metadataProvider;
        private readonly RefreshMetadataCommand _command;

        public RefreshMetadataCommandTests()
        {
            _metadataProvider = Substitute.For<IMetadataProvider>();
            _command = new RefreshMetadataCommand(_metadataProvider);
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
        public void Execute_Always_RefreshesMetadata()
        {
            // Act
            _command.Execute(null);

            // Assert
            _metadataProvider.Received().Refresh();
        }
    }
}
