using NSubstitute;
using PerfectMedia.Sources;
using PerfectMedia.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.Tests.UI.ViewModels
{
    public class SourceManagerViewModelTests
    {
        private readonly ISourceRepository _sourceRepository;
        private readonly SourceManagerViewModel _viewModel;

        public SourceManagerViewModelTests()
        {
            _sourceRepository = Substitute.For<ISourceRepository>();
            _viewModel = new SourceManagerViewModel(_sourceRepository, SourceType.Music);
        }

        [Fact]
        public void Load_WithAvailableSources_AddsRootFoldersAndSpecificFolders()
        {
            // Arrange
            Source rootFolder = new Source { IsRoot = true, SourceType = SourceType.Music, Folder = @"C:\Folder" };
            Source specificFolder = new Source { IsRoot = false, SourceType = SourceType.Music, Folder = @"C:\Folder\Music" };
            List<Source> sources = new List<Source> { rootFolder, specificFolder };

            _sourceRepository.GetSources(SourceType.Music)
                .Returns(sources);

            // Act
            _viewModel.Load();

            // Assert
            Assert.Equal(1, _viewModel.RootFolders.Count);
            Assert.Equal(rootFolder.Folder, _viewModel.RootFolders[0]);

            Assert.Equal(1, _viewModel.SpecificFolders.Count);
            Assert.Equal(specificFolder.Folder, _viewModel.SpecificFolders[0]);
        }

        [Fact]
        public void Load_WithAvailableSources_DoesntSaveThoseSources()
        {
            Source rootFolder = new Source { IsRoot = true, SourceType = SourceType.Music, Folder = @"C:\Folder" };
            Source specificFolder = new Source { IsRoot = false, SourceType = SourceType.Music, Folder = @"C:\Folder\Music" };
            List<Source> sources = new List<Source> { rootFolder, specificFolder };

            _sourceRepository.GetSources(SourceType.Music)
                .Returns(sources);

            // Act
            _viewModel.Load();

            // Assert
            _sourceRepository.DidNotReceiveWithAnyArgs().Save(null);
        }

        [Fact]
        public void AddRootFolder_NewFolder_AddsRootFolder()
        {
            // Arrange
            string folder = @"C:\Folder\Music";

            // Act
            _viewModel.AddRootFolder(folder);

            // Assert
            Assert.Equal(1, _viewModel.RootFolders.Count);
            Assert.Equal(folder, _viewModel.RootFolders[0]);
        }

        [Fact]
        public void AddRootFolder_NewFolder_SavesThatFolder()
        {
            // Arrange
            string folder = @"C:\Folder\Music";

            // Act
            _viewModel.AddRootFolder(folder);

            // Assert
            _sourceRepository.Received()
                .Save(Arg.Is<Source>(source => source.Folder == folder && source.IsRoot && source.SourceType == SourceType.Music));
        }

        [Fact]
        public void AddRootFolder_ExistingFolder_DoesNothing()
        {
            // Arrange
            string folder = @"C:\Folder\Music";
            _viewModel.RootFolders.Add(folder);

            // Act
            _viewModel.AddRootFolder(folder);

            // Assert
            Assert.Equal(1, _viewModel.RootFolders.Count);
        }

        [Fact]
        public void AddSpecificFolder_NewFolder_AddsSpecificFolder()
        {
            // Arrange
            string folder = @"C:\Folder\Music\Artist";

            // Act
            _viewModel.AddSpecificFolder(folder);

            // Assert
            Assert.Equal(1, _viewModel.SpecificFolders.Count);
            Assert.Equal(folder, _viewModel.SpecificFolders[0]);
        }

        [Fact]
        public void AddSpecificFolder_NewFolder_SavesThatFolder()
        {
            // Arrange
            string folder = @"C:\Folder\Music";

            // Act
            _viewModel.AddSpecificFolder(folder);

            // Assert
            _sourceRepository.Received()
                .Save(Arg.Is<Source>(source => source.Folder == folder && !source.IsRoot && source.SourceType == SourceType.Music));
        }

        [Fact]
        public void AddSpecificFolder_ExistingFolder_DoesNothing()
        {
            // Arrange
            string folder = @"C:\Folder\Music\Artist";
            _viewModel.SpecificFolders.Add(folder);

            // Act
            _viewModel.AddSpecificFolder(folder);

            // Assert
            Assert.Equal(1, _viewModel.SpecificFolders.Count);
        }

        [Fact]
        public void RemoveRootFolder_Always_RemoveTheFolder()
        {
            // Arrange
            string folder = @"C:\Folder\Music";
            _viewModel.RootFolders.Add(folder);

            // Act
            _viewModel.RemoveRootFolder(folder);

            // Assert
            Assert.Equal(0, _viewModel.RootFolders.Count);
        }

        [Fact]
        public void RemoveRootFolder_Always_RemovesTheSavedFolder()
        {
            // Arrange
            string folder = @"C:\Folder\Music";
            _viewModel.RootFolders.Add(folder);

            // Act
            _viewModel.RemoveRootFolder(folder);

            // Assert
            _sourceRepository.Received()
                .Delete(Arg.Is<Source>(source => source.Folder == folder && source.IsRoot && source.SourceType == SourceType.Music));
        }

        [Fact]
        public void RemoveSpecificFolder_Always_RemoveTheFolder()
        {
            // Arrange
            string folder = @"C:\Folder\Music\Artist";
            _viewModel.SpecificFolders.Add(folder);

            // Act
            _viewModel.RemoveSpecificFolder(folder);

            // Assert
            Assert.Equal(0, _viewModel.SpecificFolders.Count);
        }

        [Fact]
        public void RemoveSpecificFolder_Always_RemovesTheSavedFolder()
        {
            // Arrange
            string folder = @"C:\Folder\Music";
            _viewModel.SpecificFolders.Add(folder);

            // Act
            _viewModel.RemoveSpecificFolder(folder);

            // Assert
            _sourceRepository.Received()
                .Delete(Arg.Is<Source>(source => source.Folder == folder && !source.IsRoot && source.SourceType == SourceType.Music));
        }

        [Fact(Skip = "Depends on filesystem")]
        public void RefreshSpecificFolders_WithRootFolder_AddsSpecificFolders()
        {

        }
    }
}
