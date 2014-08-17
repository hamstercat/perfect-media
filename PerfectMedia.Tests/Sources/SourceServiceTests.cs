using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;
using Xunit.Extensions;

namespace PerfectMedia.Sources
{
    public class SourceServiceTests
    {
        private readonly ISourceRepository _sourceRepository;
        private readonly SourceService _service;

        public SourceServiceTests()
        {
            _sourceRepository = Substitute.For<ISourceRepository>();
            _service = new SourceService(_sourceRepository);
        }

        [Theory]
        [InlineData(SourceType.Movie)]
        [InlineData(SourceType.Music)]
        [InlineData(SourceType.TvShow)]
        public void GetSources_AfterInitialization_ReturnsSources(SourceType sourceType)
        {
            // Arrange
            IEnumerable<Source> expectedSources = new List<Source>
            {
                new Source(sourceType, true, @"C:\Folder1"),
                new Source(sourceType, false, @"C:\Folder2\My Folder")
            };
            _sourceRepository.GetSources(sourceType)
                .Returns(expectedSources);
            ((ILifecycleService)_service).Initialize();

            // Act
            IEnumerable<Source> sources = _service.GetSources(sourceType);

            // Assert
            Assert.Equal(expectedSources, sources);
        }
    }
}
