﻿using System;
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
        public async Task Get_WhenMetadataRepositoryReturnsMetadata_ReturnsIt()
        {
            // Arrange
            MovieMetadata metadata = new MovieMetadata();
            _metadataRepository.Get(MovieFile)
                .Returns(metadata.ToTask());

            // Act
            MovieMetadata actualMetadata = await _service.Get(MovieFile);

            // Assert
            Assert.Same(metadata, actualMetadata);
        }

        [Fact]
        public async Task Get_WithActors_SetsActorThumbnailPath()
        {
            // Arrange
            MovieMetadata metadata = new MovieMetadata();
            ActorMetadata actor = new ActorMetadata { Name = "Michael Cera" };
            metadata.Actors.Add(actor);
            _metadataRepository.Get(MovieFile)
                .Returns(metadata.ToTask());

            _fileSystemService.GetParentFolder(MovieFile, 1)
                .Returns(@"C:\Folder\Movies\Scott Pilgrim Vs. The World\");

            // Act
            MovieMetadata actualMetadata = await _service.Get(MovieFile);

            // Assert
            Assert.NotEmpty(actualMetadata.Actors);
            ActorMetadata firstActor = actualMetadata.Actors.First();
            Assert.Equal(@"C:\Folder\Movies\Scott Pilgrim Vs. The World\.actors\Michael_Cera.jpg", firstActor.ThumbPath);
        }

        [Fact]
        public async Task Get_Always_SetFanartImagePath()
        {
            // Arrange
            _metadataRepository.Get(MovieFile)
                .Returns(new MovieMetadata().ToTask());

            // Act
            MovieMetadata metadata = await _service.Get(MovieFile);

            // Assert
            Assert.Equal(@"C:\Folder\Movies\Scott Pilgrim Vs. The World\Scott_Pilgrim_Vs_The_World-fanart.jpg", metadata.ImageFanartPath);
        }

        [Fact]
        public async Task Get_Always_SetPosterImagePath()
        {
            // Arrange
            _metadataRepository.Get(MovieFile)
                .Returns(new MovieMetadata().ToTask());

            // Act
            MovieMetadata metadata = await _service.Get(MovieFile);

            // Assert
            Assert.Equal(@"C:\Folder\Movies\Scott Pilgrim Vs. The World\Scott_Pilgrim_Vs_The_World-poster.jpg", metadata.ImagePosterPath);
        }

        [Fact]
        public async Task GetMovieSet_Always_SetsAppropriateProperties()
        {
            _fileSystemService.FolderExists(@"C:\Movies\_Artwork")
                .Returns(true.ToTask());

            // Act
            MovieSet set = await _service.GetMovieSet("Star Wars");

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
        public async Task Delete_Always_DeletesMetadata()
        {
            // Act
            await _service.Delete(MovieFile);

            // Assert
            _metadataRepository.Received()
                .Delete(MovieFile).Async();
        }

        [Fact]
        public async Task DeleteImages_Always_DeletesImages()
        {
            // Act
            await _service.DeleteImages(MovieFile);

            // Assert
            _imagesService.Received()
                .Delete(MovieFile).Async();
        }

        [Fact]
        public async Task FindMovies_WhenMetadataUpdaterReturnsMovies_ReturnsThose()
        {
            // Arrange
            IEnumerable<Movie> movies = new List<Movie>
            {
                new Movie { Title = "The Movie About Stuff" },
                new Movie { Title = "Great Stuff" }
            };
            _metadataUpdater.FindMovies("Stuff")
                .Returns(movies.ToTask());

            // Act
            IEnumerable<Movie> actualMovies = await _service.FindMovies("Stuff");

            // Assert
            Assert.Equal(2, actualMovies.Count());
            Assert.Contains(movies.ElementAt(0), actualMovies);
            Assert.Contains(movies.ElementAt(1), actualMovies);
        }

        [Fact]
        public async Task FindImages_WhenMetadataUpdaterReturnsImages_ReturnsThose()
        {
            // Arrange
            AvailableMovieImages images = new AvailableMovieImages();
            _metadataUpdater.FindImages("123")
                .Returns(images.ToTask());

            // Act
            AvailableMovieImages actualImages = await _service.FindImages("123");

            // Assert
            Assert.Same(images, actualImages);
        }

        [Fact]
        public async Task FindSetImages_WhenMetadataUpdaterReturnsImages_ReturnsThose()
        {
            // Arrange
            AvailableMovieImages images = new AvailableMovieImages();
            _metadataUpdater.FindSetImages("Star Wars")
                .Returns(images.ToTask());

            // Act
            AvailableMovieImages actualImages = await _service.FindSetImages("Star Wars");

            // Assert
            Assert.Same(images, actualImages);
        }
    }
}
