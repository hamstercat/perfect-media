using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.UI.Images.Selection
{
    public class NoImageStrategyTests
    {
        private readonly NoImageStrategy _strategy;

        public NoImageStrategyTests()
        {
            _strategy = new NoImageStrategy();
        }

        [Fact]
        public async Task FindImages_Always_ReturnsNothing()
        {
            // Act
            var images = await _strategy.FindImages();

            // Assert
            Assert.Empty(images);
        }
    }
}
