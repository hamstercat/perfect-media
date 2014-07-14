using NSubstitute;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Shows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.UI.TvShows
{
    public class FindNewEpisodesCommandTests
    {
        private readonly SmartObservableCollection<ITvShowViewModel> _tvShows;
        private IProgressManagerViewModel _progressManager;
        private readonly FindNewEpisodesCommand _command;

        public FindNewEpisodesCommandTests()
        {
            _tvShows = new SmartObservableCollection<ITvShowViewModel>();
            _progressManager = Substitute.For<IProgressManagerViewModel>();
            _command = new FindNewEpisodesCommand(_tvShows, _progressManager);
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
            _tvShows.Add(null);

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
            _tvShows.Add(null);

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
        public void Execute_WithTvShows_UpdatesTheseTvShows()
        {
            // Arrange
            ITvShowViewModel viewModel1 = Substitute.For<ITvShowViewModel>();
            _tvShows.Add(viewModel1);
            viewModel1.FindNewEpisodes()
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
            return new ProgressItem(null, null);
        }
    }
}
