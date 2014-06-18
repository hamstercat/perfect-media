using PerfectMedia.Metadata.TheTvDbDataContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Metadata
{
    public class SeasonMetadataService : ISeasonMetadataService
    {
        private readonly IRestApiWrapper _restApiWrapper;
        private readonly IFileSystemService _fileSystemService;

        public SeasonMetadataService(IRestApiWrapper restApiWrapper, IFileSystemService fileSystemService)
        {
            _restApiWrapper = restApiWrapper;
            _fileSystemService = fileSystemService;
        }

        public void UpdateMetadata(string path, string seriesId)
        {
            string url = string.Format("api/{0}/series/{1}/banners.xml", TvShowHelper.TheTvDbApiKey, seriesId);
            List<Banner> banners = _restApiWrapper.Get<List<Banner>>(url);

            foreach (string season in _fileSystemService.FindSeasonFolders(path))
            {
                SaveSeasonPoster(banners, season);
            }
        }

        private void SaveSeasonPoster(List<Banner> banners, string season)
        {
            int seasonNumber = TvShowHelper.FindSeasonNumberFromFolder(season);
            if (seasonNumber != -1)
            {
                string posterUrl = FindPosterForSeason(banners, seasonNumber);
                if (!string.IsNullOrEmpty(posterUrl))
                {
                    DownloadSeasonPoster(season, seasonNumber, posterUrl);
                }
            }
        }

        private string FindPosterForSeason(List<Banner> banners, int seasonNumber)
        {
            Banner banner = banners
                .OrderByDescending(ban => ban.Rating)
                .FirstOrDefault(ban => ban.BannerType == "season"
                    && ban.Season == seasonNumber.ToString()
                    && ban.Language == "en");
            if (banner != null)
            {
                return TvShowHelper.ExpandImagesUrl(banner.BannerPath);
            }
            return string.Empty;
        }

        private void DownloadSeasonPoster(string season, int seasonNumber, string posterUrl)
        {
            string folder = Path.GetDirectoryName(season);
            string posterPath = TvShowHelper.GetSeasonImageFileName(folder, seasonNumber, "poster");
            if (!File.Exists(posterPath))
            {
                _fileSystemService.DownloadFile(posterPath, posterUrl);
            }
        }
    }
}
