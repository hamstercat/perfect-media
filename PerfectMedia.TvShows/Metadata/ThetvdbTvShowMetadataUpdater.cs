using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PerfectMedia.TvShows.Metadata
{
    public class ThetvdbTvShowMetadataUpdater : ITvShowMetadataUpdater
    {
        private readonly IRestApiService _restApiService;

        public ThetvdbTvShowMetadataUpdater(IRestApiService restApiService)
        {
            _restApiService = restApiService;
        }

        public IEnumerable<Series> FindSeries(string name)
        {
            string url = string.Format("api/GetSeries.php?seriesname={0}&language=en", HttpUtility.UrlEncode(name));
            return _restApiService.Get<List<Series>>(url);
        }

        public FullSerie GetTvShowMetadata(string serieId)
        {
            string url = string.Format("api/{0}/series/{1}/en.xml", TvShowHelper.TheTvDbApiKey, serieId);
            FullSerie fullSerie =  _restApiService.Get<FullSerie>(url);
            FixSerieUrl(fullSerie);
            return fullSerie;
        }

        public AvailableTvShowImages FindImages(string serieId)
        {
            string url = string.Format("/api/{0}/series/{1}/banners.xml", TvShowHelper.TheTvDbApiKey, serieId);
            List<Banner> images = _restApiService.Get<List<Banner>>(url);
            return MapBannersToAvailableTvShowImages(images);
        }

        public IEnumerable<Actor> FindActors(string serieId)
        {
            string url = string.Format("api/{0}/series/{1}/actors.xml", TvShowHelper.TheTvDbApiKey, serieId);
            return _restApiService.Get<List<Actor>>(url);
        }

        public EpisodeMetadata GetEpisodeMetadata(string serieId, int seasonNumber, int episodeNumber)
        {
            string url = string.Format("api/{0}/series/{1}/default/{2}/{3}/en.xml", TvShowHelper.TheTvDbApiKey, serieId, seasonNumber, episodeNumber);
            Episode episode = _restApiService.Get<Episode>(url);
            return MapEpisodeToMetadata(episode);
        }

        private void FixSerieUrl(FullSerie serie)
        {
            serie.Fanart = TvShowHelper.ExpandImagesUrl(serie.Fanart);
            serie.Banner = TvShowHelper.ExpandImagesUrl(serie.Banner);
            serie.Poster = TvShowHelper.ExpandImagesUrl(serie.Poster);
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
                Credits = episode.Writer.Split('|').ToList(),
                Director = episode.Director.Split('|').ToList(),
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
    }
}
