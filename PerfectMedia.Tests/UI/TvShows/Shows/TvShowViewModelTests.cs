using NSubstitute;
using PerfectMedia.TvShows;
using PerfectMedia.UI.TvShows;
using PerfectMedia.UI.TvShows.Shows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.Tests.UI.TvShows.Shows
{
    public class TvShowViewModelTests
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly ITvShowFileService _tvShowFileService;
        private readonly string _path;
        private readonly TvShowViewModel _viewModel;

        public TvShowViewModelTests()
        {
            _viewModelFactory = Substitute.For<ITvShowViewModelFactory>();
            _tvShowFileService = Substitute.For<ITvShowFileService>();
            _path = @"C:\Folder\TV Shows\Game of Thrones";
            _viewModel = new TvShowViewModel(_viewModelFactory, _tvShowFileService, _path);
        }

        [Fact]
        public void Constructor_Always_CreatesDummySeasonForTreeView()
        {
            // Assert
            Assert.NotEmpty(_viewModel.Seasons);
        }

        [Fact]
        public void IsExpanded_WhenSeasonsExists_LoadsThoseSeasons()
        {
            // Arrange
            List<Season> seasonPaths = new List<Season>
            {
                new Season { Path = @"C:\Folder\TV Shows\Game of Thrones\Season 1" },
                new Season { Path = @"C:\Folder\TV Shows\Game of Thrones\Season 2" },
                new Season { Path = @"C:\Folder\TV Shows\Game of Thrones\Season 3" }
            };
            _tvShowFileService.GetSeasons(_path)
                .Returns(seasonPaths);

            // Act
            _viewModel.IsExpanded = true;

            // Assert
            Assert.Equal(3, _viewModel.Seasons.Count);
            _viewModelFactory.Received()
                .GetSeason(_path, Arg.Is<string>(seasonPaths[0].Path));
            _viewModelFactory.Received()
                .GetSeason(_path, Arg.Is<string>(seasonPaths[1].Path));
            _viewModelFactory.Received()
                .GetSeason(_path, Arg.Is<string>(seasonPaths[2].Path));
        }

        [Fact]
        public void IsExpanded_WhenNoSeasonsExists_ClearsAllSeasons()
        {
            // Act
            _viewModel.IsExpanded = true;

            // Assert
            Assert.Empty(_viewModel.Seasons);
        }
    }
}
