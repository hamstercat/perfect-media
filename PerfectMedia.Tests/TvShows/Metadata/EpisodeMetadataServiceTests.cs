using NSubstitute;
using PerfectMedia.FileInformation;
using PerfectMedia.TvShows.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.Tests.TvShows.Metadata
{
    public class EpisodeMetadataServiceTests
    {
        private readonly IEpisodeMetadataRepository _metadataRepository;
        private readonly ITvShowMetadataUpdater _metadataUpdater;
        private readonly ITvShowMetadataService _tvShowMetadataService;
        private readonly IFileInformationService _fileInformationService;
        private readonly string _path;
        private readonly EpisodeMetadataService _service;

        public EpisodeMetadataServiceTests()
        {
            _metadataRepository = Substitute.For<IEpisodeMetadataRepository>();
            _metadataUpdater = Substitute.For<ITvShowMetadataUpdater>();
            _tvShowMetadataService = Substitute.For<ITvShowMetadataService>();
            _fileInformationService = Substitute.For<IFileInformationService>();
            _path = @"C:\Folder\TV Shows\Game of Thrones\Season 3\3x09.mkv";
            _service = new EpisodeMetadataService(_metadataRepository, _metadataUpdater, _tvShowMetadataService, _fileInformationService);
        }

        [Fact]
        public void Get_Always_ReturnsMetadata()
        {
            // Arrange
            EpisodeMetadata expectedMetadata = new EpisodeMetadata();
            _metadataRepository.Get(_path)
                .Returns(expectedMetadata);

            // Act
            EpisodeMetadata metadata = _service.Get(_path);

            // Assert
            Assert.Equal(expectedMetadata, metadata);
        }

        [Fact]
        public void Save_Always_PersistMetadata()
        {
            // Arrange
            EpisodeMetadata metadata = new EpisodeMetadata();

            // Act
            _service.Save(_path, metadata);

            // Assert
            _metadataRepository.Received()
                .Save(_path, metadata);
        }

        [Fact(Skip = "Not implemented")]
        public void Update_SpecialEpisode_ShouldSaveMetadata()
        {
            // Arrange
            EpisodeMetadata metadata = new EpisodeMetadata
            {

            };

            // Act
            _service.Update(_path);

            // Assert
            _metadataRepository.Received()
                .Save(_path, metadata);
        }

        [Fact(Skip = "Not implemented")]
        public void Update_EpisodeFromSeason3_ShouldSaveMetadata()
        {
            // Arrange
            EpisodeMetadata metadata = new EpisodeMetadata
            {

            };

            // Act
            _service.Update(_path);

            // Assert
            _metadataRepository.Received()
                .Save(_path, metadata);
        }

        [Fact]
        public void Delete_Always_DeleteMetadata()
        {
            // Act
            _service.Delete(_path);

            // Assert
            _metadataRepository.Received()
                .Delete(_path);
        }
    }
}
