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
        public async Task GetSources_Always_ReturnsSources(SourceType sourceType)
        {
            // Arrange
            IEnumerable<Source> expectedSources = new List<Source>
            {
                new Source(sourceType, true, @"C:\Folder1"),
                new Source(sourceType, false, @"C:\Folder2\My Folder")
            };
            _sourceRepository.GetSources(sourceType)
                .Returns(Task.FromResult(expectedSources));

            // Act
            IEnumerable<Source> sources = await _service.GetSources(sourceType);

            // Assert
            Assert.Equal(expectedSources, sources);
        }

        [Theory]
        [InlineData(SourceType.Movie)]
        [InlineData(SourceType.Music)]
        [InlineData(SourceType.TvShow)]
        public void Save_Always_PersistSource(SourceType sourceType)
        {
            // Arrange
            Source source = new Source(sourceType, false, @"C:\Folder2\My Folder");

            // Act
            _service.Save(source);

            // Assert
            _sourceRepository.Received()
                .Save(source);
        }

        [Theory]
        [InlineData(SourceType.Movie)]
        [InlineData(SourceType.Music)]
        [InlineData(SourceType.TvShow)]
        public async Task Delete_Always_PersistSource(SourceType sourceType)
        {
            // Arrange
            Source source = new Source(sourceType, false, @"C:\Folder2\My Folder");

            // Act
            await _service.Delete(source);

            // Assert
            _sourceRepository.Received()
                .Delete(source).Async();
        }
    }
}
