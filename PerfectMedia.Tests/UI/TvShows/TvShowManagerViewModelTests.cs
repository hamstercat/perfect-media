﻿using System.Collections.ObjectModel;
using NSubstitute;
using PerfectMedia.Sources;
using PerfectMedia.UI.Sources;
using PerfectMedia.UI.TvShows.Shows;
using Xunit;

namespace PerfectMedia.UI.TvShows
{
    public class TvShowManagerViewModelTests
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly ISourceManagerViewModel _sourceManagerViewModel;
        private readonly TvShowManagerViewModel _viewModel;

        public TvShowManagerViewModelTests()
        {
            _sourceManagerViewModel = Substitute.For<ISourceManagerViewModel>();
            _sourceManagerViewModel.SpecificFolders
                .Returns(new ObservableCollection<string>());

            _viewModelFactory = Substitute.For<ITvShowViewModelFactory>();
            _viewModelFactory.GetSourceManager(SourceType.TvShow)
                .Returns(_sourceManagerViewModel);

            _viewModel = new TvShowManagerViewModel(_viewModelFactory, null);
        }

        [Fact]
        public void Constructor_Always_LoadsSources()
        {
            // Assert
            _sourceManagerViewModel.Received()
                .Load();
        }

        [Fact]
        public void Sources_AddsSpecificFolder_AddsNewTvShow()
        {
            // Act
            _sourceManagerViewModel.SpecificFolders.Add(@"C:\Folder\TV Shows\Game of Thrones");

            // Assert
            Assert.NotEmpty(_viewModel.TvShows);
        }

        [Fact]
        public void Sources_RemovesSpecificFolder_RemovesTvShow()
        {
            // Arrange
            const string folder = @"C:\Folder\TV Shows\Game of Thrones";

            ITvShowViewModel tvShowViewModel = Substitute.For<ITvShowViewModel>();
            tvShowViewModel.Path.Returns(folder);
            _viewModelFactory.GetTvShow(folder)
                .Returns(tvShowViewModel);

            _sourceManagerViewModel.SpecificFolders.Add(folder);

            // Act
            _sourceManagerViewModel.SpecificFolders.Remove(folder);

            // Assert
            Assert.Empty(_viewModel.TvShows);
        }

        [Fact]
        public void Sources_ClearSpecificFolder_RemovesAllTvShow()
        {
            // Arrange
            _sourceManagerViewModel.AddRootFolder(@"C:\Folder1");
            _sourceManagerViewModel.AddRootFolder(@"C:\Folder2");
            _sourceManagerViewModel.AddRootFolder(@"C:\Folder3");

            // Act
            _sourceManagerViewModel.SpecificFolders.Clear();

            // Assert
            Assert.Empty(_viewModel.TvShows);
        }
    }
}
