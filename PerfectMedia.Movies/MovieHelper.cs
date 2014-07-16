using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private static string GetMovieImagePath(string path, string imageType)
        {
            string folder = Path.GetDirectoryName(path);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
            string fileName = string.Format("{0}-{1}.jpg", fileNameWithoutExtension, imageType);
            return Path.Combine(folder, fileName);
        }
    }
}
