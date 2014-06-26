using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows
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

        internal static int FindSeasonNumberFromFolder(string seasonFolder)
        {
            string seasonFolderName = Path.GetFileName(seasonFolder);
            Match match = Regex.Match(seasonFolderName, @"Season (\d+).*");
            if (match.Success)
            {
                string matchedSeasonNumber = match.Groups[1].Value;
                return int.Parse(matchedSeasonNumber);
            }

            if (seasonFolderName.StartsWith("Special"))
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

        // TODO: support multi-episode files
        internal static EpisodeNumber FindEpisodeNumberFromFile(string episodeFile)
        {
            string episodeFileName = Path.GetFileNameWithoutExtension(episodeFile);
            Match match = Regex.Match(episodeFileName, @"(\d)x(\d+)");
            if (match.Success)
            {
                int seasonNumber = int.Parse(match.Groups[1].Value);
                int episodeNumber = int.Parse(match.Groups[2].Value);
                string tvShowPath = GetParentDirectory(episodeFile, 2);
                return new EpisodeNumber
                {
                    SeasonNumber = seasonNumber,
                    EpisodeSeasonNumber = episodeNumber,
                    TvShowPath = tvShowPath
                };
            }
            return null;
        }

        internal static string[] GetVideoFileExtensions()
        {
            return new string[]
            {
                ".mkv", ".wmv", ".mov", ".avi"
            };
        }

        // This method comes from https://stackoverflow.com/questions/4389775/what-is-a-good-way-to-remove-last-few-directory
        // TODO: Rewrite it more clearly
        private static string GetParentDirectory(string path, int parentCount)
        {
            if (string.IsNullOrEmpty(path) || parentCount < 1)
                return path;

            string parent = System.IO.Path.GetDirectoryName(path);

            if (--parentCount > 0)
                return GetParentDirectory(parent, parentCount);

            return parent;
        }
    }
}
