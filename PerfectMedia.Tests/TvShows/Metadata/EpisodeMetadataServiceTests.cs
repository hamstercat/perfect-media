using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nito.AsyncEx.Synchronous;
using NSubstitute;
using PerfectMedia.FileInformation;
using Xunit;

namespace PerfectMedia.TvShows.Metadata
{
    public class EpisodeMetadataServiceTests
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IEpisodeMetadataRepository _metadataRepository;
        private readonly ITvShowMetadataUpdater _metadataUpdater;
        private readonly IFileInformationService _fileInformationService;
        private readonly string _path;
        private readonly EpisodeMetadataService _service;

        public EpisodeMetadataServiceTests()
        {
            _fileSystemService = Substitute.For<IFileSystemService>();
            _metadataRepository = Substitute.For<IEpisodeMetadataRepository>();
            _metadataUpdater = Substitute.For<ITvShowMetadataUpdater>();
            _fileInformationService = Substitute.For<IFileInformationService>();
            _path = @"C:\Folder\TV Shows\Game of Thrones\Season 3\3x09.mkv";
            _service = new EpisodeMetadataService(_fileSystemService, _metadataRepository, _metadataUpdater, _fileInformationService);
        }

        [Fact]
        public async Task Get_Always_ReturnsMetadata()
        {
            // Arrange
            EpisodeMetadata expectedMetadata = new EpisodeMetadata();
            _metadataRepository.Get(_path)
                .Returns(Task.FromResult(expectedMetadata));

            // Act
            EpisodeMetadata metadata = await _service.Get(_path);

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

        [Fact]
        public async Task Update_SpecialEpisode_ShouldSaveMetadata()
        {
            // Arrange
            const string path = @"C:\Folder\TV Shows\Game of Thrones\Specials\0x02.mkv";
            EpisodeMetadata metadata = CreateEpisodeMetadata(0, "Specials");

            _metadataUpdater.GetEpisodeMetadata("123", 0, 2)
                .Returns(metadata.ToTask());

            _fileInformationService.GetVideoFileInformation(path)
                .Returns(CreateFileInformation());

            // Act
            await _service.Update(path, "123");

            // Assert
            EpisodeMetadata expectedMetadata = CreateEpisodeMetadataWithFileInformation(0, "Specials");
            _metadataRepository.Received()
                .Save(path, Arg.Is<EpisodeMetadata>(m => m == expectedMetadata)).Async();
        }

        [Fact]
        public async Task Update_EpisodeFromSeason3_ShouldSaveMetadata()
        {
            // Arrange
            const string path = @"C:\Folder\TV Shows\Game of Thrones\Specials\3x02.mkv";
            EpisodeMetadata metadata = CreateEpisodeMetadata(3, "Season 3");

            _metadataUpdater.GetEpisodeMetadata("123", 3, 2)
                .Returns(metadata.ToTask());

            _fileInformationService.GetVideoFileInformation(path)
                .Returns(CreateFileInformation());

            // Act
            await _service.Update(path, "123");

            // Assert
            EpisodeMetadata expectedMetadata = CreateEpisodeMetadataWithFileInformation(3, "Season 3");
            _metadataRepository.Received()
                .Save(path, Arg.Is<EpisodeMetadata>(m => m == expectedMetadata)).Async();
        }

        [Fact]
        public void Update_WhenNoMetadataIsFound_ThrowsException()
        {
            // Arrange
            _metadataUpdater.GetEpisodeMetadata("234", 3, 9)
                .Returns(x => { throw new ApiException(); });

            // Act + Assert
            Assert.Throws<EpisodeNotFoundException>(() => _service.Update(_path, "234").WaitAndUnwrapException());
        }

        [Fact]
        public async Task Delete_Always_DeleteMetadata()
        {
            // Act
            await _service.Delete(_path);

            // Assert
            _metadataRepository.Received()
                .Delete(_path).Async();
        }

        private EpisodeMetadata CreateEpisodeMetadata(int seasonNumber, string seasonFolder)
        {
            return new EpisodeMetadata
            {
                AiredDate = new DateTime(2012, 06, 27),
                Credits = new List<string> { "Writer #1", "Writer #2" },
                Director = new List<string> { "Director #1", "Director #2" },
                DisplayEpisode = 56,
                DisplaySeason = 1,
                EpisodeBookmarks = 23.4,
                EpisodeNumber = 2,
                ImagePath = string.Format(@"C:\Folder\TV Shows\Game of Thrones\{0}\{1}x02-thumb.png", seasonFolder, seasonNumber),
                ImageUrl = "http://thetvdb.com/banners/image.jpg",
                LastPlayed = new DateTime(2013, 08, 13),
                PlayCount = 3,
                Plot = "The best plot ever",
                Rating = 8.7,
                SeasonNumber = seasonNumber,
                Title = "Game of Thrones"
            };
        }

        private EpisodeMetadata CreateEpisodeMetadataWithFileInformation(int seasonNumber, string seasonFolder)
        {
            EpisodeMetadata metadata = CreateEpisodeMetadata(seasonNumber, seasonFolder);
            metadata.FileInformation = CreateFileInformation();
            return metadata;
        }

        private VideoFileInformation CreateFileInformation()
        {
            return new VideoFileInformation
            {
                StreamDetails = new StreamDetails
                {
                    Audios = new List<Audio>
                    {
                        new Audio
                        {
                            Codec = "MP3",
                            Language = "eng",
                            NumberOfChannels = 2
                        }
                    },
                    Videos = new List<Video>
                    {
                        new Video
                        {
                            Aspect = "1.8777",
                            Codec = "h264",
                            DurationInSeconds = 1427,
                            Height = 1080,
                            Language = "eng",
                            LongLanguage = "English",
                            ScanType = "Progressive",
                            Width = 1920
                        }
                    }
                }
            };
        }
    }
}
