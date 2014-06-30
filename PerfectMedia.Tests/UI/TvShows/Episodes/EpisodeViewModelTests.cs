using NSubstitute;
using PerfectMedia.FileInformation;
using PerfectMedia.TvShows.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.UI.TvShows.Episodes
{
    public class EpisodeViewModelTests
    {
        private readonly EpisodeViewModel _viewModel;
        private readonly IEpisodeMetadataService _metadataService;
        private readonly string _path;

        public EpisodeViewModelTests()
        {
            _metadataService = Substitute.For<IEpisodeMetadataService>();
            _path = @"C:\Folder\TV Shows\Game of Thrones\Season 2\3x09.mkv";
            _viewModel = new EpisodeViewModel(_metadataService, _path);
        }

        [Fact]
        public void Refresh_Always_RefreshesTvShowProperties()
        {
            // Arrange
            EpisodeMetadata metadata = CreateEpisodeMetadata();
            _metadataService.Get(_path)
                .Returns(metadata);

            // Act
            _viewModel.Refresh();

            // Assert
            AssertMetadataEqualsViewModel(metadata);
        }

        [Fact]
        public void Refresh_Always_ClearsAnyError()
        {
            // Arrange
            _metadataService.Get(_path)
                .Returns(new EpisodeMetadata());
            _viewModel.Error = "An error";

            // Act
            _viewModel.Refresh();

            // Assert
            Assert.True(string.IsNullOrEmpty(_viewModel.Error));
        }

        [Fact]
        public void Update_WhenMetadataAlreadyExists_DoesNothing()
        {
            // Arrange
            EpisodeMetadata metadata = CreateEpisodeMetadata();
            _metadataService.Get(_path)
                .Returns(metadata);

            // Act
            _viewModel.Update();

            // Assert
            _metadataService.DidNotReceiveWithAnyArgs()
                .Update(_path);
        }

        [Fact]
        public void Update_WhenNoMetadataAlreadyExists_RetrievesFreshMetadata()
        {
            // Arrange
            EpisodeMetadata metadata = CreateEpisodeMetadata();
            _metadataService.Get(_path)
                .Returns(new EpisodeMetadata(), metadata);

            // Act
            _viewModel.Update();

            // Assert
            _metadataService.Received()
                .Update(_path);
            AssertMetadataEqualsViewModel(metadata);
        }

        [Fact]
        public void Update_WithAnUnknownCodec_ShowsAnErrorMessage()
        {
            // Arrange
            _metadataService.Get(_path)
                .Returns(new EpisodeMetadata());
            _metadataService.When(svc => svc.Update(_path))
                .Do(x => { throw new UnknownCodecException("", "456", "MP7"); });
            
            // Act
            _viewModel.Update();

            // Assert
            Assert.False(string.IsNullOrEmpty(_viewModel.Error));
        }

        [Fact]
        public void Update_WithAnUnknownCodec_DoesntRefreshMetadata()
        {
            _metadataService.Get(_path)
                .Returns(new EpisodeMetadata());
            _metadataService.When(svc => svc.Update(_path))
                .Do(x => { throw new UnknownCodecException("", "456", "MP7"); });

            // Act
            _viewModel.Update();

            // Assert
            Assert.NotEqual(9, _viewModel.EpisodeNumber);
        }

        [Fact]
        public void Save_Always_SavesMetadataLocally()
        {
            // Arrange
            _metadataService.Get(_path)
                .Returns(new EpisodeMetadata());

            _viewModel.AiredDate = new DateTime(2012, 02, 17);
            _viewModel.Credits.Collection.Add("Writer #1");
            _viewModel.Credits.Collection.Add("Writer #2");
            _viewModel.Directors.Collection.Add("Director #1");
            _viewModel.Directors.Collection.Add("Director #2");
            _viewModel.DisplayEpisode = 1;
            _viewModel.DisplaySeason = 1;
            _viewModel.EpisodeBookmarks = 3.2;
            _viewModel.EpisodeNumber = 9;
            _viewModel.ImagePath = @"C:\Folder\TV Shows\Game of Thrones\Season 2\3x09-thumb.png";
            _viewModel.ImageUrl = "http://thetvdb.com/banners/seasons/79481-0.jpg";
            _viewModel.LastPlayed = new DateTime(2013, 01, 13);
            _viewModel.PlayCount = 4;
            _viewModel.Plot = "The best plot ever written in the history of men";
            _viewModel.Rating = 9.5;
            _viewModel.SeasonNumber = 3;
            _viewModel.Title = "The Red Wedding";

            // Act
            _viewModel.Save();

            // Assert
            _metadataService.Received()
                .Save(_path, Arg.Is<EpisodeMetadata>(x => AssertMetadataEqualsViewModel(CreateEpisodeMetadata())));
        }

        [Fact]
        public void Save_Always_ClearsAnyError()
        {
            // Arrange
            _metadataService.Get(_path)
                .Returns(new EpisodeMetadata());
            _viewModel.Error = "An error";

            // Act
            _viewModel.Save();

            // Assert
            Assert.True(string.IsNullOrEmpty(_viewModel.Error));
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
                Playcount = 4,
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
            Assert.Equal(metadata.EpisodeNumber, _viewModel.EpisodeNumber);
            Assert.Equal(metadata.ImagePath, _viewModel.ImagePath);
            Assert.Equal(metadata.ImageUrl, _viewModel.ImageUrl);
            Assert.Equal(metadata.LastPlayed, _viewModel.LastPlayed);
            Assert.Equal(metadata.Playcount, _viewModel.PlayCount);
            Assert.Equal(metadata.Plot, _viewModel.Plot);
            Assert.Equal(metadata.Rating, _viewModel.Rating);
            Assert.Equal(metadata.SeasonNumber, _viewModel.SeasonNumber);
            Assert.Equal(metadata.Title, _viewModel.Title);
            return true;
        }
    }
}
