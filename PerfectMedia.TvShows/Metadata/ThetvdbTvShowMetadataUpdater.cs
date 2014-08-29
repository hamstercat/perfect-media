using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Anotar.Log4Net;
using PerfectMedia.ExternalApi;

namespace PerfectMedia.TvShows.Metadata
{
    public class ThetvdbTvShowMetadataUpdater : ITvShowMetadataUpdater
    {
        private readonly IRestApiService _restApiService;

        public ThetvdbTvShowMetadataUpdater(IRestApiService restApiService)
        {
            _restApiService = restApiService;
        }

        public async Task<IEnumerable<Series>> FindSeries(string name)
        {
            string url = string.Format("api/GetSeries.php?seriesname={0}&language=en", HttpUtility.UrlEncode(name));
            List<Series> series = await _restApiService.Get<List<Series>>(url);
            FixSeriesUrl(series);
            return series;
        }

        public async Task<FullSerie> GetTvShowMetadata(string serieId)
        {
            string url = string.Format("api/{0}/series/{1}/en.xml", TvShowHelper.TheTvDbApiKey, serieId);
            FullSerie fullSerie = await _restApiService.Get<FullSerie>(url);
            FixSerieUrl(fullSerie);
            return fullSerie;
        }

        public async Task<AvailableTvShowImages> FindImages(string serieId)
        {
            string url = string.Format("/api/{0}/series/{1}/banners.xml", TvShowHelper.TheTvDbApiKey, serieId);
            List<Banner> images = await _restApiService.Get<List<Banner>>(url);
            return MapBannersToAvailableTvShowImages(images);
        }

        public async Task<IEnumerable<Actor>> FindActors(string serieId)
        {
            string url = string.Format("api/{0}/series/{1}/actors.xml", TvShowHelper.TheTvDbApiKey, serieId);
            return await _restApiService.Get<List<Actor>>(url);
        }

        public async Task<EpisodeMetadata> GetEpisodeMetadata(string serieId, int seasonNumber, int episodeNumber)
        {
            string url = string.Format("api/{0}/series/{1}/default/{2}/{3}/en.xml", TvShowHelper.TheTvDbApiKey, serieId, seasonNumber, episodeNumber);
            Episode episode = await _restApiService.Get<Episode>(url);
            return MapEpisodeToMetadata(episode);
        }

        private void FixSeriesUrl(IEnumerable<Series> series)
        {
            foreach (Series serie in series)
            {
                serie.Banner = TvShowHelper.ExpandImagesUrl(serie.Banner);
            }
        }

        private void FixSerieUrl(FullSerie serie)
        {
            if (serie != null)
            {
                serie.Fanart = TvShowHelper.ExpandImagesUrl(serie.Fanart);
                serie.Banner = TvShowHelper.ExpandImagesUrl(serie.Banner);
                serie.Poster = TvShowHelper.ExpandImagesUrl(serie.Poster);
            }
        }

        private AvailableTvShowImages MapBannersToAvailableTvShowImages(IEnumerable<Banner> banners)
        {
            AvailableTvShowImagesMapper mapper = new AvailableTvShowImagesMapper(banners);
            return mapper.Map();
        }

        private EpisodeMetadata MapEpisodeToMetadata(Episode episode)
        {
            return new EpisodeMetadata
            {
                AiredDate = episode.FirstAired,
                Credits = SplitStringList(episode.Writer).ToList(),
                Director = SplitStringList(episode.Director).ToList(),
                // TODO: check the 2 following properties
                DisplayEpisode = episode.AirsBeforeEpisode,
                DisplaySeason = episode.AirsBeforeSeason,
                EpisodeNumber = episode.EpisodeNumber,
                ImageUrl = TvShowHelper.ExpandImagesUrl(episode.Filename),
                Plot = episode.Overview,
                Rating = episode.Rating,
                SeasonNumber = episode.SeasonNumber,
                Title = episode.EpisodeName,
            };
        }

        private static IEnumerable<string> SplitStringList(string pipeDelimitedString)
        {
            return pipeDelimitedString.Split('|')
                .Select(str => str.Trim())
                .Where(trimmedString => !string.IsNullOrEmpty(trimmedString));
        }
    }
}
