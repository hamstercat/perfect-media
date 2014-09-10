using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using PerfectMedia.FileInformation;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Shows;
using Xunit;

namespace PerfectMedia.UI.TvShows.Episodes
{
    public class EpisodeViewModelTests
    {
        private readonly EpisodeViewModel _viewModel;
        private readonly IEpisodeMetadataService _metadataService;
        private readonly ITvShowViewModel _tvShowMetadata;
        private readonly IBusyProvider _busyProvider;
        private readonly string _path;

        public EpisodeViewModelTests()
        {
            _metadataService = Substitute.For<IEpisodeMetadataService>();
            _tvShowMetadata = Substitute.For<ITvShowViewModel>();
            ITvShowViewModelFactory viewModelFactory = Substitute.For<ITvShowViewModelFactory>();
            _busyProvider = _busyProvider = Substitute.For<IBusyProvider>();
            var keyDataStore = Substitute.For<IKeyDataStore>();
            _path = @"C:\Folder\TV Shows\Game of Thrones\Season 2\3x09.mkv";
            _viewModel = new EpisodeViewModel(viewModelFactory, _metadataService, _tvShowMetadata, null, _busyProvider, null, keyDataStore, _path);
        }

        [Fact]
        public async Task Refresh_Always_RefreshesTvShowProperties()
        {
            // Arrange
            EpisodeMetadata metadata = CreateEpisodeMetadata();
            _metadataService.Get(_path)
                .Returns(Task.FromResult(metadata));

            // Act
            await _viewModel.Refresh();

            // Assert
            AssertMetadataEqualsViewModel(metadata);
        }

        [Fact]
        public async Task Update_WhenMetadataAlreadyExists_DoesNothing()
        {
            // Arrange
            EpisodeMetadata metadata = CreateEpisodeMetadata();
            _metadataService.Get(_path)
                .Returns(Task.FromResult(metadata));
            _tvShowMetadata.Id
                .Returns("123");

            // Act
            await _viewModel.Update();

            // Assert
            _metadataService.DidNotReceiveWithAnyArgs()
                .Update(_path, "123").Async();
        }

        [Fact]
        public async Task Update_WhenNoMetadataAlreadyExists_RetrievesFreshMetadata()
        {
            // Arrange
            EpisodeMetadata metadata = CreateEpisodeMetadata();
            _metadataService.Get(_path)
                .Returns(new EpisodeMetadata().ToTask(), metadata.ToTask());
            _tvShowMetadata.Id
                .Returns("123");

            // Act
            IEnumerable<ProgressItem> items = await _viewModel.Update();
            ProgressItem item = items.First();
            await item.Execute();

            // Assert
            _metadataService.Received()
                .Update(_path, "123").Async();
            AssertMetadataEqualsViewModel(metadata);
        }

        [Fact]
        public async Task Update_Always_UpdatesTvShowMetadata()
        {
            // Arrange
            _metadataService.Get(_path)
                .Returns(new EpisodeMetadata().ToTask());

            // Act
            await _viewModel.Update();

            // Assert
            _tvShowMetadata.Received()
                .Update().Async();
        }

        [Fact]
        public void Save_Always_SavesMetadataLocally()
        {
            // Arrange
            _metadataService.Get(_path)
                .Returns(new EpisodeMetadata().ToTask());

            _viewModel.AiredDate = new DateTime(2012, 02, 17);
            _viewModel.Credits.Collection.Add("Writer #1");
            _viewModel.Credits.Collection.Add("Writer #2");
            _viewModel.Directors.Collection.Add("Director #1");
            _viewModel.Directors.Collection.Add("Director #2");
            _viewModel.DisplayEpisode = 1;
            _viewModel.DisplaySeason = 1;
            _viewModel.EpisodeBookmarks = 3.2;
            _viewModel.EpisodeNumber.Value = 9;
            _viewModel.ImagePath.Path = @"C:\Folder\TV Shows\Game of Thrones\Season 2\3x09-thumb.png";
            _viewModel.ImageUrl = "http://thetvdb.com/banners/seasons/79481-0.jpg";
            _viewModel.LastPlayed = new DateTime(2013, 01, 13);
            _viewModel.PlayCount = 4;
            _viewModel.Plot = "The best plot ever written in the history of men";
            _viewModel.Rating = 9.5;
            _viewModel.SeasonNumber.Value = 3;
            _viewModel.Title.Value = "The Red Wedding";

            // Act
            _viewModel.Save();

            // Assert
            _metadataService.Received()
                .Save(_path, Arg.Is<EpisodeMetadata>(x => AssertMetadataEqualsViewModel(CreateEpisodeMetadata())));
        }

        private EpisodeMetadata CreateEpisodeMetadata()
        {
            return new EpisodeMetadata
            {
                AiredDate = new DateTime(2012, 02, 17),
                Credits = new List<string> { "Writer #1", "Writer #2" },
                Director = new List<string> { "Director #1", "Director #2" },
                DisplayEpisode = 1,
                DisplaySeason = 1,
                EpisodeBookmarks = 3.2,
                EpisodeNumber = 9,
                ImagePath = @"C:\Folder\TV Shows\Game of Thrones\Season 2\3x09-thumb.png",
                ImageUrl = "http://thetvdb.com/banners/seasons/79481-0.jpg",
                LastPlayed = new DateTime(2013, 01, 13),
                PlayCount = 4,
                Plot = "The best plot ever written in the history of men",
                Rating = 9.5,
                SeasonNumber = 3,
                Title = "The Red Wedding",
                FileInformation = new VideoFileInformation(),
            };
        }

        private bool AssertMetadataEqualsViewModel(EpisodeMetadata metadata)
        {
            Assert.Equal(metadata.AiredDate, _viewModel.AiredDate);
            Assert.Equal(metadata.Credits, _viewModel.Credits.Collection);
            Assert.Equal(metadata.Director, _viewModel.Directors.Collection);
            Assert.Equal(metadata.DisplayEpisode, _viewModel.DisplayEpisode);
            Assert.Equal(metadata.DisplaySeason, _viewModel.DisplaySeason);
            Assert.Equal(metadata.EpisodeBookmarks, _viewModel.EpisodeBookmarks);
            Assert.Equal(metadata.EpisodeNumber, _viewModel.EpisodeNumber.Value);
            Assert.Equal(metadata.ImageUrl, _viewModel.ImageUrl);
            Assert.Equal(metadata.LastPlayed, _viewModel.LastPlayed);
            Assert.Equal(metadata.PlayCount, _viewModel.PlayCount);
            Assert.Equal(metadata.Plot, _viewModel.Plot);
            Assert.Equal(metadata.Rating, _viewModel.Rating);
            Assert.Equal(metadata.SeasonNumber, _viewModel.SeasonNumber.Value);
            Assert.Equal(metadata.Title, _viewModel.Title.Value);
            return true;
        }
    }
}
