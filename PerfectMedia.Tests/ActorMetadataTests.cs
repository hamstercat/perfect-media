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
        [InlineData("", "")]
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
    }
}
