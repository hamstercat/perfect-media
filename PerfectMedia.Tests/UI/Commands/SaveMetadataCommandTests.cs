using NSubstitute;
using PerfectMedia.UI.ViewModels;
using PerfectMedia.UI.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.Tests.UI.Commands
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
            _metadataProvider.Received().Save();
        }
    }
}
