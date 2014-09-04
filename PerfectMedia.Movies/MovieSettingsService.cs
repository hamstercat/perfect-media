using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectMedia.Movies.Properties;

namespace PerfectMedia.Movies
{
    public class MovieSettingsService : IMovieSettingsService
    {
        private readonly IFileSystemService _fileSystemService;

        public MovieSettingsService(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        public async Task<string> GetMovieSetArtworkFolder()
        {
            return await MovieHelper.GetMovieSetFolder(_fileSystemService);
        }

        public void SetMovieSetArtworkFolder(string folder)
        {
            Settings.Default.MovieSetArtworkFolder = folder;
            Settings.Default.Save();
        }
    }
}
