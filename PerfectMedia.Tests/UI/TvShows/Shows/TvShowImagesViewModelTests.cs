using NSubstitute;
using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.TvShows.Seasons;
using PerfectMedia.UI.TvShows.Shows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.Tests.UI.TvShows.Shows
{
    public class TvShowImagesViewModelTests
    {
        private readonly ITvShowFileService _tvShowFileService;
        private readonly ITvShowMetadataService _metadataService;
        private readonly string _path;
        private readonly TvShowImagesViewModel _viewModel;

        public TvShowImagesViewModelTests()
        {
            _tvShowFileService = Substitute.For<ITvShowFileService>();
            _metadataService = Substitute.For<ITvShowMetadataService>();
            _path = @"C:\Folder\TV Shows\Game of Thrones";
            _viewModel = new TvShowImagesViewModel(_tvShowFileService, _metadataService, _path);
        }

        [Fact]
        public void FanartUrl_Always_ShouldBeLoaded()
        {
            // Act
            string fanartUrl = _viewModel.FanartUrl;

            // Assert
            Assert.Equal(@"C:\Folder\TV Shows\Game of Thrones\fanart.jpg", fanartUrl);
        }

        [Fact]
        public void PosterUrl_Always_ShouldBeLoaded()
        {
            // Act
            string posterUrl = _viewModel.PosterUrl;

            // Assert
            Assert.Equal(@"C:\Folder\TV Shows\Game of Thrones\poster.jpg", posterUrl);
        }

        [Fact]
        public void BannerUrl_Always_ShouldBeLoaded()
        {
            // Act
            string bannerUrl = _viewModel.BannerUrl;

            // Assert
            Assert.Equal(@"C:\Folder\TV Shows\Game of Thrones\banner.jpg", bannerUrl);
        }

        [Fact]
        public void SeasonImages_WhenSeasonsExist_AddsThoseSeasons()
        {
            // Arrange
            List<Season> seasons = new List<Season>
            {
                new Season { SeasonNumber = 0 },
                new Season { SeasonNumber = 1 },
                new Season { SeasonNumber = 2 },
                new Season { SeasonNumber = 3 },
                new Season { SeasonNumber = 4 }
            };
            _tvShowFileService.GetSeasons(_path)
                .Returns(seasons);

            // Assert
            Assert.Equal(5, _viewModel.SeasonImages.Count);
            Assert.Equal(seasons.Select(s => s.SeasonNumber), _viewModel.SeasonImages.Select(s => s.SeasonNumber));
        }
        
        [Fact]
        public void SeasonImages_WhenNoSeasonsExist_ClearsSeasonImages()
        {
            // Assert
            Assert.Empty(_viewModel.SeasonImages);
        }
    }
}
