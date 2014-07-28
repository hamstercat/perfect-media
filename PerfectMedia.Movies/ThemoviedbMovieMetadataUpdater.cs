using Anotar.Log4Net;
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

        [LogToErrorOnException]
        public IEnumerable<Movie> FindMovies(string name)
        {
            string url = string.Format("3/search/movie?api_key={0}&query={1}",
                MovieHelper.ThemoviedbApiKey,
                HttpUtility.UrlEncode(name));
            SearchMovieResult result = _restApiService.Get<SearchMovieResult>(url);
            FixImagesUrl(result.Results);
            return result.Results;
        }

        [LogToErrorOnException]
        public FullMovie GetMovieMetadata(string movieId)
        {
            string url = string.Format("3/movie/{0}?api_key={1}", movieId, MovieHelper.ThemoviedbApiKey);
            FullMovie fullMovie = _restApiService.Get<FullMovie>(url);
            FixImagesUrl(fullMovie);
            return fullMovie;
        }

        [LogToErrorOnException]
        public AvailableMovieImages FindImages(string movieId)
        {
            string url = string.Format("3/movie/{0}/images?api_key={1}", movieId, MovieHelper.ThemoviedbApiKey);
            MovieImagesResult result = _restApiService.Get<MovieImagesResult>(url);
            return ConvertImagesResult(result);
        }

        [LogToErrorOnException]
        public AvailableMovieImages FindSetImages(string setName)
        {
            // TODO: refactor
            string searchCollectionUrl = string.Format("3/search/collection?query={0}&api_key={1}", setName, MovieHelper.ThemoviedbApiKey);
            SearchCollectionResult searchResult = _restApiService.Get<SearchCollectionResult>(searchCollectionUrl);
            MovieSet set = searchResult.Results.FirstOrDefault();
            if (set != null)
            {
                string getCollectionImagesUrl = string.Format("3/collection/{0}/images?api_key={1}", set.Id, MovieHelper.ThemoviedbApiKey);
                MovieImagesResult getImagesResult = _restApiService.Get<MovieImagesResult>(getCollectionImagesUrl);
                return ConvertImagesResult(getImagesResult);
            }
            return new AvailableMovieImages();
        }

        [LogToErrorOnException]
        public MovieActorsResult FindCast(string movieId)
        {
            string url = string.Format("3/movie/{0}/credits?api_key={1}", movieId, MovieHelper.ThemoviedbApiKey);
            MovieActorsResult actorsResult = _restApiService.Get<MovieActorsResult>(url);
            FixImagesUrl(actorsResult.Cast);
            return actorsResult;
        }

        [LogToErrorOnException]
        public string FindCertification(string movieId)
        {
            string url = string.Format("3/movie/{0}/releases?api_key={1}", movieId, MovieHelper.ThemoviedbApiKey);
            MovieCertificationResult result = _restApiService.Get<MovieCertificationResult>(url);
            return ConvertCertificationResult(result);
        }

        private string ConvertCertificationResult(MovieCertificationResult result)
        {
            CountryCertification certification = result.Countries.FirstOrDefault(cert => cert.Iso_3166_1 == "US");
            if(certification == null)
            {
                certification = result.Countries.FirstOrDefault();
                if (certification == null)
                {
                    return null;
                }
            }
            return "Rated " + certification.Certification;
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
                Size = string.Format("{0}x{1}", themoviedbImage.Width, themoviedbImage.Height),
                Rating = themoviedbImage.VoteAverage
            };
        }

        private void FixImagesUrl(IEnumerable<Movie> movies)
        {
            foreach (Movie movie in movies)
            {
                if (!string.IsNullOrEmpty(movie.BackdropPath))
                {
                    movie.BackdropPath = GetImageBasePath() + "original" + movie.BackdropPath;
                }
                if (!string.IsNullOrEmpty(movie.PosterPath))
                {
                    movie.PosterPath = GetImageBasePath() + "original" + movie.PosterPath;
                }
            }
        }

        private void FixImagesUrl(FullMovie fullMovie)
        {
            if (!string.IsNullOrEmpty(fullMovie.BackdropPath))
            {
                fullMovie.BackdropPath = GetImageBasePath() + "original" + fullMovie.BackdropPath;
            }
            if (!string.IsNullOrEmpty(fullMovie.PosterPath))
            {
                fullMovie.PosterPath = GetImageBasePath() + "original" + fullMovie.PosterPath;
            }
        }

        private void FixImagesUrl(IEnumerable<Cast> actors)
        {
            foreach (Cast actor in actors)
            {
                actor.ProfilePath = string.IsNullOrEmpty(actor.ProfilePath) ? null : GetImageBasePath() + "w300" + actor.ProfilePath;
            }
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
