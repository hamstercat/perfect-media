using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using Anotar.Log4Net;
using PerfectMedia.Movies.Properties;

namespace PerfectMedia.Movies
{
    internal static class MovieHelper
    {
        internal static string ThemoviedbApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings["ThemoviedbApiKey"];
            }
        }

        internal static string GetMoviePosterPath(string path)
        {
            return GetMovieImagePath(path, "poster");
        }

        internal static string GetMovieFanartPath(string path)
        {
            return GetMovieImagePath(path, "fanart");
        }

        internal static async Task<string> GetMovieSetFanartPath(IFileSystemService fileSystemService, string setName)
        {
            string movieSetFolder = await GetMovieSetFolder(fileSystemService);
            return Path.Combine(movieSetFolder, setName + "-fanart.jpg");
        }

        internal static async Task<string> GetMovieSetPosterPath(IFileSystemService fileSystemService, string setName)
        {
            string movieSetFolder = await GetMovieSetFolder(fileSystemService);
            return Path.Combine(movieSetFolder, setName + "-poster.jpg");
        }

        internal static async Task<string> GetMovieSetFolder(IFileSystemService fileSystemService)
        {
            string movieSetFolder = Settings.Default.MovieSetArtworkFolder;
            if (string.IsNullOrEmpty(movieSetFolder) || !await fileSystemService.FolderExists(movieSetFolder))
            {
                movieSetFolder = SettingsHelper.GetAppDataFilePath("MovieSetArtwork");
            }
            return movieSetFolder;
        }

        private static string GetMovieImagePath(string path, string imageType)
        {
            string folder = Path.GetDirectoryName(path);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
            string fileName = string.Format("{0}-{1}.jpg", fileNameWithoutExtension, imageType);
            return Path.Combine(folder, fileName);
        }
    }
}
