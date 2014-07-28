using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.TvShows.Metadata
{
    public class TvShowImagesServiceTests
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly ITvShowFileService _tvShowFileService;
        private readonly string _path;
        private readonly TvShowImagesService _service;

        public TvShowImagesServiceTests()
        {
            _fileSystemService = Substitute.For<IFileSystemService>();
            _path = @"C:\Folder\TV Shows\Game of Thrones";
            
            _tvShowFileService = Substitute.For<ITvShowFileService>();
            TvShowImages images = new TvShowImages
            {
                Fanart = @"C:\Folder\TV Shows\Game of Thrones\fanart.jpg",
                Poster = @"C:\Folder\TV Shows\Game of Thrones\poster.jpg",
                Banner = @"C:\Folder\TV Shows\Game of Thrones\banner.jpg",
                Seasons = new List<Season>
                {
                    new Season
                    {
                        SeasonNumber = 0,
                        Path = @"C:\Folder\TV Shows\Game of Thrones\Specials",
                        PosterUrl = @"C:\Folder\TV Shows\Game of Thrones\season-specials-poster.jpg",
                        BannerUrl = @"C:\Folder\TV Shows\Game of Thrones\season-specials-banner.jpg"
                    },
                    new Season
                    {
                        SeasonNumber = 1,
                        Path = @"C:\Folder\TV Shows\Game of Thrones\Season 1",
                        PosterUrl = @"C:\Folder\TV Shows\Game of Thrones\season01-poster.jpg",
                        BannerUrl = @"C:\Folder\TV Shows\Game of Thrones\season01-banner.jpg"
                    }
                }
            };
            _tvShowFileService.GetShowImages(_path)
                .Returns(images);

            _service = new TvShowImagesService(_fileSystemService, _tvShowFileService);
        }

        [Fact]
        public void Update_WithNoAvailableImages_DoesNothing()
        {
            // Act
            _service.Update(_path, new AvailableTvShowImages());

            // Assert
            _fileSystemService.DidNotReceive()
                .DownloadImage(Arg.Any<string>(), Arg.Any<string>());
            _fileSystemService.DidNotReceive()
                .DownloadImage(Arg.Any<string>(), Arg.Any<string>());
        }

        [Fact]
        public void Update_WhenImagesAlreadyExist_DoesntUpdateThem()
        {
            // Arrange
            AvailableTvShowImages availableImages = CreateAvailableImages();
            _fileSystemService.FileExists(Arg.Any<string>())
                .Returns(true);

            // Act
            _service.Update(_path, availableImages);

            // Assert
            _fileSystemService.DidNotReceive()
                .DownloadImage(Arg.Any<string>(), Arg.Any<string>());
            _fileSystemService.DidNotReceive()
                .DownloadImage(Arg.Any<string>(), Arg.Any<string>());
        }

        [Fact]
        public void Update_WhenImagesDontExist_UpdatesThem()
        {
            // Arrange
            AvailableTvShowImages availableImages = CreateAvailableImages();

            // Act
            _service.Update(_path, availableImages);

            // Assert
            _fileSystemService.Received()
                .DownloadImage(@"C:\Folder\TV Shows\Game of Thrones\fanart.jpg", "http://thetvdb.com/fanart1.jpg");
            _fileSystemService.Received()
                .DownloadImage(@"C:\Folder\TV Shows\Game of Thrones\poster.jpg", "http://thetvdb.com/poster1.jpg");
            _fileSystemService.Received()
                .DownloadImage(@"C:\Folder\TV Shows\Game of Thrones\banner.jpg", "http://thetvdb.com/banner1.jpg");
            _fileSystemService.Received()
                .DownloadImage(@"C:\Folder\TV Shows\Game of Thrones\season-specials-poster.jpg", "http://thetvdb.com/specials-poster.jpg");
            _fileSystemService.Received()
                .DownloadImage(@"C:\Folder\TV Shows\Game of Thrones\season-specials-banner.jpg", "http://thetvdb.com/specials-banner.jpg");
            _fileSystemService.Received()
                .DownloadImage(@"C:\Folder\TV Shows\Game of Thrones\season01-poster.jpg", "http://thetvdb.com/season01-poster.jpg");
            _fileSystemService.Received()
                .DownloadImage(@"C:\Folder\TV Shows\Game of Thrones\season01-banner.jpg", "http://thetvdb.com/season01-banner.jpg");
        }

        [Fact]
        public void Delete_Always_DeletesImages()
        {
            // Act
            _service.Delete(_path);

            // Assert
            _fileSystemService.Received()
                .DeleteFile(@"C:\Folder\TV Shows\Game of Thrones\fanart.jpg");
            _fileSystemService.Received()
                .DeleteFile(@"C:\Folder\TV Shows\Game of Thrones\poster.jpg");
            _fileSystemService.Received()
                .DeleteFile(@"C:\Folder\TV Shows\Game of Thrones\banner.jpg");
            _fileSystemService.Received()
                .DeleteFile(@"C:\Folder\TV Shows\Game of Thrones\season-specials-poster.jpg");
            _fileSystemService.Received()
                .DeleteFile(@"C:\Folder\TV Shows\Game of Thrones\season-specials-banner.jpg");
            _fileSystemService.Received()
                .DeleteFile(@"C:\Folder\TV Shows\Game of Thrones\season01-poster.jpg");
            _fileSystemService.Received()
                .DeleteFile(@"C:\Folder\TV Shows\Game of Thrones\season01-banner.jpg");
        }

        private AvailableTvShowImages CreateAvailableImages()
        {
            return new AvailableTvShowImages
            {
                Fanarts = new List<Image>
                {
                    new Image { Url = "http://thetvdb.com/fanart1.jpg" },
                    new Image { Url = "http://thetvdb.com/fanart2.jpg" }
                },
                Posters = new List<Image>
                {
                    new Image { Url = "http://thetvdb.com/poster1.jpg" },
                    new Image { Url = "http://thetvdb.com/poster2.jpg" }
                },
                Banners = new List<Image>
                {
                    new Image { Url = "http://thetvdb.com/banner1.jpg" },
                    new Image { Url = "http://thetvdb.com/banner2.jpg" }
                },
                Seasons = new Dictionary<int, AvailableSeasonImages>
                {
                    { 0, new AvailableSeasonImages
                        {
                            Banners = new List<Image> { new Image { Url = "http://thetvdb.com/specials-banner.jpg" } },
                            Posters = new List<Image> { new Image { Url = "http://thetvdb.com/specials-poster.jpg" } },
                        }
                    },
                    { 1, new AvailableSeasonImages
                        {
                            Banners = new List<Image> { new Image { Url = "http://thetvdb.com/season01-banner.jpg" } },
                            Posters = new List<Image> { new Image { Url = "http://thetvdb.com/season01-poster.jpg" } },
                        }
                    }
                }
            };
        }
    }
}
