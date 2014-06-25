using NSubstitute;
using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.ViewModels.TvShows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.Tests.UI.ViewModels.TvShows
{
    public class TvShowMetadataViewModelTests
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly ITvShowMetadataService _metadataService;
        private readonly TvShowMetadataViewModel _viewModel;
        private readonly string _path;

        public TvShowMetadataViewModelTests()
        {
            _viewModelFactory = Substitute.For<ITvShowViewModelFactory>();
            _metadataService = Substitute.For<ITvShowMetadataService>();
            _path = @"C:\Folder\Music";
            _viewModel = new TvShowMetadataViewModel(_viewModelFactory, _metadataService, _path);
        }

        [Fact]
        public void Genres_WhenModified_ModifiesGenresString()
        {
            // Arrange
            string raisedPropertyName = null;
            _viewModel.PropertyChanged += (s, e) => raisedPropertyName = e.PropertyName;

            _metadataService.Get(Arg.Any<string>())
                .Returns(new TvShowMetadata());

            TvShowImagesViewModel imagesViewModel = Substitute.For<TvShowImagesViewModel>();
            _viewModelFactory.GetTvShowImages(_path)
                .Returns(imagesViewModel);

            // Act
            _viewModel.Genres.Collection.Add("Animation");
            _viewModel.Genres.Collection.Add("Action");
            _viewModel.Genres.Collection.Add("Adventure");

            // Assert
            Assert.Equal("GenresString", raisedPropertyName);
            Assert.Contains("Animation", _viewModel.Genres.String);
            Assert.Contains("Action", _viewModel.Genres.String);
            Assert.Contains("Adventure", _viewModel.Genres.String);
        }

        [Fact]
        public void GenresString_WhenModified_ModifiesGenres()
        {
            // Arrange
            _metadataService.Get(Arg.Any<string>())
                .Returns(new TvShowMetadata());

            bool collectionChanged = false;
            _viewModel.Genres.Collection.CollectionChanged += (s, e) => collectionChanged = true;

            // Act
            _viewModel.Genres.String = "Animation / Action / Adventure";

            // Assert
            Assert.True(collectionChanged);
            Assert.Contains("Animation", _viewModel.Genres.Collection);
            Assert.Contains("Action", _viewModel.Genres.Collection);
            Assert.Contains("Adventure", _viewModel.Genres.Collection);
        }

        [Fact]
        public void Refresh_Always_RefreshesTvShowProperties()
        {
            // Arrange
            TvShowMetadata metadata = CreateTvShowMetadata();
            _metadataService.Get(Arg.Any<string>())
                .Returns(new TvShowMetadata());

            // Act
            _viewModel.Refresh();

            // Assert
            AssertMetadataEqualsViewModel(metadata);
        }

        [Fact]
        public void Refresh_Always_RefreshesImages()
        {
            // Arrange
            _metadataService.Get(Arg.Any<string>())
                .Returns(new TvShowMetadata());

            // Act
            _viewModel.Refresh();

            // Assert
            /*_metadataService.ReceivedWithAnyArgs()
                .GetLocalImages(null);
            _localMetadataService.ReceivedWithAnyArgs()
                .GetLocalSeasonImages(null);*/
            throw new NotImplementedException();
        }

        [Fact]
        public void Update_Always_RetrievesFreshMetadata()
        {
            // Arrange
            TvShowMetadata metadata = CreateTvShowMetadata();
            _metadataService.Get(Arg.Any<string>())
                .Returns(new TvShowMetadata());

            // Act
            _viewModel.Update();

            // Assert
            _metadataService.Received()
                .Update(_path);
            AssertMetadataEqualsViewModel(metadata);
        }

        [Fact]
        public void Save_Always_SavesMetadataLocally()
        {
            // Arrange
            _metadataService.Get(Arg.Any<string>())
                .Returns(new TvShowMetadata());

            _viewModel.Actors.Add(new ActorViewModel { Name = "ActorName", Role = "ActorRole", Thumb = "ActorThumb" });
            _viewModel.Actors.Add(new ActorViewModel { Name = "ActorName", Role = "ActorRole", Thumb = "ActorThumb" });
            _viewModel.Id = "Good ID";
            _viewModel.ImdbId = "IMDB ID";
            _viewModel.Language = "fr";
            _viewModel.MpaaRating = "G";
            _viewModel.Plot = "The best plot ever";
            _viewModel.PremieredDate = new DateTime(2012, 12, 21);
            _viewModel.Rating = 9;
            _viewModel.RuntimeInMinutes = 23;
            _viewModel.State = 1;
            _viewModel.Studio = "HBO";
            _viewModel.Title = "A good title";

            // Act
            _viewModel.Save();

            // Assert
            // TODO: validate we're getting the good properties in the second argument to save
            _metadataService.Received()
                .Save(_path, Arg.Any<TvShowMetadata>());
        }

        private TvShowMetadata CreateTvShowMetadata()
        {
            return new TvShowMetadata
            {
                Actors = new List<ActorMetadata>
                {
                    new ActorMetadata { Name = "ActorName", Role="ActorRole", Thumb ="ActorThumb" },
                    new ActorMetadata { Name = "ActorName", Role="ActorRole", Thumb ="ActorThumb" }
                },
                Genres = new List<string> { "Animation", "Action" },
                Id = "Good ID",
                ImdbId = "IMDB ID",
                Language = "fr",
                MpaaRating = "G",
                Plot = "The best plot ever",
                PremieredDate = new DateTime(2012, 12, 21),
                Rating = 9,
                RuntimeInMinutes = 23,
                State = 1,
                Studio = "HBO",
                Title = "A good title"
            };
        }

        private void AssertMetadataEqualsViewModel(TvShowMetadata metadata)
        {
            Assert.Equal(2, _viewModel.Actors.Count);
            ActorViewModel actorViewModel = _viewModel.Actors[0];
            Assert.Equal("ActorName", actorViewModel.Name);
            Assert.Equal("ActorRole", actorViewModel.Role);
            Assert.Equal("ActorThumb", actorViewModel.Thumb);

            Assert.Equal(metadata.Genres, _viewModel.Genres.Collection);
            Assert.Equal(metadata.Id, _viewModel.Id);
            Assert.Equal(metadata.ImdbId, _viewModel.ImdbId);
            Assert.Equal(metadata.Language, _viewModel.Language);
            Assert.Equal(metadata.MpaaRating, _viewModel.MpaaRating);
            Assert.Equal(metadata.Plot, _viewModel.Plot);
            Assert.Equal(metadata.PremieredDate, _viewModel.PremieredDate);
            Assert.Equal(metadata.Rating, _viewModel.Rating);
            Assert.Equal(metadata.RuntimeInMinutes, _viewModel.RuntimeInMinutes);
            Assert.Equal(metadata.State, _viewModel.State);
            Assert.Equal(metadata.Studio, _viewModel.Studio);
            Assert.Equal(metadata.Title, _viewModel.Title);
        }
    }
}
