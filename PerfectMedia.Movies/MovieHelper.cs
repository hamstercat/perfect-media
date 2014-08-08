using System.Configuration;
using System.IO;

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

        private static string MovieSetFolder
        {
            get
            {
                return ConfigurationManager.AppSettings["MovieSetArtworkFolder"];
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

        internal static string GetMovieSetFanartPath(string setName)
        {
            return Path.Combine(MovieSetFolder, setName + "-fanart.jpg");
        }

        internal static string GetMovieSetPosterPath(string setName)
        {
            return Path.Combine(MovieSetFolder, setName + "-poster.jpg");
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
