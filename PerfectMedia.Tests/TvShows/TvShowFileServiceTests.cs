using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace PerfectMedia.TvShows
{
    public class TvShowFileServiceTests
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly TvShowFileService _service;

        public TvShowFileServiceTests()
        {
            _fileSystemService = Substitute.For<IFileSystemService>();
            _service = new TvShowFileService(_fileSystemService);
        }

        [Fact]
        public void GetShowImages_Always_CalculatesTheShowMainImagePaths()
        {
            // Arrange
            string path = @"C:\Folder\TV Shows\Game of Thrones";

            // Act
            TvShowImages images = _service.GetShowImages(path);

            // Assert
            Assert.Equal(@"C:\Folder\TV Shows\Game of Thrones\fanart.jpg", images.Fanart);
            Assert.Equal(@"C:\Folder\TV Shows\Game of Thrones\poster.jpg", images.Poster);
            Assert.Equal(@"C:\Folder\TV Shows\Game of Thrones\banner.jpg", images.Banner);
        }

        [Theory]
        [InlineData("Specials", 0, @"C:\Folder\TV Shows\Game of Thrones\season-specials-")]
        [InlineData("Season 1", 1, @"C:\Folder\TV Shows\Game of Thrones\season01-")]
        [InlineData("Season 39", 39, @"C:\Folder\TV Shows\Game of Thrones\season39-")]
        public void GetSeason_WithValidFolderName_ExtractsTheCorrectSeasonNumber(string seasonFolder, int expectedSeasonNumber, string imagePath)
        {
            // Arrange
            string path = @"C:\Folder\TV Shows\Game of Thrones";

            // Act
            Season season = _service.GetSeason(path, seasonFolder);

            // Assert
            Assert.Equal(expectedSeasonNumber, season.SeasonNumber);
            Assert.Equal(imagePath + "poster.jpg", season.PosterUrl);
            Assert.Equal(imagePath + "banner.jpg", season.BannerUrl);
        }

        [Fact]
        public void GetSeasons_WithFolders_ReturnsSeasons()
        {
            // Arrange
            string path = @"C:\Folder";
            List<string> seasonFolders = new List<string>
            {
                @"C:\Folder\Season 1",
                @"C:\Folder\Season 2",
                @"C:\Folder\Specials"
            };
            _fileSystemService.FindDirectories(path, "Season *")
                .Returns(seasonFolders.Take(2));
            _fileSystemService.FindDirectories(path, "Special*")
                .Returns(seasonFolders.Skip(2));

            // Act
            IEnumerable<Season> seasons = _service.GetSeasons(path);

            // Assert
            IEnumerable<string> actualSeasonFolders = seasons.Select(s => s.Path);
            Assert.Equal(seasonFolders.Count, actualSeasonFolders.Count());
            // Seasons are sorted by season number
            Assert.Equal(seasonFolders[0], actualSeasonFolders.ElementAt(1));
            Assert.Equal(seasonFolders[1], actualSeasonFolders.ElementAt(2));
            Assert.Equal(seasonFolders[2], actualSeasonFolders.ElementAt(0));
        }

        [Fact]
        public void GetSeasons_WithoutFolders_ReturnsEmpty()
        {
            // Act
            IEnumerable<Season> seasons = _service.GetSeasons(@"C:\Folder");

            // Assert
            Assert.NotNull(seasons);
            Assert.False(seasons.Any());
        }

        [Fact]
        public void GetSeasons_EmptyPath_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                // Method returns an IEnumerable, enumerate it so the method executes
                _service.GetSeasons(null).ToList();
            });
        }

        [Fact]
        public void GetEpisodes_WithFolders_ReturnsEpisodes()
        {
            // Arrange
            string path = @"C:\Folder\Season 1";
            List<string> episodeFolders = new List<string>
            {
                @"C:\Folder\Season 1\1x02.mkv",
                @"C:\Folder\Season 1\1x01.mkv",
                @"C:\Folder\Season 1\1x03.mkv"
            };
            _fileSystemService.FindVideoFiles(path)
                .Returns(episodeFolders);

            // Act
            IEnumerable<Episode> episodes = _service.GetEpisodes(path);

            // Assert
            IEnumerable<string> actualEpisodeFolders = episodes.Select(s => s.Path);
            Assert.Equal(episodeFolders.Count, actualEpisodeFolders.Count());
            // Episodes are sorted by season number / episode number
            Assert.Equal(episodeFolders[0], actualEpisodeFolders.ElementAt(1));
            Assert.Equal(episodeFolders[1], actualEpisodeFolders.ElementAt(0));
            Assert.Equal(episodeFolders[2], actualEpisodeFolders.ElementAt(2));
        }

        [Fact]
        public void GetEpisodes_WithoutFolders_ReturnsEmpty()
        {
            // Act
            IEnumerable<Episode> episodes = _service.GetEpisodes(@"C:\Folder");

            // Assert
            Assert.NotNull(episodes);
            Assert.False(episodes.Any());
        }

        [Fact]
        public void GetEpisodes_EmptyPath_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                // Method returns an IEnumerable, enumerate it so the method executes
                _service.GetEpisodes(null).ToList();
            });
        }
    }
}
