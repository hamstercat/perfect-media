using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace PerfectMedia.Movies
{
    public class MovieImagesServiceTests
    {
        private const string MoviePath = @"C:\Folder\Movies\Scott Pilgrim Vs. The World\Scott_Pilgrim_Vs_The_World.mkv";
        private const string FanartPath = @"C:\Folder\Movies\Scott Pilgrim Vs. The World\Scott_Pilgrim_Vs_The_World-fanart.jpg";
        private const string PosterPath = @"C:\Folder\Movies\Scott Pilgrim Vs. The World\Scott_Pilgrim_Vs_The_World-poster.jpg";
        private const string ImageUrl = @"http://image-site.com/scott.jpg";

        private readonly MovieImagesService _service;
        private readonly IFileSystemService _fileSystemService;

        public MovieImagesServiceTests()
        {
            _fileSystemService = Substitute.For<IFileSystemService>();
            _service = new MovieImagesService(_fileSystemService);
        }

        [Fact]
        public async Task Update_FanartExistsAndIsFound_DoesNothing()
        {
            // Act
            await UpdateMovieFanart(true, true);

            // Assert
            _fileSystemService.DidNotReceive()
                .DownloadImage(Arg.Any<string>(), Arg.Any<string>()).Async();
        }

        [Fact]
        public async Task Update_PosterExistsAndIsFound_DoesNothing()
        {
            // Act
            await UpdateMoviePoster(true, true);

            // Assert
            _fileSystemService.DidNotReceive()
                .DownloadImage(Arg.Any<string>(), Arg.Any<string>()).Async();
        }

        [Fact]
        public async Task Update_FanartDoesntExistAndIsFound_DownloadsIt()
        {
            // Act
            await UpdateMovieFanart(false, true);

            // Assert
            _fileSystemService.Received()
                .DownloadImage(FanartPath, ImageUrl).Async();
        }

        [Fact]
        public async Task Update_PosterDoesntExistAndIsFound_DownloadsIt()
        {
            // Act
            await UpdateMoviePoster(false, true);

            // Assert
            _fileSystemService.Received()
                .DownloadImage(PosterPath, ImageUrl).Async();
        }

        [Fact]
        public async Task Update_FanartDoesntExistAndIsNotFound_DoesNothing()
        {
            // Act
            await UpdateMovieFanart(false, false);

            // Assert
            _fileSystemService.DidNotReceive()
                .DownloadImage(Arg.Any<string>(), Arg.Any<string>()).Async();
        }

        [Fact]
        public async Task Update_PosterDoesntExistAndIsNotFound_DoesNothing()
        {
            // Act
            await UpdateMoviePoster(false, false);

            // Assert
            _fileSystemService.DidNotReceive()
                .DownloadImage(Arg.Any<string>(), Arg.Any<string>()).Async();
        }

        [Fact]
        public async Task Delete_Always_DeletesPosterFile()
        {
            // Act
            await _service.Delete(MoviePath);

            // Arrange
            _fileSystemService.Received()
                .DeleteFile(PosterPath).Async();
        }

        [Fact]
        public async Task Delete_Always_DeletesFanartFile()
        {
            // Act
            await _service.Delete(MoviePath);

            // Arrange
            _fileSystemService.Received()
                .DeleteFile(FanartPath).Async();
        }

        private async Task UpdateMovieFanart(bool fileExists, bool imageIsFound)
        {
            // Arrange
            _fileSystemService.FileExists(FanartPath)
                .Returns(Task.FromResult(fileExists));
            FullMovie movie = new FullMovie();
            if (imageIsFound)
            {
                movie.BackdropPath = ImageUrl;
            }

            // Act
            await _service.Update(MoviePath, movie);
        }

        private async Task UpdateMoviePoster(bool fileExists, bool imageIsFound)
        {
            // Arrange
            _fileSystemService.FileExists(PosterPath)
                .Returns(Task.FromResult(fileExists));
            FullMovie movie = new FullMovie();
            if (imageIsFound)
            {
                movie.PosterPath = ImageUrl;
            }

            // Act
            await _service.Update(MoviePath, movie);
        }
    }
}
