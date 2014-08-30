using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using PerfectMedia.Movies;
using PerfectMedia.TvShows;
using Xunit;

namespace PerfectMedia.UI.Progress
{
    public class ProgressItemTests
    {
        private readonly ProgressItem _progressItem;
        private readonly string _uniqueKey;
        private readonly Lazy<string> _display;
        private readonly Func<Task> _func;

        public ProgressItemTests()
        {
            _uniqueKey = @"C:\TV Shows\Adventure Time";
            _display = new Lazy<string>(() => "Adventure Time");
            _func = Substitute.For<Func<Task>>();
            _progressItem = new ProgressItem(_uniqueKey, _display, _func);
        }

        [Fact]
        public void Display_WhenLazyStringWasGivenInConstructor_ReturnsTheName()
        {
            // Act
            string name = _progressItem.Display;

            // Assert
            Assert.Equal("Adventure Time", name);
        }

        [Fact]
        public async Task Execute_ExecutionCompleteSuccesfully_DoesntSetError()
        {
            // Act
            await _progressItem.Execute();

            // Assert
            Assert.True(string.IsNullOrEmpty(_progressItem.Error));
        }

        [Fact]
        public async Task Execute_WhenEpisodeIsNotFound_SetsErrorMessage()
        {
            // Arrange
            _func().Returns(x => { throw new EpisodeNotFoundException(); });

            // Act
            await _progressItem.Execute();

            // Assert
            Assert.Contains("Episode", _progressItem.Error);
        }

        [Fact]
        public async Task Execute_WhenTvShowIsNotFound_SetsErrorMessage()
        {
            // Arrange
            _func().Returns(x => { throw new TvShowNotFoundException(); });

            // Act
            await _progressItem.Execute();

            // Assert
            Assert.Contains("TV Show", _progressItem.Error);
        }

        [Fact]
        public async Task Execute_WhenMovieIsNotFound_SetsErrorMessage()
        {
            // Arrange
            _func().Returns(x => { throw new MovieNotFoundException(); });

            // Act
            await _progressItem.Execute();

            // Assert
            Assert.Contains("Movie", _progressItem.Error);
        }

        [Fact]
        public async Task Execute_WhenAnUnknownErrorOccurs_SetsErrorMessage()
        {
            // Arrange
            _func().Returns(x => { throw new InvalidOperationException(); });

            // Act
            await _progressItem.Execute();

            // Assert
            Assert.Contains("log", _progressItem.Error);
        }
    }
}
