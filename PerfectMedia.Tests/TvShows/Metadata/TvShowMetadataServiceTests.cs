using System.Collections.Generic;
using Nito.AsyncEx.Synchronous;
using NSubstitute;
using Xunit;
using System.Threading.Tasks;

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
        public async Task Get_Always_ReturnsMetadata()
        {
            // Arrange
            TvShowMetadata expectedMetadata = new TvShowMetadata();
            _metadataRepository.Get(_path)
                .Returns(expectedMetadata.ToTask());

            // Act
            TvShowMetadata metadata = await _service.Get(_path);

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

        [Fact]
        public async Task Update_WhenSerieAlreadyHasMetadata_UpdatesImages()
        {
            // Arrange
            _metadataRepository.Get(_path)
                .Returns(new TvShowMetadata { Id = "456" }.ToTask());

            FullSerie fullSerie = CreateFullSerie();
            _metadataUpdater.GetTvShowMetadata("456")
                .Returns(fullSerie.ToTask());

            // Act
            await _service.Update(_path);

            // Assert
            _imageService.Received()
                .Update(_path, Arg.Any<AvailableTvShowImages>()).Async();
        }

        [Fact]
        public void Update_WhenSerieDoesntHaveMetadataAndSerieDoesntMatch_ThrowsException()
        {
            // Arrange
            _metadataRepository.Get(_path)
                .Returns(new TvShowMetadata().ToTask());

            // Act + Assert
            Assert.Throws<TvShowNotFoundException>(() => _service.Update(_path).WaitAndUnwrapException());
        }

        [Fact]
        public async Task Delete_Always_DeleteMetadata()
        {
            // Act
            await _service.Delete(_path);

            // Assert
            _metadataRepository.Received()
                .Delete(_path).Async();
        }

        [Fact]
        public async Task Delete_Always_DeleteImages()
        {
            // Act
            await _service.Delete(_path);

            // Assert
            _imageService.Received()
                .Delete(_path).Async();
        }

        [Fact]
        public async Task FindSeries_Always_ReturnsSeries()
        {
            // Arrange
            const string serieName = "Supernatural";

            IEnumerable<Series> expectedSeries = new List<Series>
            {
                new Series { SeriesId = "78901", SeriesName = "Supernatural" },
                new Series { SeriesId = "79426", SeriesName = "Supernatural Science" },
                new Series { SeriesId = "154401", SeriesName = "5th Dimension - Secrets of the Supernatural" }
            };
            _metadataUpdater.FindSeries(serieName)
                .Returns(expectedSeries.ToTask());

            // Act
            IEnumerable<Series> series = await _service.FindSeries(serieName);

            // Assert
            Assert.Equal(expectedSeries, series);
        }

        [Fact]
        public async Task FindImages_Always_ReturnsSeries()
        {
            // Arrange
            const string serieId = "78901";

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
                .Returns(expectedImages.ToTask());

            // Act
            AvailableTvShowImages images = await _service.FindImages(serieId);

            // Assert
            Assert.Equal(expectedImages, images);
        }

        private FullSerie CreateFullSerie()
        {
            return new FullSerie
            {
                Genre = ""
            };
        }
    }
}
