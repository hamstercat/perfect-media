using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Actors;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Seasons;
using Xunit;

namespace PerfectMedia.UI.TvShows.Shows
{
    public class TvShowViewModelTests
    {
        private TvShowViewModel _viewModel;
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly ITvShowFileService _tvShowFileService;
        private readonly ITvShowMetadataService _metadataService;
        private readonly IBusyProvider _busyProvider;
        private readonly string _path;

        public TvShowViewModelTests()
        {
            _viewModelFactory = Substitute.For<ITvShowViewModelFactory>();
            _tvShowFileService = Substitute.For<ITvShowFileService>();
            _metadataService = Substitute.For<ITvShowMetadataService>();
            _busyProvider = Substitute.For<IBusyProvider>();

            _path = @"C:\Folder\TV Shows\Game of Thrones";
            ICachedPropertyViewModel<string> cachedProperty = Substitute.For<ICachedPropertyViewModel<string>>();
            _viewModelFactory = Substitute.For<ITvShowViewModelFactory>();
            _viewModelFactory.GetStringCachedProperty(_path, Arg.Any<bool>())
                .Returns(cachedProperty);
            IActorManagerViewModel actorManager = Substitute.For<IActorManagerViewModel>();
            actorManager.Actors
                .Returns(new ObservableCollection<IActorViewModel>());
            _viewModelFactory.GetActorManager()
                .Returns(actorManager);

            _viewModel = new TvShowViewModel(_viewModelFactory, _tvShowFileService, _metadataService, _busyProvider, null, null, _path);
        }

        [Fact]
        public void Constructor_Always_CreatesDummySeasonForTreeView()
        {
            // Assert
            Assert.NotEmpty(_viewModel.Children);
        }

        [Fact]
        public async Task LoadChildren_WhenSeasonsExists_LoadsThoseSeasons()
        {
            // Arrange
            IEnumerable<Season> seasonPaths = new List<Season>
            {
                new Season { Path = @"C:\Folder\TV Shows\Game of Thrones\Season 1" },
                new Season { Path = @"C:\Folder\TV Shows\Game of Thrones\Season 2" },
                new Season { Path = @"C:\Folder\TV Shows\Game of Thrones\Season 3" }
            };
            _tvShowFileService.GetSeasons(_path)
                .Returns(seasonPaths.ToTask());

            // Act
            await _viewModel.LoadChildren();

            // Assert
            Assert.Equal(3, _viewModel.Children.Count);
            _viewModelFactory.Received()
                .GetSeason(Arg.Any<ITvShowViewModel>(), Arg.Is(seasonPaths.ElementAt(0).Path));
            _viewModelFactory.Received()
                .GetSeason(Arg.Any<ITvShowViewModel>(), Arg.Is(seasonPaths.ElementAt(1).Path));
            _viewModelFactory.Received()
                .GetSeason(Arg.Any<ITvShowViewModel>(), Arg.Is(seasonPaths.ElementAt(2).Path));
        }

        [Fact]
        public async Task LoadChildren_WhenNoSeasonsExists_ClearsAllSeasons()
        {
            // Act
            await _viewModel.LoadChildren();

            // Assert
            Assert.Empty(_viewModel.Children);
        }

        [Fact]
        public async Task FindNewEpisodes_WithoutSeasons_DoesNothing()
        {
            // Act
            await _viewModel.FindNewEpisodes();
        }

        [Fact]
        public async Task FindNewEpisodes_WithSeasons_FindNewEpisodesInTheseSeasons()
        {
            // Arrange
            IEnumerable<Season> seasons = new List<Season> { new Season(), new Season() };
            _tvShowFileService.GetSeasons(_path)
                .Returns(seasons.ToTask());

            ISeasonViewModel seasonViewModel1 = Substitute.For<ISeasonViewModel>();
            _viewModelFactory.GetSeason(Arg.Any<ITvShowViewModel>(), Arg.Any<string>())
                .Returns(seasonViewModel1);

            // Act
            await _viewModel.FindNewEpisodes();

            // Assert
            seasonViewModel1.Received()
                .FindNewEpisodes().Async();
        }

        [Fact]
        public async Task Refresh_Always_RefreshesTvShowProperties()
        {
            // Arrange
            TvShowMetadata metadata = CreateTvShowMetadata();
            _metadataService.Get(Arg.Any<string>())
                .Returns(metadata.ToTask());

            // Act
            await _viewModel.Refresh();

            // Assert
            AssertMetadataEqualsViewModel(metadata);
        }

        [Fact]
        public async Task Refresh_Always_RefreshesImages()
        {
            // Arrange
            _metadataService.Get(_path)
                .Returns(new TvShowMetadata().ToTask());

            ITvShowImagesViewModel imagesViewModel = Substitute.For<ITvShowImagesViewModel>();
            _viewModelFactory.GetTvShowImages(Arg.Any<ITvShowViewModel>(), _path)
                .Returns(imagesViewModel);
            // Recreate the ViewModel as the ImagesViewModel is retrieved in the constructor
            _viewModel = new TvShowViewModel(_viewModelFactory, _tvShowFileService, _metadataService, _busyProvider, null, null, _path);

            // Act
            await _viewModel.Refresh();

            // Assert
            imagesViewModel.Received()
                .Refresh().Async();
        }

        [Fact]
        public async Task Update_WhenMetadataAlreadyExists_DoesNothing()
        {
            // Arrange
            TvShowMetadata metadata = CreateTvShowMetadata();
            _metadataService.Get(Arg.Any<string>())
                .Returns(metadata.ToTask());

            // Act
            await _viewModel.Update();

            // Assert
            _metadataService.DidNotReceiveWithAnyArgs()
                .Update(_path).Async();
        }

        [Fact]
        public async Task Update_WhenNoMetadataAlreadyExists_RetrievesFreshMetadata()
        {
            // Arrange
            TvShowMetadata metadata = CreateTvShowMetadata();
            _metadataService.Get(Arg.Any<string>())
                .Returns(new TvShowMetadata().ToTask(), metadata.ToTask());

            // Act
            IEnumerable<ProgressItem> items = await _viewModel.Update();
            ProgressItem item = items.First();
            await item.Execute();

            // Assert
            _metadataService.Received()
                .Update(_path).Async();
            AssertMetadataEqualsViewModel(metadata);
        }

        [Fact]
        public void Save_Always_SavesMetadataLocally()
        {
            // Arrange
            _metadataService.Get(Arg.Any<string>())
                .Returns(new TvShowMetadata().ToTask());

            _viewModel.ActorManager.Actors.Add(CreateActorViewModel(1));
            _viewModel.ActorManager.Actors.Add(CreateActorViewModel(2));
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
            Assert.Equal(2, _viewModel.ActorManager.Actors.Count);
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
