using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NSubstitute;
using PerfectMedia.UI.Movies;
using PerfectMedia.UI.Progress;
using Xunit;

namespace PerfectMedia.UI.Metadata
{
    public class UpdateAllMetadataCommandTests
    {
        private readonly ObservableCollection<IMovieViewModel> _movies;
        private readonly IProgressManagerViewModel _progressManager;
        private readonly UpdateAllMetadataCommand<IMovieViewModel> _command;

        public UpdateAllMetadataCommandTests()
        {
            _movies = new ObservableCollection<IMovieViewModel>();
            _progressManager = Substitute.For<IProgressManagerViewModel>();
            _command = new UpdateAllMetadataCommand<IMovieViewModel>(_movies, _progressManager);
        }

        [Fact]
        public void CanExecute_WithoutTvShows_ReturnsFalse()
        {
            // Act
            bool canExecute = _command.CanExecute(null);

            // Assert
            Assert.False(canExecute);
        }

        [Fact]
        public void CanExecute_WithTvShows_ReturnsTrue()
        {
            // Arrange
            _movies.Add(null);

            // Act
            bool canExecute = _command.CanExecute(null);

            // Assert
            Assert.True(canExecute);
        }

        [Fact]
        public void Execute_WithoutTvShows_DoesNothing()
        {
            // Act
            _command.Execute(null);
        }

        [Fact]
        public void Execute_WithTvShows_QueuesUpdates()
        {
            // Arrange
            IMovieViewModel viewModel1 = Substitute.For<IMovieViewModel>();
            _movies.Add(viewModel1);
            IEnumerable<ProgressItem> items = new List<ProgressItem> { CreateProgressItem() };
            viewModel1.Update()
                .Returns(items.ToTask());

            // Act
            _command.Execute(null);

            // Assert
            _progressManager.Received()
                .AddItem(Arg.Any<ProgressItem>());
            _progressManager.Received()
                .Start().Async();
        }

        private ProgressItem CreateProgressItem()
        {
            return new ProgressItem(null, null);
        }
    }
}
