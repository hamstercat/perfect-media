using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.UI.Progress
{
    public class ProgressIndicatorFactoryTests
    {
        private readonly ProgressIndicatorFactory _factory;

        public ProgressIndicatorFactoryTests()
        {
            _factory = new ProgressIndicatorFactory();
        }

        [Fact]
        public void CreateProgressIndicator_Always_ReturnsSomething()
        {
            // Act
            IProgressIndicator progressIndicator = _factory.CreateProgressIndicator();

            // Assert
            Assert.NotNull(progressIndicator);
        }
    }
}
