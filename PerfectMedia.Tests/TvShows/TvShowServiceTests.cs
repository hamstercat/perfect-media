using NSubstitute;
using PerfectMedia.TvShows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.Tests.TvShows
{
    public class TvShowServiceTests
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly TvShowFileService _service;

        public TvShowServiceTests()
        {
            _fileSystemService = Substitute.For<IFileSystemService>();
            _service = new TvShowFileService(_fileSystemService);
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

            // Act
            IEnumerable<Season> seasons = _service.GetSeasons(path);

            // Assert
            IEnumerable<string> actualSeasonFolders = seasons.Select(s => s.Path);
            Assert.Equal(seasonFolders, actualSeasonFolders);
        }

        [Fact]
        public void GetSeasons_WithoutFolders_ReturnsEmpty()
        {
            // Arrange

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
                @"C:\Folder\Season 1\0x01.mkv",
                @"C:\Folder\Season 1\0x02.mkv",
                @"C:\Folder\Season 1\0x03.mkv"
            };

            // Act
            IEnumerable<Episode> episodes = _service.GetEpisodes(path);

            // Assert
            IEnumerable<string> actualEpisodeFolders = episodes.Select(s => s.Path);
            Assert.Equal(episodeFolders, actualEpisodeFolders);
        }

        [Fact]
        public void GetEpisodes_WithoutFolders_ReturnsEmpty()
        {
            // Arrange

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
