﻿using NSubstitute;
using PerfectMedia.Metadata;
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
        private readonly ITvShowLocalMetadataService _localMetadataService;
        private readonly ITvShowMetadataService _metadataService;
        private readonly TvShowMetadataViewModel _viewModel;
        private readonly string _path;

        public TvShowMetadataViewModelTests()
        {
            _localMetadataService = Substitute.For<ITvShowLocalMetadataService>();
            _metadataService = Substitute.For<ITvShowMetadataService>();
            _path = @"C:\Folder\Music";
            _viewModel = new TvShowMetadataViewModel(_localMetadataService, _metadataService, _path);
        }

        [Fact]
        public void Genres_WhenModified_ModifiesGenresString()
        {
            // Arrange
            string raisedPropertyName = null;
            _viewModel.PropertyChanged += (s, e) => raisedPropertyName = e.PropertyName;

            _localMetadataService.GetLocalMetadata(Arg.Any<string>())
                .Returns(new TvShowMetadata());
            _localMetadataService.GetLocalImages(Arg.Any<string>())
                .Returns(new TvShowImages());

            // Act
            _viewModel.Genres.Add("Animation");
            _viewModel.Genres.Add("Action");
            _viewModel.Genres.Add("Adventure");

            // Assert
            Assert.Equal("GenresString", raisedPropertyName);
            Assert.Contains("Animation", _viewModel.GenresString);
            Assert.Contains("Action", _viewModel.GenresString);
            Assert.Contains("Adventure", _viewModel.GenresString);
        }

        [Fact]
        public void GenresString_WhenModified_ModifiesGenres()
        {
            // Arrange
            _localMetadataService.GetLocalMetadata(Arg.Any<string>())
                .Returns(new TvShowMetadata());
            _localMetadataService.GetLocalImages(Arg.Any<string>())
                .Returns(new TvShowImages());

            bool collectionChanged = false;
            _viewModel.Genres.CollectionChanged += (s, e) => collectionChanged = true;

            // Act
            _viewModel.GenresString = "Animation / Action / Adventure";

            // Assert
            Assert.True(collectionChanged);
            Assert.Contains("Animation", _viewModel.Genres);
            Assert.Contains("Action", _viewModel.Genres);
            Assert.Contains("Adventure", _viewModel.Genres);
        }

        [Fact]
        public void Refresh_Always_RefreshesTvShowProperties()
        {
            // Arrange
            TvShowMetadata metadata = CreateTvShowMetadata();
            _localMetadataService.GetLocalMetadata(_path)
                .Returns(metadata);
            _localMetadataService.GetLocalImages(Arg.Any<string>())
                .Returns(new TvShowImages());

            // Act
            _viewModel.Refresh();

            // Assert
            AssertMetadataEqualsViewModel(metadata);
        }

        [Fact]
        public void Refresh_Always_RefreshesImages()
        {
            // Arrange
            _localMetadataService.GetLocalMetadata(Arg.Any<string>())
                .Returns(new TvShowMetadata());
            _localMetadataService.GetLocalImages(Arg.Any<string>())
                .Returns(new TvShowImages());

            // Act
            _viewModel.Refresh();

            // Assert
            _localMetadataService.ReceivedWithAnyArgs()
                .GetLocalImages(null);
            _localMetadataService.ReceivedWithAnyArgs()
                .GetLocalSeasonImages(null);
        }

        [Fact]
        public void Update_Always_RetrievesFreshMetadata()
        {
            // Arrange
            TvShowMetadata metadata = CreateTvShowMetadata();
            _localMetadataService.GetLocalMetadata(_path)
                .Returns(metadata);
            _localMetadataService.GetLocalImages(Arg.Any<string>())
                .Returns(new TvShowImages());

            // Act
            _viewModel.Update();

            // Assert
            _metadataService.Received()
                .UpdateMetadata(_path);
            AssertMetadataEqualsViewModel(metadata);
        }

        [Fact]
        public void Save_Always_SavesMetadataLocally()
        {
            // Arrange
            _localMetadataService.GetLocalMetadata(_path)
                .Returns(new TvShowMetadata());
            _localMetadataService.GetLocalImages(Arg.Any<string>())
                .Returns(new TvShowImages());

            _viewModel.Actors.Add(new ActorViewModel { Name = "ActorName", Role = "ActorRole", Thumb = "ActorThumb" });
            _viewModel.Actors.Add(new ActorViewModel { Name = "ActorName", Role = "ActorRole", Thumb = "ActorThumb" });
            _viewModel.Genres = new ObservableCollection<string> { "Animation", "Action" };
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
            _localMetadataService.Received()
                .SaveLocalMetadata(_path, Arg.Any<TvShowMetadata>());
        }

        private TvShowMetadata CreateTvShowMetadata()
        {
            return new TvShowMetadata
            {
                Actors = new List<Actor>
                {
                    new Actor { Name = "ActorName", Role="ActorRole", Thumb ="ActorThumb" },
                    new Actor { Name = "ActorName", Role="ActorRole", Thumb ="ActorThumb" }
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

            Assert.Equal(metadata.Genres, _viewModel.Genres);
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
