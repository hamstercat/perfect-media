using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PerfectMedia.Metadata
{
    public class TvShowMetadataService : ITvShowMetadataService
    {
        private const string NfoFile = "tvshow.nfo";

        private readonly IFileFinder _fileFinder;

        public TvShowMetadataService(IFileFinder fileFinder)
        {
            _fileFinder = fileFinder;
        }

        public TvShowMetadata GetLocalMetadata(string path)
        {
            string nfoFileFullPath = Path.Combine(path, NfoFile);
            using (XmlReader reader = XmlReader.Create(nfoFileFullPath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TvShowMetadata));
                return (TvShowMetadata)serializer.Deserialize(reader);
            }
        }

        public TvShowImages GetLocalImages(string path)
        {
            TvShowImages images = new TvShowImages();
            images.FanartUrl = Path.Combine(path, "fanart.jpg");
            images.PosterUrl = Path.Combine(path, "poster.jpg");
            images.BannerUrl = Path.Combine(path, "banner.jpg");
            return images;
        }

        public IEnumerable<SeasonImages> GetLocalSeasonImages(string path)
        {
            foreach (string season in _fileFinder.FindFolders(path, "Season *"))
            {
                SeasonImages seasonImages;
                if (TryCreateSeasonImages(path, season, out seasonImages))
                {
                    yield return seasonImages;
                }
            }
            foreach (string season in _fileFinder.FindFolders(path, "Special*"))
            {
                SeasonImages seasonImages;
                if (TryCreateSeasonImages(path, season, out seasonImages))
                {
                    yield return seasonImages;
                }
            }
        }

        private bool TryCreateSeasonImages(string path, string season, out SeasonImages seasonImages)
        {
            seasonImages = new SeasonImages();
            seasonImages.SeasonNumber = FindSeasonNumberFromFolder(season);
            if (seasonImages.SeasonNumber == -1)
            {
                seasonImages = null;
                return false;
            }

            if (seasonImages.SeasonNumber == 0)
            {
                seasonImages.PosterUrl = Path.Combine(path, "season-specials-poster.jpg");
                seasonImages.BannerUrl = Path.Combine(path, "season-specials-banner.jpg");
            }
            else
            {
                seasonImages.PosterUrl = Path.Combine(path, string.Format("season{0:D2}-poster.jpg", seasonImages.SeasonNumber));
                seasonImages.BannerUrl = Path.Combine(path, string.Format("season{0:D2}-banner.jpg", seasonImages.SeasonNumber));
            }
            return true;
        }

        private int FindSeasonNumberFromFolder(string season)
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
    }
}
