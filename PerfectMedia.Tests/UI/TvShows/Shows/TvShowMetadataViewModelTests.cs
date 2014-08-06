using NSubstitute;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Progress;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PerfectMedia.UI.TvShows.Shows
{
    public class TvShowMetadataViewModelTests
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly ITvShowMetadataService _metadataService;
        private readonly IProgressManagerViewModel _progressManager;
        private readonly string _path;
        private TvShowMetadataViewModel _viewModel;

        public TvShowMetadataViewModelTests()
        {
            _path = @"C:\Folder\TV Shows";
            ICachedPropertyViewModel cachedProperty = Substitute.For<ICachedPropertyViewModel>();
            _viewModelFactory = Substitute.For<ITvShowViewModelFactory>();
            _viewModelFactory.GetCachedProperty(_path)
                .Returns(cachedProperty);

            _metadataService = Substitute.For<ITvShowMetadataService>();
            _progressManager = Substitute.For<IProgressManagerViewModel>();
            _viewModel = new TvShowMetadataViewModel(_viewModelFactory, _metadataService, _progressManager, _path);
        }

        [Fact]
        public void Refresh_Always_RefreshesTvShowProperties()
        {
            // Arrange
            TvShowMetadata metadata = CreateTvShowMetadata();
            _metadataService.Get(Arg.Any<string>())
                .Returns(metadata);

            // Act
            _viewModel.Refresh();

            // Assert
            AssertMetadataEqualsViewModel(metadata);
        }

        [Fact]
        public void Refresh_Always_RefreshesImages()
        {
            // Arrange
            _metadataService.Get(_path)
                .Returns(new TvShowMetadata());

            ITvShowImagesViewModel imagesViewModel = Substitute.For<ITvShowImagesViewModel>();
            _viewModelFactory.GetTvShowImages(Arg.Any<ITvShowMetadataViewModel>(), _path)
                .Returns(imagesViewModel);
            // Recreate the ViewModel as the ImagesViewModel is retrieved in the constructor
            _viewModel = new TvShowMetadataViewModel(_viewModelFactory, _metadataService, _progressManager, _path);

            // Act
            _viewModel.Refresh();

            // Assert
            imagesViewModel.Received().Refresh();
        }

        [Fact]
        public void Update_WhenMetadataAlreadyExists_DoesNothing()
        {
            // Arrange
            TvShowMetadata metadata = CreateTvShowMetadata();
            _metadataService.Get(Arg.Any<string>())
                .Returns(metadata);

            // Act
            _viewModel.Update();

            // Assert
            _metadataService.DidNotReceiveWithAnyArgs()
                .Update(_path);
        }

        [Fact]
        public async void Update_WhenNoMetadataAlreadyExists_RetrievesFreshMetadata()
        {
            // Arrange
            TvShowMetadata metadata = CreateTvShowMetadata();
            _metadataService.Get(Arg.Any<string>())
                .Returns(new TvShowMetadata(), metadata);

            // Act
            ProgressItem item = _viewModel.Update().First();
            await item.Execute();

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

            _viewModel.Actors.Add(CreateActorViewModel(1));
            _viewModel.Actors.Add(CreateActorViewModel(2));
            _viewModel.Genres.Collection.Add("Animation");
            _viewModel.Genres.Collection.Add("Action");
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
            _viewModel.Title.Value = "A good title";

            // Act
            _viewModel.Save();

            // Assert
            _metadataService.Received()
                .Save(_path, Arg.Is<TvShowMetadata>(x => AssertMetadataEqualsViewModel(CreateTvShowMetadata())));
        }

        private ActorViewModel CreateActorViewModel(int i)
        {
            IImageViewModel image = Substitute.For<IImageViewModel>();
            ActorViewModel actor = new ActorViewModel(image);
            actor.Name = "ActorName" + i;
            actor.Role = "ActorRole" + i;
            actor.ThumbUrl = "ActorThumb" + i;
            return actor;
        }

        private TvShowMetadata CreateTvShowMetadata()
        {
            return new TvShowMetadata
            {
                Actors = new List<ActorMetadata>
                {
                    new ActorMetadata { Name = "ActorName1", Role="ActorRole1", Thumb ="ActorThumb1" },
                    new ActorMetadata { Name = "ActorName2", Role="ActorRole2", Thumb ="ActorThumb2" }
                },
                Genres = new List<string> { "Animation", "Action" },
                Id = "Good ID",
                ImdbId = "IMDB ID",
                Language = "fr",
                MpaaRating = "G",
                Plot = "The best plot ever",
                Premiered = new DateTime(2012, 12, 21),
                Rating = 9,
                RuntimeInMinutes = 23,
                State = 1,
                Studio = "HBO",
                Title = "A good title"
            };
        }

        private bool AssertMetadataEqualsViewModel(TvShowMetadata metadata)
        {
            Assert.Equal(2, _viewModel.Actors.Count);
            ActorViewModel actorViewModel = _viewModel.Actors[0];
            Assert.Equal("ActorName1", actorViewModel.Name);
            Assert.Equal("ActorRole1", actorViewModel.Role);
            Assert.Equal("ActorThumb1", actorViewModel.ThumbUrl);

            Assert.Equal(metadata.Genres, _viewModel.Genres.Collection);
            Assert.Equal(metadata.Id, _viewModel.Id);
            Assert.Equal(metadata.ImdbId, _viewModel.ImdbId);
            Assert.Equal(metadata.Language, _viewModel.Language);
            Assert.Equal(metadata.MpaaRating, _viewModel.MpaaRating);
            Assert.Equal(metadata.Plot, _viewModel.Plot);
            Assert.Equal(metadata.Premiered, _viewModel.PremieredDate);
            Assert.Equal(metadata.Rating, _viewModel.Rating);
            Assert.Equal(metadata.RuntimeInMinutes, _viewModel.RuntimeInMinutes);
            Assert.Equal(metadata.State, _viewModel.State);
            Assert.Equal(metadata.Studio, _viewModel.Studio);
            Assert.Equal(metadata.Title, _viewModel.Title.Value);

            return true;
        }
    }
}
