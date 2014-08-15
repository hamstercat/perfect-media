using NSubstitute;
using Xunit;

namespace PerfectMedia.UI.Metadata
{
    public class SaveMetadataCommandTests
    {
        private readonly IMetadataProvider _metadataProvider;
        private readonly SaveMetadataCommand _command;

        public SaveMetadataCommandTests()
        {
            _metadataProvider = Substitute.For<IMetadataProvider>();
            _command = new SaveMetadataCommand(_metadataProvider);
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
        public void Execute_Always_SavesMetadata()
        {
            // Act
            _command.Execute(null);

            // Assert
            _metadataProvider.Received()
                .Save();
        }
    }
}
