using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using PerfectMedia.TvShows;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.TvShows.Seasons;
using Xunit;

namespace PerfectMedia.UI.TvShows.Shows
{
    public class TvShowViewModelTests
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly ITvShowFileService _tvShowFileService;
        private readonly string _path;
        private readonly IBusyProvider _busyProvider;
        private TvShowViewModel _viewModel;

        public TvShowViewModelTests()
        {
            _viewModelFactory = Substitute.For<ITvShowViewModelFactory>();
            _tvShowFileService = Substitute.For<ITvShowFileService>();
            _busyProvider = Substitute.For<IBusyProvider>();
            _path = @"C:\Folder\TV Shows\Game of Thrones";
            _viewModel = new TvShowViewModel(_viewModelFactory, _tvShowFileService, _busyProvider, _path);
        }

        [Fact]
        public void Constructor_Always_CreatesDummySeasonForTreeView()
        {
            // Assert
            Assert.NotEmpty(_viewModel.Seasons);
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
            Assert.Equal(3, _viewModel.Seasons.Count);
            _viewModelFactory.Received()
                .GetSeason(Arg.Any<ITvShowMetadataViewModel>(), Arg.Is(seasonPaths.ElementAt(0).Path));
            _viewModelFactory.Received()
                .GetSeason(Arg.Any<ITvShowMetadataViewModel>(), Arg.Is(seasonPaths.ElementAt(1).Path));
            _viewModelFactory.Received()
                .GetSeason(Arg.Any<ITvShowMetadataViewModel>(), Arg.Is(seasonPaths.ElementAt(2).Path));
        }

        [Fact]
        public async Task LoadChildren_WhenNoSeasonsExists_ClearsAllSeasons()
        {
            // Act
            await _viewModel.LoadChildren();

            // Assert
            Assert.Empty(_viewModel.Seasons);
        }

        [Fact]
        public async Task Update_Always_UpdatesMetadata()
        {
            // Arrange
            ITvShowMetadataViewModel metadata = Substitute.For<ITvShowMetadataViewModel>();
            _viewModelFactory.GetTvShowMetadata(_path)
                .Returns(metadata);
            _viewModel = new TvShowViewModel(_viewModelFactory, _tvShowFileService, _busyProvider, _path);

            // Act
            await _viewModel.Update();

            // Assert
            metadata.Received()
                .Update().Async();
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
            _viewModelFactory.GetSeason(Arg.Any<ITvShowMetadataViewModel>(), Arg.Any<string>())
                .Returns(seasonViewModel1);

            // Act
            await _viewModel.FindNewEpisodes();

            // Assert
            seasonViewModel1.Received()
                .FindNewEpisodes().Async();
        }
    }
}
