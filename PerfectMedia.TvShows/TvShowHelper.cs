﻿using System;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

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
            if (string.IsNullOrEmpty(relativePath))
            {
                return string.Empty;
            }

            string imageRelativePath = "banners";
            if (!relativePath.StartsWith("/"))
            {
                imageRelativePath += "/";
            }
            imageRelativePath += relativePath;
            return new Uri(new Uri(TheTvDbUrl), imageRelativePath).ToString();
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
        internal static EpisodeNumber FindEpisodeNumberFromFile(IFileSystemService fileSystemService, string episodeFile)
        {
            string episodeFileName = Path.GetFileNameWithoutExtension(episodeFile);
            Match match = Regex.Match(episodeFileName, @"(\d)x(\d+)");
            if (match.Success)
            {
                int seasonNumber = int.Parse(match.Groups[1].Value);
                int episodeNumber = int.Parse(match.Groups[2].Value);
                string tvShowPath = fileSystemService.GetParentFolder(episodeFile, 2);
                return new EpisodeNumber
                {
                    SeasonNumber = seasonNumber,
                    EpisodeSeasonNumber = episodeNumber,
                    TvShowPath = tvShowPath
                };
            }
            return null;
        }

        internal static string GetSeasonName(int seasonNumber)
        {
            if (seasonNumber == 0)
            {
                return "Specials";
            }
            return "Season " + seasonNumber;
        }
    }
}
