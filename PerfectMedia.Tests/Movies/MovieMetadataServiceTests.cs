using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using PerfectMedia.FileInformation;
using Xunit;

namespace PerfectMedia.Movies
{
    public class MovieMetadataServiceTests
    {
        private const string MovieFile = @"C:\Folder\Movies\Scott Pilgrim Vs. The World\Scott_Pilgrim_Vs_The_World.mkv";

        private readonly MovieMetadataService _service;
        private readonly IFileSystemService _fileSystemService;
        private readonly IMovieMetadataRepository _metadataRepository;
        private readonly IMovieMetadataUpdater _metadataUpdater;
        private readonly IMovieSynopsisService _synopsisService;
        private readonly IMovieImagesService _imagesService;
        private readonly IFileInformationService _fileInformationService;

        public MovieMetadataServiceTests()
        {
            _fileSystemService = Substitute.For<IFileSystemService>();
            _metadataRepository = Substitute.For<IMovieMetadataRepository>();
            _metadataUpdater = Substitute.For<IMovieMetadataUpdater>();
            _synopsisService = Substitute.For<IMovieSynopsisService>();
            _imagesService = Substitute.For<IMovieImagesService>();
            _fileInformationService = Substitute.For<IFileInformationService>();
            _service = new MovieMetadataService(_fileSystemService, _metadataRepository, _metadataUpdater, _synopsisService, _imagesService, _fileInformationService);
        }

        [Fact]
        public void Get_WhenMetadataRepositoryReturnsMetadata_ReturnsIt()
        {
            // Arrange
            MovieMetadata metadata = new MovieMetadata();
            _metadataRepository.Get(MovieFile)
                .Returns(metadata);

            // Act
            MovieMetadata actualMetadata = _service.Get(MovieFile);

            // Assert
            Assert.Same(metadata, actualMetadata);
        }

        [Fact]
        public void Get_WithActors_SetsActorThumbnailPath()
        {
            // Arrange
            MovieMetadata metadata = new MovieMetadata();
            ActorMetadata actor = new ActorMetadata { Name = "Michael Cera" };
            metadata.Actors.Add(actor);
            _metadataRepository.Get(MovieFile)
                .Returns(metadata);

            _fileSystemService.GetParentFolder(MovieFile, 1)
                .Returns(@"C:\Folder\Movies\Scott Pilgrim Vs. The World\");

            // Act
            MovieMetadata actualMetadata = _service.Get(MovieFile);

            // Assert
            Assert.NotEmpty(actualMetadata.Actors);
            ActorMetadata firstActor = actualMetadata.Actors.First();
            Assert.Equal(@"C:\Folder\Movies\Scott Pilgrim Vs. The World\.actors\Michael_Cera.jpg", firstActor.ThumbPath);
        }

        [Fact]
        public void Get_Always_SetFanartImagePath()
        {
            // Arrange
            _metadataRepository.Get(MovieFile)
                .Returns(new MovieMetadata());

            // Act
            MovieMetadata metadata = _service.Get(MovieFile);

            // Assert
            Assert.Equal(@"C:\Folder\Movies\Scott Pilgrim Vs. The World\Scott_Pilgrim_Vs_The_World-fanart.jpg", metadata.ImageFanartPath);
        }

        [Fact]
        public void Get_Always_SetPosterImagePath()
        {
            // Arrange
            _metadataRepository.Get(MovieFile)
                .Returns(new MovieMetadata());

            // Act
            MovieMetadata metadata = _service.Get(MovieFile);

            // Assert
            Assert.Equal(@"C:\Folder\Movies\Scott Pilgrim Vs. The World\Scott_Pilgrim_Vs_The_World-poster.jpg", metadata.ImagePosterPath);
        }

        [Fact]
        public void GetMovieSet_Always_SetsAppropriateProperties()
        {
            // Act
            MovieSet set = _service.GetMovieSet("Star Wars");

            // Assert
            Assert.Equal("Star Wars", set.Name);
            Assert.Equal(@"C:\Movies\_Artwork\Star Wars-fanart.jpg", set.BackdropPath);
            Assert.Equal(@"C:\Movies\_Artwork\Star Wars-poster.jpg", set.PosterPath);
        }

        [Fact]
        public async Task Save_Always_PersistsMetadata()
        {
            // Arrange
            MovieMetadata metadata = new MovieMetadata();

            // Act
            await _service.Save(MovieFile, metadata);

            // Assert
            _metadataRepository.Received()
                .Save(MovieFile, metadata).Async();
        }

        [Fact]
        public void Delete_Always_DeletesMetadata()
        {
            // Act
            _service.Delete(MovieFile);

            // Assert
            _metadataRepository.Received()
                .Delete(MovieFile);
        }

        [Fact]
        public void DeleteImages_Always_DeletesImages()
        {
            // Act
            _service.DeleteImages(MovieFile);

            // Assert
            _imagesService.Received()
                .Delete(MovieFile);
        }

        [Fact]
        public void FindMovies_WhenMetadataUpdaterReturnsMovies_ReturnsThose()
        {
            // Arrange
            List<Movie> movies = new List<Movie>
            {
                new Movie { Title = "The Movie About Stuff" },
                new Movie { Title = "Great Stuff" }
            };
            _metadataUpdater.FindMovies("Stuff")
                .Returns(movies);

            // Act
            List<Movie> actualMovies = _service.FindMovies("Stuff").ToList();

            // Assert
            Assert.Equal(2, actualMovies.Count);
            Assert.Contains(movies[0], actualMovies);
            Assert.Contains(movies[1], actualMovies);
        }

        [Fact]
        public void FindImages_WhenMetadataUpdaterReturnsImages_ReturnsThose()
        {
            // Arrange
            AvailableMovieImages images = new AvailableMovieImages();
            _metadataUpdater.FindImages("123")
                .Returns(images);

            // Act
            AvailableMovieImages actualImages = _service.FindImages("123");

            // Assert
            Assert.Same(images, actualImages);
        }

        [Fact]
        public void FindSetImages_WhenMetadataUpdaterReturnsImages_ReturnsThose()
        {
            // Arrange
            AvailableMovieImages images = new AvailableMovieImages();
            _metadataUpdater.FindSetImages("Star Wars")
                .Returns(images);

            // Act
            AvailableMovieImages actualImages = _service.FindSetImages("Star Wars");

            // Assert
            Assert.Same(images, actualImages);
        }
    }
}
