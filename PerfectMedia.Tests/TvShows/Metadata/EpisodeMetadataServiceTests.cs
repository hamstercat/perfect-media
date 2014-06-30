using NSubstitute;
using PerfectMedia.FileInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.TvShows.Metadata
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

        [Fact]
        public void Update_SpecialEpisode_ShouldSaveMetadata()
        {
            // Arrange
            string path = @"C:\Folder\TV Shows\Game of Thrones\Specials\0x02.mkv";
            EpisodeMetadata metadata = CreateEpisodeMetadata(0, "Specials");

            _tvShowMetadataService.Get(@"C:\Folder\TV Shows\Game of Thrones")
                .Returns(new TvShowMetadata { Id = "123" });

            _metadataUpdater.GetEpisodeMetadata("123", 0, 2)
                .Returns(metadata);

            _fileInformationService.GetVideoFileInformation(path)
                .Returns(CreateFileInformation());

            // Act
            _service.Update(path);

            // Assert
            EpisodeMetadata expectedMetadata = CreateEpisodeMetadataWithFileInformation(0, "Specials");
            _metadataRepository.Received()
                .Save(path, Arg.Is<EpisodeMetadata>(m => m == expectedMetadata));
        }

        [Fact]
        public void Update_EpisodeFromSeason3_ShouldSaveMetadata()
        {
            // Arrange
            string path = @"C:\Folder\TV Shows\Game of Thrones\Specials\3x02.mkv";
            EpisodeMetadata metadata = CreateEpisodeMetadata(3, "Season 3");

            _tvShowMetadataService.Get(@"C:\Folder\TV Shows\Game of Thrones")
                .Returns(new TvShowMetadata { Id = "123" });

            _metadataUpdater.GetEpisodeMetadata("123", 3, 2)
                .Returns(metadata);

            _fileInformationService.GetVideoFileInformation(path)
                .Returns(CreateFileInformation());

            // Act
            _service.Update(path);

            // Assert
            EpisodeMetadata expectedMetadata = CreateEpisodeMetadataWithFileInformation(3, "Season 3");
            _metadataRepository.Received()
                .Save(path, Arg.Is<EpisodeMetadata>(m => m == expectedMetadata));
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
                Playcount = 3,
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
