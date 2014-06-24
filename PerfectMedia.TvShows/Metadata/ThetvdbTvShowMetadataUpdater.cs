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
    }
}
