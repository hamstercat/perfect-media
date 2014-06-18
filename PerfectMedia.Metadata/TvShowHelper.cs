using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PerfectMedia.Metadata
{
    internal static class TvShowHelper
    {
        internal static string TheTvDbUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["TheTvDbUrl"];
            }
        }

        internal static string TheTvDbApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings["TheTvDbApiKey"];
            }
        }

        internal static int FindSeasonNumberFromFolder(string season)
        {
            string seasonFolder = Path.GetFileName(season);
            Match match = Regex.Match(seasonFolder, @"Season (\d+).*");
            if (match.Success)
            {
                string matchedSeasonNumber = match.Groups[1].Value;
                return int.Parse(matchedSeasonNumber);
            }

            if (seasonFolder.StartsWith("Special"))
            {
                return 0;
            }

            return -1;
        }

        internal static string ExpandImagesUrl(string relativePath)
        {
            string imageRelativePath = "banners";
            if (!relativePath.StartsWith("/"))
            {
                imageRelativePath += "/";
            }
            imageRelativePath += relativePath;
            return new Uri(new Uri(TvShowHelper.TheTvDbUrl), imageRelativePath).ToString();
        }

        internal static string GetSeasonImageFileName(string folder, int seasonNumber, string imageType)
        {
            string seasonFormat = "season{0:D2}";
            if (seasonNumber == 0)
            {
                seasonFormat = "season-specials";
            }
            string imageFileName = string.Format(seasonFormat + "-{1}.jpg", seasonNumber, imageType);
            return Path.Combine(folder, imageFileName);
        }
    }
}
