﻿using NSubstitute;
using PerfectMedia.TvShows;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Episodes;
using PerfectMedia.UI.TvShows.Shows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.UI.TvShows.Seasons
{
    public class SeasonViewModelTests
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly ITvShowFileService _tvShowFileService;
        private readonly ITvShowMetadataViewModel _tvShowMetadata;
        private readonly string _path;
        private readonly SeasonViewModel _viewModel;

        public SeasonViewModelTests()
        {
            _viewModelFactory = Substitute.For<ITvShowViewModelFactory>();
            _tvShowFileService = Substitute.For<ITvShowFileService>();
            _tvShowMetadata = Substitute.For<ITvShowMetadataViewModel>();
            _path = @"C:\Folder\TV Shows\Game of Thrones\Season 1";
            _viewModel = new SeasonViewModel(_viewModelFactory, _tvShowFileService, _tvShowMetadata, _path);
        }

        [Fact]
        public void Constructor_Always_CreatesDummyEpisodeForTreeView()
        {
            // Assert
            Assert.NotEmpty(_viewModel.Episodes);
        }

        [Fact]
        public void IsExpanded_WhenEpisodesExists_LoadsThoseEpisodes()
        {
            // Arrange
            List<Episode> episodePaths = new List<Episode>
            {
                new Episode { Path = @"C:\Folder\TV Shows\Game of Thrones\Season 1\1x01.mkv" },
                new Episode { Path = @"C:\Folder\TV Shows\Game of Thrones\Season 1\1x02.mkv" },
                new Episode { Path = @"C:\Folder\TV Shows\Game of Thrones\Season 1\1x03.mkv" }
            };
            _tvShowFileService.GetEpisodes(_path)
                .Returns(episodePaths);

            // Act
            _viewModel.IsExpanded = true;

            // Assert
            Assert.Equal(3, _viewModel.Episodes.Count);
            _viewModelFactory.Received()
                .GetEpisode(Arg.Any<ITvShowMetadataViewModel>(), Arg.Is<string>(episodePaths[0].Path));
            _viewModelFactory.Received()
                .GetEpisode(Arg.Any<ITvShowMetadataViewModel>(), Arg.Is<string>(episodePaths[1].Path));
            _viewModelFactory.Received()
                .GetEpisode(Arg.Any<ITvShowMetadataViewModel>(), Arg.Is<string>(episodePaths[2].Path));
        }

        [Fact]
        public void IsExpanded_WhenNoEpisodesExists_ClearsAllEpisodes()
        {
            // Act
            _viewModel.IsExpanded = true;

            // Assert
            Assert.Empty(_viewModel.Episodes);
        }

        [Fact]
        public void PosterUrl_Always_ShouldBeLoaded()
        {
            // Arrange
            Season season = new Season { PosterUrl = @"C:\Folder\TV Shows\Game of Thrones\season01-poster.jpg" };
            _tvShowFileService.GetSeason(Arg.Any<string>(), _path)
                .Returns(season);

            // Act
            string posterUrl = _viewModel.PosterUrl;

            // Assert
            Assert.Equal(season.PosterUrl, posterUrl);
        }

        [Fact]
        public void BannerUrl_Always_ShouldBeLoaded()
        {
            // Arrange
            Season season = new Season { BannerUrl = @"C:\Folder\TV Shows\Game of Thrones\season01-banner.jpg" };
            _tvShowFileService.GetSeason(Arg.Any<string>(), _path)
                .Returns(season);

            // Act
            string bannerUrl = _viewModel.BannerUrl;

            // Assert
            Assert.Equal(season.BannerUrl, bannerUrl);
        }

        [Fact]
        public void FindNewEpisodes_WithoutEpisodes_DoesNothing()
        {
            // Act
            _viewModel.FindNewEpisodes();
        }

        [Fact]
        public void FindNewEpisodes_WithTvShows_UpdatesTheseEpisodes()
        {
            // Arrange
            _tvShowFileService.GetEpisodes(_path)
                .Returns(new List<Episode> { new Episode(), new Episode() });

            IEpisodeViewModel episodeViewModel1 = Substitute.For<IEpisodeViewModel>();
            _viewModelFactory.GetEpisode(Arg.Any<ITvShowMetadataViewModel>(), Arg.Any<string>())
                .Returns(episodeViewModel1);

            // Act
            _viewModel.FindNewEpisodes().ToList();

            // Assert
            episodeViewModel1.Received()
                .Update();
        }
    }
}