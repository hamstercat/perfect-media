using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using PerfectMedia.Sources;
using PerfectMedia.UI.Busy;
using Xunit;

namespace PerfectMedia.UI.Sources
{
    public class SourceManagerViewModelTests
    {
        private readonly ISourceService _sourceService;
        private readonly IFileSystemService _fileSystemService;
        private readonly SourceManagerViewModel _viewModel;
        private readonly IBusyProvider _busyProvider;

        public SourceManagerViewModelTests()
        {
            _sourceService = Substitute.For<ISourceService>();
            _fileSystemService = Substitute.For<IFileSystemService>();
            _busyProvider = Substitute.For<IBusyProvider>();
            _viewModel = new SourceManagerViewModel(_sourceService, _fileSystemService, _busyProvider, SourceType.Music);
        }

        [Fact]
        public void Load_WithAvailableSources_AddsRootFoldersAndSpecificFolders()
        {
            // Arrange
            Source rootFolder = new Source { IsRoot = true, SourceType = SourceType.Music, Folder = @"C:\Folder" };
            Source specificFolder = new Source { IsRoot = false, SourceType = SourceType.Music, Folder = @"C:\Folder\Music" };
            IEnumerable<Source> sources = new List<Source> { rootFolder, specificFolder };

            _sourceService.GetSources(SourceType.Music)
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
            IEnumerable<Source> sources = new List<Source> { rootFolder, specificFolder };

            _sourceService.GetSources(SourceType.Music)
                .Returns(sources);

            // Act
            _viewModel.Load();

            // Assert
            _sourceService.DidNotReceiveWithAnyArgs()
                .Add(null);
        }

        [Fact]
        public void AddRootFolder_NewFolder_AddsRootFolder()
        {
            // Arrange
            const string folder = @"C:\Folder\Music";

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
            const string folder = @"C:\Folder\Music";

            // Act
            _viewModel.AddRootFolder(folder);

            // Assert
            _sourceService.Received()
                .Add(Arg.Is<Source>(source => source.Folder == folder && source.IsRoot && source.SourceType == SourceType.Music));
        }

        [Fact]
        public void AddRootFolder_ExistingFolder_DoesNothing()
        {
            // Arrange
            const string folder = @"C:\Folder\Music";
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
            const string folder = @"C:\Folder\Music\Artist";

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
            const string folder = @"C:\Folder\Music";

            // Act
            _viewModel.AddSpecificFolder(folder);

            // Assert
            _sourceService.Received()
                .Add(Arg.Is<Source>(source => source.Folder == folder && !source.IsRoot && source.SourceType == SourceType.Music));
        }

        [Fact]
        public void AddSpecificFolder_ExistingFolder_DoesNothing()
        {
            // Arrange
            const string folder = @"C:\Folder\Music\Artist";
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
            const string folder = @"C:\Folder\Music";
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
            const string folder = @"C:\Folder\Music";
            _viewModel.RootFolders.Add(folder);

            // Act
            _viewModel.RemoveRootFolder(folder);

            // Assert
            _sourceService.Received()
                .Remove(Arg.Is<Source>(source => source.Folder == folder && source.IsRoot && source.SourceType == SourceType.Music));
        }

        [Fact]
        public void RemoveSpecificFolder_Always_RemoveTheFolder()
        {
            // Arrange
            const string folder = @"C:\Folder\Music\Artist";
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
            const string folder = @"C:\Folder\Music";
            _viewModel.SpecificFolders.Add(folder);

            // Act
            _viewModel.RemoveSpecificFolder(folder);

            // Assert
            _sourceService.Received()
                .Remove(Arg.Is<Source>(source => source.Folder == folder && !source.IsRoot && source.SourceType == SourceType.Music));
        }

        [Fact]
        public async Task RefreshSpecificFolders_WithRootFolder_AddsSpecificFolders()
        {
            // Arrange
            const string folder = @"C:\Folder\Music\";
            _viewModel.RootFolders.Add(folder);

            IEnumerable<string> artistFolders = new List<string>
            {
                @"C:\Folder\Music\Billy Talent",
                @"C:\Folder\Music\Cobra Starship",
                @"C:\Folder\Music\Linkin Park"
            };
            _fileSystemService.FindDirectories(folder)
                .Returns(artistFolders.ToTask());

            // Act
            await _viewModel.RefreshSpecificFolders();

            // Assert
            Assert.Equal(artistFolders, _viewModel.SpecificFolders);
        }
    }
}
