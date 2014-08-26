using NSubstitute;
using Xunit;

namespace PerfectMedia.UI.Metadata
{
    public class DeleteMetadataCommandTests
    {
        private readonly IMetadataProvider _metadataProvider;
        private readonly DeleteMetadataCommand _command;

        public DeleteMetadataCommandTests()
        {
            _metadataProvider = Substitute.For<IMetadataProvider>();
            _command = new DeleteMetadataCommand(_metadataProvider);
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
        public void Execute_Always_DeletesMetadata()
        {
            // Act
            _command.Execute(null);

            // Assert
            _metadataProvider.Received()
                .Delete();
        }
    }
}
