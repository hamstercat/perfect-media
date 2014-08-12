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
        public void Update_FanartExistsAndIsFound_DoesNothing()
        {
            // Act
            UpdateMovieFanart(true, true);

            // Assert
            _fileSystemService.DidNotReceive()
                .DownloadImage(Arg.Any<string>(), Arg.Any<string>());
        }

        [Fact]
        public void Update_PosterExistsAndIsFound_DoesNothing()
        {
            // Act
            UpdateMoviePoster(true, true);

            // Assert
            _fileSystemService.DidNotReceive()
                .DownloadImage(Arg.Any<string>(), Arg.Any<string>());
        }

        [Fact]
        public void Update_FanartDoesntExistAndIsFound_DownloadsIt()
        {
            // Act
            UpdateMovieFanart(false, true);

            // Assert
            _fileSystemService.Received()
                .DownloadImage(FanartPath, ImageUrl);
        }

        [Fact]
        public void Update_PosterDoesntExistAndIsFound_DownloadsIt()
        {
            // Act
            UpdateMoviePoster(false, true);

            // Assert
            _fileSystemService.Received()
                .DownloadImage(PosterPath, ImageUrl);
        }

        [Fact]
        public void Update_FanartDoesntExistAndIsNotFound_DoesNothing()
        {
            // Act
            UpdateMovieFanart(false, false);

            // Assert
            _fileSystemService.DidNotReceive()
                .DownloadImage(Arg.Any<string>(), Arg.Any<string>());
        }

        [Fact]
        public void Update_PosterDoesntExistAndIsNotFound_DoesNothing()
        {
            // Act
            UpdateMoviePoster(false, false);

            // Assert
            _fileSystemService.DidNotReceive()
                .DownloadImage(Arg.Any<string>(), Arg.Any<string>());
        }

        [Fact]
        public void Delete_Always_DeletesPosterFile()
        {
            // Act
            _service.Delete(MoviePath);

            // Arrange
            _fileSystemService.Received()
                .DeleteFile(PosterPath);
        }

        [Fact]
        public void Delete_Always_DeletesFanartFile()
        {
            // Act
            _service.Delete(MoviePath);

            // Arrange
            _fileSystemService.Received()
                .DeleteFile(FanartPath);
        }

        private void UpdateMovieFanart(bool fileExists, bool imageIsFound)
        {
            // Arrange
            _fileSystemService.FileExists(FanartPath)
                .Returns(fileExists);
            FullMovie movie = new FullMovie();
            if (imageIsFound)
            {
                movie.BackdropPath = ImageUrl;
            }

            // Act
            _service.Update(MoviePath, movie);
        }

        private void UpdateMoviePoster(bool fileExists, bool imageIsFound)
        {
            // Arrange
            _fileSystemService.FileExists(PosterPath)
                .Returns(fileExists);
            FullMovie movie = new FullMovie();
            if (imageIsFound)
            {
                movie.PosterPath = ImageUrl;
            }

            // Act
            _service.Update(MoviePath, movie);
        }
    }
}
