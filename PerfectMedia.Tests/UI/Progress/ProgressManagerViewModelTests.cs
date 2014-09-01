using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using PerfectMedia.TvShows;
using PerfectMedia.UI.Busy;
using Xunit;

namespace PerfectMedia.UI.Progress
{
    public class ProgressManagerViewModelTests
    {
        private readonly ProgressManagerViewModel _viewModel;
        private readonly IProgressIndicatorFactory _progressIndicatorFactory;
        private readonly IProgressIndicator _progressIndicator;
        private readonly IBusyProvider _busyProvider;
        private readonly List<Func<Task>> _progressItemActions;

        public ProgressManagerViewModelTests()
        {
            _progressIndicatorFactory = Substitute.For<IProgressIndicatorFactory>();
            _progressIndicator = Substitute.For<IProgressIndicator>();
            _progressIndicatorFactory.CreateProgressIndicator()
                .Returns(_progressIndicator);
            _busyProvider = Substitute.For<IBusyProvider>();
            _progressItemActions = new List<Func<Task>>();
            _viewModel = new ProgressManagerViewModel(_progressIndicatorFactory, _busyProvider);
        }

        [Fact]
        public void AddItem_WhenCollecting_AddsNewItemToTotal()
        {
            // Arrange
            ProgressItem progressItem = CreateProgressItem();

            // Act
            _viewModel.AddItem(progressItem);

            // Assert
            Assert.Contains(progressItem, _viewModel.Total);
        }

        [Fact]
        public void AddItem_WhenCollectingAndSimilarItemWasAlreadyAdded_DoesntAddItToTotal()
        {
            // Arrange
            ProgressItem progressItem1 = CreateProgressItem();
            ProgressItem progressItem2 = CreateProgressItem();
            _viewModel.AddItem(progressItem1);

            // Act
            _viewModel.AddItem(progressItem2);

            // Assert
            Assert.DoesNotContain(progressItem2, _viewModel.Total);
        }

        [Fact]
        public void AddItem_WhenNotCollecting_ClearOldItems()
        {
            // Arrange
            ProgressItem progressItem1 = CreateProgressItem();
            _viewModel.Total.Add(progressItem1);
            _viewModel.Completed.Add(progressItem1);
            _viewModel.InError.Add(progressItem1);
            ProgressItem progressItem2 = CreateProgressItem();

            // Act
            _viewModel.AddItem(progressItem2);

            // Assert
            Assert.DoesNotContain(progressItem1, _viewModel.Total);
            Assert.DoesNotContain(progressItem1, _viewModel.Completed);
            Assert.DoesNotContain(progressItem1, _viewModel.InError);
        }

        [Fact]
        public void AddItem_WhenNotCollecting_ShowProgressIndicator()
        {
            // Arrange
            ProgressItem progressItem1 = CreateProgressItem();
            _viewModel.Total.Add(progressItem1);
            ProgressItem progressItem2 = CreateProgressItem();

            // Act
            _viewModel.AddItem(progressItem2);

            // Assert
            _progressIndicator.Received()
                .Show(Arg.Any<IProgressManagerViewModel>());
        }

        [Fact]
        public async Task Start_Always_StopsTheCollection()
        {
            // Arrange
            ProgressItem progressItem1 = CreateProgressItem();
            _viewModel.AddItem(progressItem1);

            // Act
            await _viewModel.Start();

            // Assert
            _viewModel.AddItem(CreateProgressItem());
            _progressIndicator.Received()
                .Show(Arg.Any<IProgressManagerViewModel>());
        }

        [Fact]
        public async Task Start_WithProgressItems_ExecutesThem()
        {
            // Arrange
            ProgressItem progressItem1 = CreateProgressItem();
            _viewModel.AddItem(progressItem1);
            ProgressItem progressItem2 = CreateProgressItem(@"C:\TV Shows\Game of Thrones", "Game of Thrones");
            _viewModel.AddItem(progressItem2);

            // Act
            await _viewModel.Start();

            // Assert
            _progressItemActions[0].Received()
                ().Async();
            _progressItemActions[1].Received()
                ().Async();
        }

        [Fact]
        public async Task Start_WithProgressItem_AddsItToCompleted()
        {
            // Arrange
            ProgressItem progressItem1 = CreateProgressItem();
            _viewModel.AddItem(progressItem1);

            // Act
            await _viewModel.Start();

            // Assert
            Assert.Contains(progressItem1, _viewModel.Completed);
        }

        [Fact]
        public async Task Start_WithProgressItemWithError_AddsItToCompleted()
        {
            // Arrange
            ProgressItem progressItem1 = CreateProgressItem();
            _viewModel.AddItem(progressItem1);
            _progressItemActions[0]()
                .Returns(x => { throw new EpisodeNotFoundException(); });

            // Act
            await _viewModel.Start();

            // Assert
            Assert.Contains(progressItem1, _viewModel.Completed);
        }

        [Fact]
        public async Task Start_WithProgressItemWithError_AddsItToInError()
        {
            // Arrange
            ProgressItem progressItem1 = CreateProgressItem();
            _viewModel.AddItem(progressItem1);
            _progressItemActions[0]()
                .Returns(x => { throw new EpisodeNotFoundException(); });

            // Act
            await _viewModel.Start();

            // Assert
            Assert.Contains(progressItem1, _viewModel.InError);
        }

        private ProgressItem CreateProgressItem(string uniqueKey = null, string displayName = null)
        {
            uniqueKey = uniqueKey ?? @"C:\TV Shows\Adventure Time";
            Lazy<string> display = new Lazy<string>(() => displayName ?? "Adventure Time");
            Func<Task> action = Substitute.For<Func<Task>>();
            _progressItemActions.Add(action);
            return new ProgressItem(uniqueKey, display, action);
        }
    }
}
