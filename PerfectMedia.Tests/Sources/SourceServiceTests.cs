using NSubstitute;
using PerfectMedia.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace PerfectMedia.Tests.Sources
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
        public void GetSources_Always_ReturnsSources(SourceType sourceType)
        {
            // Arrange
            List<Source> expectedSources = new List<Source>
            {
                new Source(sourceType, true, @"C:\Folder1"),
                new Source(sourceType, false, @"C:\Folder2\My Folder")
            };
            _sourceRepository.GetSources(sourceType)
                .Returns(expectedSources);

            // Act
            IEnumerable<Source> sources = _service.GetSources(sourceType);

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
        public void Delete_Always_PersistSource(SourceType sourceType)
        {
            // Arrange
            Source source = new Source(sourceType, false, @"C:\Folder2\My Folder");

            // Act
            _service.Delete(source);

            // Assert
            _sourceRepository.Received()
                .Delete(source);
        }
    }
}
