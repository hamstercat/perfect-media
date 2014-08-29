using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Anotar.Log4Net;
using PerfectMedia.ExternalApi;

namespace PerfectMedia.Movies
{
    /// <summary>
    /// /// Retrieves movie metadata from themoviedb.org.
    /// </summary>
    public class ThemoviedbMovieMetadataUpdater : IMovieMetadataUpdater
    {
        private readonly IRestApiService _restApiService;
        private ThemoviedbConfiguration _serverConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemoviedbMovieMetadataUpdater"/> class.
        /// </summary>
        /// <param name="restApiService">The rest API service.</param>
        public ThemoviedbMovieMetadataUpdater(IRestApiService restApiService)
        {
            _restApiService = restApiService;
        }

        /// <summary>
        /// Finds the movies.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Movie>> FindMovies(string name)
        {
            string url = string.Format("3/search/movie?api_key={0}&query={1}",
                MovieHelper.ThemoviedbApiKey,
                HttpUtility.UrlEncode(name));
            SearchMovieResult result = await _restApiService.Get<SearchMovieResult>(url);
            await FixImagesUrl(result.Results);
            return result.Results;
        }

        /// <summary>
        /// Gets the movie metadata.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        /// <returns></returns>
        public async Task<FullMovie> GetMovieMetadata(string movieId)
        {
            string url = string.Format("3/movie/{0}?api_key={1}", movieId, MovieHelper.ThemoviedbApiKey);
            FullMovie fullMovie = await _restApiService.Get<FullMovie>(url);
            await FixImagesUrl(fullMovie);
            return fullMovie;
        }

        /// <summary>
        /// Finds the images.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        /// <returns></returns>
        public async Task<AvailableMovieImages> FindImages(string movieId)
        {
            string url = string.Format("3/movie/{0}/images?api_key={1}", movieId, MovieHelper.ThemoviedbApiKey);
            MovieImagesResult result = await _restApiService.Get<MovieImagesResult>(url);
            return await ConvertImagesResult(result);
        }

        /// <summary>
        /// Finds the set images.
        /// </summary>
        /// <param name="setName">Name of the set.</param>
        /// <returns></returns>
        public async Task<AvailableMovieImages> FindSetImages(string setName)
        {
            // TODO: refactor
            string searchCollectionUrl = string.Format("3/search/collection?query={0}&api_key={1}", setName, MovieHelper.ThemoviedbApiKey);
            SearchCollectionResult searchResult = await _restApiService.Get<SearchCollectionResult>(searchCollectionUrl);
            MovieSet set = searchResult.Results.FirstOrDefault();
            if (set != null)
            {
                string getCollectionImagesUrl = string.Format("3/collection/{0}/images?api_key={1}", set.Id, MovieHelper.ThemoviedbApiKey);
                MovieImagesResult getImagesResult = await _restApiService.Get<MovieImagesResult>(getCollectionImagesUrl);
                return await ConvertImagesResult(getImagesResult);
            }
            return new AvailableMovieImages();
        }

        /// <summary>
        /// Finds the cast.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        /// <returns></returns>
        public async Task<MovieActorsResult> FindCast(string movieId)
        {
            string url = string.Format("3/movie/{0}/credits?api_key={1}", movieId, MovieHelper.ThemoviedbApiKey);
            MovieActorsResult actorsResult = await _restApiService.Get<MovieActorsResult>(url);
            await FixImagesUrl(actorsResult.Cast);
            return actorsResult;
        }

        /// <summary>
        /// Finds the certification.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        /// <returns></returns>
        public async Task<string> FindCertification(string movieId)
        {
            string url = string.Format("3/movie/{0}/releases?api_key={1}", movieId, MovieHelper.ThemoviedbApiKey);
            MovieCertificationResult result = await _restApiService.Get<MovieCertificationResult>(url);
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
            if (string.IsNullOrEmpty(certification.Certification))
            {
                return null;
            }
            return "Rated " + certification.Certification;
        }

        private async Task<AvailableMovieImages> ConvertImagesResult(MovieImagesResult movieImagesResult)
        {
            AvailableMovieImages availableMovieImages = new AvailableMovieImages();
            availableMovieImages.Fanarts = await ConvertImagesCollection(movieImagesResult.Backdrops);
            availableMovieImages.Posters = await ConvertImagesCollection(movieImagesResult.Posters);
            return availableMovieImages;
        }

        private async Task<IEnumerable<Image>> ConvertImagesCollection(IEnumerable<ThemoviedbImage> images)
        {
            List<Image> fanarts = new List<Image>();
            foreach (ThemoviedbImage image in images)
            {
                fanarts.Add(await ConvertThemoviedbImage(image));
            }
            return fanarts;
        }

        private async Task<Image> ConvertThemoviedbImage(ThemoviedbImage themoviedbImage)
        {
            return new Image
            {
                Url = await GetImageBasePath() + "original" + themoviedbImage.FilePath,
                Size = string.Format("{0}x{1}", themoviedbImage.Width, themoviedbImage.Height),
                Rating = themoviedbImage.VoteAverage
            };
        }

        private async Task FixImagesUrl(IEnumerable<Movie> movies)
        {
            foreach (Movie movie in movies)
            {
                if (!string.IsNullOrEmpty(movie.BackdropPath))
                {
                    movie.BackdropPath = await GetImageBasePath() + "original" + movie.BackdropPath;
                }
                if (!string.IsNullOrEmpty(movie.PosterPath))
                {
                    movie.PosterPath = await GetImageBasePath() + "original" + movie.PosterPath;
                }
            }
        }

        private async Task FixImagesUrl(FullMovie fullMovie)
        {
            if (!string.IsNullOrEmpty(fullMovie.BackdropPath))
            {
                fullMovie.BackdropPath = await GetImageBasePath() + "original" + fullMovie.BackdropPath;
            }
            if (!string.IsNullOrEmpty(fullMovie.PosterPath))
            {
                fullMovie.PosterPath = await GetImageBasePath() + "original" + fullMovie.PosterPath;
            }
        }

        private async Task FixImagesUrl(IEnumerable<Cast> actors)
        {
            foreach (Cast actor in actors)
            {
                actor.ProfilePath = string.IsNullOrEmpty(actor.ProfilePath) ? null : await GetImageBasePath() + "w300" + actor.ProfilePath;
            }
        }

        private async Task<string> GetImageBasePath()
        {
            if (_serverConfiguration == null)
            {
                string url = "3/configuration?api_key=" + MovieHelper.ThemoviedbApiKey;
                _serverConfiguration = await _restApiService.Get<ThemoviedbConfiguration>(url);
            }
            return _serverConfiguration.Images.SecureBaseUrl;
        }
    }
}
