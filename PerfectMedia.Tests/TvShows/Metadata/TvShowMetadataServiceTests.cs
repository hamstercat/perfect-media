using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.TvShows.Metadata
{
    public class TvShowMetadataServiceTests
    {
        private readonly ITvShowImagesService _imageService;
        private readonly ITvShowMetadataRepository _metadataRepository;
        private readonly ITvShowMetadataUpdater _metadataUpdater;
        private readonly string _path;
        private readonly TvShowMetadataService _service;

        public TvShowMetadataServiceTests()
        {
            _imageService = Substitute.For<ITvShowImagesService>();
            _metadataRepository = Substitute.For<ITvShowMetadataRepository>();
            _metadataUpdater = Substitute.For<ITvShowMetadataUpdater>();
            _path = @"C:\Folder\TV Shows\Game of Thrones";
            _service = new TvShowMetadataService(null, _imageService, _metadataRepository, _metadataUpdater);
        }

        [Fact]
        public void Get_Always_ReturnsMetadata()
        {
            // Arrange
            TvShowMetadata expectedMetadata = new TvShowMetadata();
            _metadataRepository.Get(_path)
                .Returns(expectedMetadata);

            // Act
            TvShowMetadata metadata = _service.Get(_path);

            // Assert
            Assert.Equal(expectedMetadata, metadata);
        }

        [Fact]
        public void Save_Always_PersistMetadata()
        {
            // Arrange
            TvShowMetadata metadata = new TvShowMetadata();

            // Act
            _service.Save(_path, metadata);

            // Assert
            _metadataRepository.Received()
                .Save(_path, metadata);
        }

        [Fact(Skip = "Not implemented")]
        public void Update_WhenSerieAlreadyHasMetadata_UpdatesMetadata()
        {
            // Arrange
            _metadataRepository.Get(_path)
                .Returns(new TvShowMetadata { Id = "456" });

            FullSerie fullSerie = CreateFullSerie("456");
            _metadataUpdater.GetTvShowMetadata("456")
                .Returns(fullSerie);

            // Act
            _service.Update(_path);

            // Assert
        }

        [Fact(Skip = "Not implemented")]
        public void Update_WhenSerieAlreadyHasMetadata_UpdatesImages()
        {
            // Arrange
            _metadataRepository.Get(_path)
                .Returns(new TvShowMetadata { Id = "456" });

            // Act
            _service.Update(_path);

            // Assert
        }

        [Fact(Skip = "Not implemented")]
        public void Update_WhenSerieDoesntHaveMetadata_UpdatesMetadata()
        {
            // Arrange

            // Act
            _service.Update(_path);

            // Assert
        }

        [Fact(Skip = "Not implemented")]
        public void Update_WhenSerieDoesntHaveMetadata_UpdatesImages()
        {
            // Arrange

            // Act
            _service.Update(_path);

            // Assert
        }

        [Fact]
        public void Update_WhenSerieDoesntHaveMetadataAndSerieDoesntMatch_ThrowsException()
        {
            // Arrange
            _metadataRepository.Get(_path)
                .Returns(new TvShowMetadata());

            Assert.Throws<ItemNotFoundException>(() =>
            {
                // Act
                _service.Update(_path);
            });
        }

        [Fact]
        public void Delete_Always_DeleteMetadata()
        {
            // Act
            _service.Delete(_path);

            // Assert
            _metadataRepository.Received()
                .Delete(_path);
        }

        [Fact]
        public void Delete_Always_DeleteImages()
        {
            // Act
            _service.Delete(_path);

            // Assert
            _imageService.Received()
                .Delete(_path);
        }

        [Fact]
        public void FindSeries_Always_ReturnsSeries()
        {
            // Arrange
            string serieName = "Supernatural";

            List<Series> expectedSeries = new List<Series>
            {
                new Series { SeriesId = "78901", SeriesName = "Supernatural" },
                new Series { SeriesId = "79426", SeriesName = "Supernatural Science" },
                new Series { SeriesId = "154401", SeriesName = "5th Dimension - Secrets of the Supernatural" }
            };
            _metadataUpdater.FindSeries(serieName)
                .Returns(expectedSeries);

            // Act
            IEnumerable<Series> series = _service.FindSeries(serieName);

            // Assert
            Assert.Equal(expectedSeries, series);
        }

        [Fact]
        public void FindImages_Always_ReturnsSeries()
        {
            // Arrange
            string serieId = "78901";

            AvailableTvShowImages expectedImages = new AvailableTvShowImages
            {
                Banners = new List<Image> { new Image { Url = "http://thetvtdb.com/banner.jpg" } },
                Fanarts = new List<Image> { new Image { Url = "http://thetvtdb.com/fanart.jpg" } },
                Posters = new List<Image> { new Image { Url = "http://thetvtdb.com/poster.jpg" } },
                Seasons = new Dictionary<int, AvailableSeasonImages>
                {
                    { 0, new AvailableSeasonImages
                        {
                            Banners = new List<Image> { new Image { Url = "http://thetvdb.com/specials-banner.jpg" } },
                            Posters = new List<Image> { new Image { Url = "http://thetvdb.com/specials-poster.jpg" } },
                        }
                    }
                }
            };
            _metadataUpdater.FindImages(serieId)
                .Returns(expectedImages);

            // Act
            AvailableTvShowImages images = _service.FindImages(serieId);

            // Assert
            Assert.Equal(expectedImages, images);
        }

        private FullSerie CreateFullSerie(string serieId)
        {
            throw new NotImplementedException();
        }
    }
}
