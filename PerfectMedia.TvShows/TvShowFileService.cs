using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public async Task<TvShowImages> GetShowImages(string tvShowPath)
        {
            TvShowImages images = new TvShowImages();
            images.Fanart = Path.Combine(tvShowPath, "fanart.jpg");
            images.Poster = Path.Combine(tvShowPath, "poster.jpg");
            images.Banner = Path.Combine(tvShowPath, "banner.jpg");
            images.Seasons = await GetSeasons(tvShowPath);
            return images;
        }

        public Season GetSeason(string tvShowPath, string seasonFolder)
        {
            return CreateSeason(tvShowPath, seasonFolder);
        }

        public async Task<IEnumerable<Season>> GetSeasons(string tvShowPath)
        {
            if(string.IsNullOrEmpty(tvShowPath)) throw new ArgumentNullException("tvShowPath");

            IEnumerable<Season> seasons = await GetUnorderedSeasons(tvShowPath);
            return seasons.OrderBy(season => season.SeasonNumber);
        }

        public async Task<IEnumerable<Episode>> GetEpisodes(string seasonPath)
        {
            if (string.IsNullOrEmpty(seasonPath)) throw new ArgumentNullException("seasonPath");

            IEnumerable<Episode> episodes = await GetUnorderedEpisodes(seasonPath);
            return episodes.OrderBy(episode => episode.SeasonNumber)
                .ThenBy(episode => episode.EpisodeNumber);
        }

        private async Task<IEnumerable<Season>> GetUnorderedSeasons(string tvShowPath)
        {
            IEnumerable<string> folders = await GetSeasonFolders(tvShowPath);
            return folders.Select(seasonFolder => CreateSeason(tvShowPath, seasonFolder));
        }

        private async Task<IEnumerable<string>> GetSeasonFolders(string path)
        {
            IEnumerable<string> normalSeasons = await _fileSystemService.FindDirectories(path, "Season *");
            IEnumerable<string> specialSeasons = await _fileSystemService.FindDirectories(path, "Special*");
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

        private async Task<IEnumerable<Episode>> GetUnorderedEpisodes(string seasonPath)
        {
            IEnumerable<string> videoFiles = await _fileSystemService.FindVideoFiles(seasonPath);
            return videoFiles.Select(CreateEpisode);
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
