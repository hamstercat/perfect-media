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
    public class TvShowLocalMetadataService : ITvShowLocalMetadataService
    {
        private const string NfoFile = "tvshow.nfo";

        private readonly IFileSystemService _fileSystemService;

        public TvShowLocalMetadataService(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        public TvShowMetadata GetLocalMetadata(string path)
        {
            string nfoFileFullPath = Path.Combine(path, NfoFile);
            if (!File.Exists(nfoFileFullPath))
            {
                return new TvShowMetadata();
            }

            using (XmlReader reader = XmlReader.Create(nfoFileFullPath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TvShowMetadata));
                return (TvShowMetadata)serializer.Deserialize(reader);
            }
        }

        public void SaveLocalMetadata(string path, TvShowMetadata metadata)
        {
            string nfoFileFullPath = Path.Combine(path, NfoFile);
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };
            using (XmlWriter writer = XmlWriter.Create(nfoFileFullPath, xmlWriterSettings))
            {
                writer.WriteRaw("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>\r\n"); 

                XmlSerializer serializer = new XmlSerializer(typeof(TvShowMetadata));
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                serializer.Serialize(writer, metadata, namespaces);
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

        public void SaveFanart(string path, string imageUrl)
        {
            string fanartPath = Path.Combine(path, "fanart.jpg");
            _fileSystemService.DownloadFile(fanartPath, imageUrl);
        }

        public void SavePoster(string path, string imageUrl)
        {
            string fanartPath = Path.Combine(path, "poster.jpg");
            _fileSystemService.DownloadFile(fanartPath, imageUrl);
        }

        public void SaveBanner(string path, string imageUrl)
        {
            string fanartPath = Path.Combine(path, "banner.jpg");
            _fileSystemService.DownloadFile(fanartPath, imageUrl);
        }

        public IEnumerable<SeasonImages> GetLocalSeasonImages(string path)
        {
            foreach (string season in _fileSystemService.FindFolders(path, "Season *"))
            {
                SeasonImages seasonImages;
                if (TryCreateSeasonImages(path, season, out seasonImages))
                {
                    yield return seasonImages;
                }
            }
            foreach (string season in _fileSystemService.FindFolders(path, "Special*"))
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
