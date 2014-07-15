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

        public Season GetSeason(string tvShowPath, string seasonFolder)
        {
            return CreateSeason(tvShowPath, seasonFolder);
        }

        public IEnumerable<Season> GetSeasons(string tvShowPath)
        {
            if(string.IsNullOrEmpty(tvShowPath)) throw new ArgumentNullException("tvShowPath");

            return GetUnorderedSeasons(tvShowPath)
                .OrderBy(season => season.SeasonNumber);
        }

        public IEnumerable<Episode> GetEpisodes(string seasonPath)
        {
            if (string.IsNullOrEmpty(seasonPath)) throw new ArgumentNullException("seasonPath");

            return GetUnorderedEpisodes(seasonPath)
                .OrderBy(episode => episode.SeasonNumber)
                .ThenBy(episode => episode.EpisodeNumber);
        }

        private IEnumerable<Season> GetUnorderedSeasons(string tvShowPath)
        {
            IEnumerable<string> folders = GetSeasonFolders(tvShowPath);
            foreach (string seasonFolder in folders)
            {
                yield return CreateSeason(tvShowPath, seasonFolder);
            }
        }

        private IEnumerable<string> GetSeasonFolders(string path)
        {
            IEnumerable<string> normalSeasons = _fileSystemService.FindDirectories(path, "Season *");
            IEnumerable<string> specialSeasons = _fileSystemService.FindDirectories(path, "Special*");
            return normalSeasons.Union(specialSeasons);
        }

        private static Season CreateSeason(string tvShowPath, string seasonFolder)
        {
            Season season = new Season();
            season.Path = seasonFolder;
            season.SeasonNumber = TvShowHelper.FindSeasonNumberFromFolder(seasonFolder);
            season.PosterUrl = TvShowHelper.GetSeasonImageFileName(tvShowPath, season.SeasonNumber, "poster");
            season.BannerUrl = TvShowHelper.GetSeasonImageFileName(tvShowPath, season.SeasonNumber, "banner");
            return season;
        }

        private IEnumerable<Episode> GetUnorderedEpisodes(string seasonPath)
        {
            IEnumerable<string> videoFiles = _fileSystemService.FindVideoFiles(seasonPath);
            foreach (string episodeFile in videoFiles)
            {
                yield return CreateEpisode(episodeFile);
            }
        }

        private Episode CreateEpisode(string episodeFile)
        {
            Episode episode = new Episode();
            EpisodeNumber episodeNumber = TvShowHelper.FindEpisodeNumberFromFile(_fileSystemService, episodeFile);
            episode.Path = episodeFile;
            episode.SeasonNumber = episodeNumber.SeasonNumber;
            episode.EpisodeNumber = episodeNumber.EpisodeSeasonNumber;
            return episode;
        }
    }
}
