using NSubstitute;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Movies;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Shows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.UI.Metadata
{
    public class UpdateAllMetadataCommandTests
    {
        private readonly SmartObservableCollection<IMovieViewModel> _movies;
        private IProgressManagerViewModel _progressManager;
        private readonly UpdateAllMetadataCommand<IMovieViewModel> _command;

        public UpdateAllMetadataCommandTests()
        {
            _movies = new SmartObservableCollection<IMovieViewModel>();
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
        public void CanExecuteChanged_WhenAddingTvShow_Triggers()
        {
            // Arrange
            bool canExecuteChanged = false;
            _command.CanExecuteChanged += (s, e) => canExecuteChanged = true;

            // Act
            _movies.Add(null);

            // Assert
            Assert.True(canExecuteChanged);
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
            viewModel1.Update()
                .Returns(new List<ProgressItem> { CreateProgressItem() });

            // Act
            _command.Execute(null);

            // Assert
            _progressManager.Received()
                .AddItem(Arg.Any<ProgressItem>());
            _progressManager.Received()
                .Start();
        }

        private ProgressItem CreateProgressItem()
        {
            Lazy<string> displayName = new Lazy<string>(() => "Dinosaur");
            Task task = new Task(() =>
            {
                throw new Exception();
            });
            return new ProgressItem(null, null);
        }
    }
}
