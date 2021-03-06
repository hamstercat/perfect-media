﻿using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using PerfectMedia.Music.Albums;

namespace PerfectMedia.Music
{
    internal static class MusicHelper
    {
        internal const int DefaultPageSize = 100;

        internal static string FanartTvApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings["FanartTvApiKey"];
            }
        }

        internal static string FindArtistNameFromFolder(string path)
        {
            return Path.GetFileName(path);
        }

        internal static Album FindAlbumFromFolder(string path)
        {
            string folderName = Path.GetFileName(path);
            var match = Regex.Match(folderName, @"\[(\d+)\]\s*(.*)");
            if (match.Success)
            {
                int year;
                if (int.TryParse(match.Groups[1].Value, out year))
                {
                    return new Album
                    {
                        Title = match.Groups[2].Value,
                        Year = year
                    };
                }
            }
            return new Album { Title = folderName };
        }

        internal static string GetArtistImage(string path)
        {
            return Path.Combine(path, "fanart.jpg");
        }

        internal static string GetAlbumImage(string path)
        {
            return Path.Combine(path, "folder.jpg");
        }
    }
}
