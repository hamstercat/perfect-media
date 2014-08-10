using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace PerfectMedia
{
    public class ActorMetadataTests
    {
        [Theory]
        [InlineData("Akeno Watanabe", "Akeno_Watanabe.jpg")]
        [InlineData("Akira\tIshida", "Akira_Ishida.jpg")]
        [InlineData("JeremyShada", "JeremyShada.jpg")]
        [InlineData("Hynden_Walch", "Hynden_Walch.jpg")]
        public void GetActorThumbPath_WithDifferentActorNames_ReturnsAppropriateFilePath(string actorName, string expectedFileName)
        {
            // Arrange
            const string tvShowPath = @"C:\TV Shows\Game of Thrones\";

            // Act
            string filePath = ActorMetadata.GetActorThumbPath(tvShowPath, actorName);

            // Assert
            string expectedFilePath = Path.Combine(tvShowPath, ".actors", expectedFileName);
            Assert.Equal(expectedFilePath, filePath);
        }

        [Fact]
        public void GetActorsFolder_WithTvShowFolder_ReturnsActorThmbnailsFolder()
        {
            // Arrange
            const string tvShowPath = @"C:\TV Shows\Game of Thrones\";

            // Act
            string folder = ActorMetadata.GetActorsFolder(tvShowPath);

            // Assert
            Assert.Equal(@"C:\TV Shows\Game of Thrones\.actors", folder);
        }
    }
}
