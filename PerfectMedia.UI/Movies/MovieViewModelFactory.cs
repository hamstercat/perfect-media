using PerfectMedia.Sources;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Movies
{
    public class MovieViewModelFactory : IMovieViewModelFactory
    {
        private readonly ISourceService _sourceService;
        private readonly IFileSystemService _fileSystemService;
        private readonly IProgressManagerViewModel _progressManager;

        public MovieViewModelFactory(ISourceService sourceService, IFileSystemService fileSystemService, IProgressManagerViewModel progressManager)
        {
            _sourceService = sourceService;
            _fileSystemService = fileSystemService;
            _progressManager = progressManager;
        }

        public ISourceManagerViewModel GetSourceManager()
        {
            return new SourceManagerViewModel(_sourceService, _fileSystemService, SourceType.Movie);
        }

        public IMovieViewModel GetMovie(string path)
        {
            return new MovieViewModel(_progressManager, path);
        }
    }
}
