using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows
{
    public class TvShowFileService : ITvShowFileService
    {
        private readonly IFileSystemService _fileSystemService;

        public TvShowFileService(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        public TvShowImages GetShowImages(string tvShowPath)
        {
            TvShowImages images = new TvShowImages();
            images.Fanart = Path.Combine(tvShowPath, "fanart.jpg");
            images.Poster = Path.Combine(tvShowPath, "poster.jpg");
            images.Banner = Path.Combine(tvShowPath, "banner.jpg");
            images.Seasons = GetSeasons(tvShowPath);
            return images;
        }

        public IEnumerable<Season> GetSeasons(string tvShowPath)
        {
            if(string.IsNullOrEmpty(tvShowPath)) throw new ArgumentNullException("tvShowPath");

            IEnumerable<string> folders = GetSeasonFolders(tvShowPath);
            foreach (string seasonFolder in folders)
            {
                Season season = new Season();
                season.Path = seasonFolder;
                season.SeasonNumber = TvShowHelper.FindSeasonNumberFromFolder(seasonFolder);
                season.PosterUrl = TvShowHelper.GetSeasonImageFileName(tvShowPath, season.SeasonNumber, "poster");
                season.BannerUrl = TvShowHelper.GetSeasonImageFileName(tvShowPath, season.SeasonNumber, "banner");
                yield return season;
            }
        }

        public IEnumerable<Episode> GetEpisodes(string seasonPath)
        {
            if (string.IsNullOrEmpty(seasonPath)) throw new ArgumentNullException("seasonPath");

            IEnumerable<string> videoFiles = _fileSystemService.FindFiles(seasonPath, "*.mkv");
            foreach (string episodeFile in videoFiles)
            {
                yield return new Episode { Path = episodeFile };
            }
        }

        private IEnumerable<string> GetSeasonFolders(string path)
        {
            IEnumerable<string> normalSeasons = _fileSystemService.FindDirectories(path, "Season *");
            IEnumerable<string> specialSeasons = _fileSystemService.FindDirectories(path, "Special*");
            return normalSeasons.Union(specialSeasons);
        }
    }
}
