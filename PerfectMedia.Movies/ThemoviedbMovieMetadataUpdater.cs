using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PerfectMedia.Movies
{
    public class ThemoviedbMovieMetadataUpdater : IMovieMetadataUpdater
    {
        private readonly IRestApiService _restApiService;
        private ThemoviedbConfiguration serverConfiguration;

        public ThemoviedbMovieMetadataUpdater(IRestApiService restApiService)
        {
            _restApiService = restApiService;
        }

        public IEnumerable<Movie> FindMovies(string name)
        {
            string url = string.Format("3/search/movie?api_key={0}&query={1}",
                MovieHelper.ThemoviedbApiKey,
                HttpUtility.UrlEncode(name));
            SearchMovieResult result = _restApiService.Get<SearchMovieResult>(url);
            return result.Results;
        }

        public FullMovie GetMovieMetadata(string movieId)
        {
            string url = string.Format("3/movie/{0}?api_key={1}", movieId, MovieHelper.ThemoviedbApiKey);
            return _restApiService.Get<FullMovie>(url);
        }

        public AvailableMovieImages FindImages(string movieId)
        {
            string url = string.Format("3/movie/{0}/images?api_key={1}", movieId, MovieHelper.ThemoviedbApiKey);
            MovieImagesResult result = _restApiService.Get<MovieImagesResult>(url);
            return ConvertImagesResult(result);
        }

        public IEnumerable<Actor> FindActors(string movieId)
        {
            string url = string.Format("3/movie/{0}/credits?api_key={1}", movieId, MovieHelper.ThemoviedbApiKey);
            MovieActorsResult result = _restApiService.Get<MovieActorsResult>(url);
            return ConvertActorsResult(result.Cast);
        }

        private AvailableMovieImages ConvertImagesResult(MovieImagesResult movieImagesResult)
        {
            AvailableMovieImages availableMovieImages = new AvailableMovieImages();
            availableMovieImages.Fanarts = movieImagesResult.Backdrops.Select(ConvertThemoviedbImage);
            availableMovieImages.Posters = movieImagesResult.Posters.Select(ConvertThemoviedbImage);
            return availableMovieImages;
        }

        private Image ConvertThemoviedbImage(ThemoviedbImage themoviedbImage)
        {
            return new Image
            {
                Url = GetImageBasePath() + "original" + themoviedbImage.FilePath,
                Size = string.Format("{0}x{1})", themoviedbImage.Width, themoviedbImage.Height),
                Rating = themoviedbImage.VoteAverage
            };
        }

        private IEnumerable<Actor> ConvertActorsResult(IEnumerable<Cast> list)
        {
            return list.Select(cast => new Actor
            {
                Name = cast.Name,
                Role = cast.Character,
                Image = GetImageBasePath() + "w300" + cast.ProfilePath
            });
        }

        private string GetImageBasePath()
        {
            if (serverConfiguration == null)
            {
                string url = "3/configuration?api_key=" + MovieHelper.ThemoviedbApiKey;
                serverConfiguration = _restApiService.Get<ThemoviedbConfiguration>(url);
            }
            return serverConfiguration.Images.SecureBaseUrl;
        }
    }
}
