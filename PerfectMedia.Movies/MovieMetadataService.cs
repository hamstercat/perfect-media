using System.Collections.Generic;
using System.IO;
using System.Linq;
using PerfectMedia.FileInformation;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    /// <summary>
    /// Finds metadata about movies.
    /// </summary>
    public class MovieMetadataService : IMovieMetadataService
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IMovieMetadataRepository _metadataRepository;
        private readonly IMovieMetadataUpdater _metadataUpdater;
        private readonly IMovieSynopsisService _synopsisService;
        private readonly IMovieImagesService _imagesService;
        private readonly IFileInformationService _fileInformationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieMetadataService"/> class.
        /// </summary>
        /// <param name="fileSystemService">The file system service.</param>
        /// <param name="metadataRepository">The metadata repository.</param>
        /// <param name="metadataUpdater">The metadata updater.</param>
        /// <param name="synopsisService">The synopsis service.</param>
        /// <param name="imagesService">The images service.</param>
        /// <param name="fileInformationService">The file information service.</param>
        public MovieMetadataService(IFileSystemService fileSystemService,
            IMovieMetadataRepository metadataRepository,
            IMovieMetadataUpdater metadataUpdater,
            IMovieSynopsisService synopsisService,
            IMovieImagesService imagesService,
            IFileInformationService fileInformationService)
        {
            _fileSystemService = fileSystemService;
            _metadataRepository = metadataRepository;
            _metadataUpdater = metadataUpdater;
            _synopsisService = synopsisService;
            _imagesService = imagesService;
            _fileInformationService = fileInformationService;
        }

        /// <summary>
        /// Gets metadata about the movie located at the specified path.
        /// </summary>
        /// <param name="path">The movie file path.</param>
        /// <returns></returns>
        public async Task<MovieMetadata> Get(string path)
        {
            MovieMetadata metadata = await _metadataRepository.Get(path);
            SetActorsThumbPath(path, metadata);
            SetImagesPath(path, metadata);
            return metadata;
        }

        /// <summary>
        /// Gets the movie set.
        /// </summary>
        /// <param name="setName">Name of the set.</param>
        /// <returns></returns>
        public MovieSet GetMovieSet(string setName)
        {
            MovieSet set = new MovieSet();
            set.Name = setName;
            set.BackdropPath = MovieHelper.GetMovieSetFanartPath(setName);
            set.PosterPath = MovieHelper.GetMovieSetPosterPath(setName);
            return set;
        }

        /// <summary>
        /// Saves the metadata to the movie located at the specified path.
        /// </summary>
        /// <param name="path">The movie file path.</param>
        /// <param name="metadata">The metadata.</param>
        public async Task Save(string path, MovieMetadata metadata)
        {
            await _metadataRepository.Save(path, metadata);
        }

        /// <summary>
        /// Updates the movie located at the specified path.
        /// </summary>
        /// <param name="path">The movie file path.</param>
        /// <exception cref="MovieNotFoundException">No movie found</exception>
        public async Task Update(string path)
        {
            FullMovie movie = await FindFullMovie(path);
            if (string.IsNullOrEmpty(movie.ImdbId))
            {
                throw new MovieNotFoundException("No movie found for " + path);
            }
            await UpdateFromMovie(path, movie);
        }

        /// <summary>
        /// Deletes the metadata from the movie located at the specified path.
        /// </summary>
        /// <param name="path">The movie file path.</param>
        public async Task Delete(string path)
        {
            await _metadataRepository.Delete(path);
        }

        /// <summary>
        /// Deletes the images associated with the movie located at the specified path.
        /// </summary>
        /// <param name="path">The movie file path.</param>
        public async Task DeleteImages(string path)
        {
            await _imagesService.Delete(path);
        }

        /// <summary>
        /// Finds the movis summary that match the given name.
        /// </summary>
        /// <param name="name">The movie name.</param>
        /// <returns></returns>
        public Task<IEnumerable<Movie>> FindMovies(string name)
        {
            return _metadataUpdater.FindMovies(name);
        }

        /// <summary>
        /// Finds the images about a movie.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        /// <returns></returns>
        public Task<AvailableMovieImages> FindImages(string movieId)
        {
            return _metadataUpdater.FindImages(movieId);
        }

        /// <summary>
        /// Finds the set images.
        /// </summary>
        /// <param name="setName">Name of the set.</param>
        /// <returns></returns>
        public Task<AvailableMovieImages> FindSetImages(string setName)
        {
            return _metadataUpdater.FindSetImages(setName);
        }

        private void SetActorsThumbPath(string path, MovieMetadata metadata)
        {
            string movieFolder = _fileSystemService.GetParentFolder(path, 1);
            foreach (ActorMetadata actor in metadata.Actors)
            {
                actor.ThumbPath = ActorMetadata.GetActorThumbPath(movieFolder, actor.Name);
            }
        }

        private void SetImagesPath(string path, MovieMetadata metadata)
        {
            metadata.ImageFanartPath = MovieHelper.GetMovieFanartPath(path);
            metadata.ImagePosterPath = MovieHelper.GetMoviePosterPath(path);
        }

        private async Task<FullMovie> FindFullMovie(string path)
        {
            string movieId = await GetMovieId(path);
            FullMovie fullMovie = await _metadataUpdater.GetMovieMetadata(movieId);
            if (fullMovie == null)
            {
                throw new MovieNotFoundException(path);
            }
            return fullMovie;
        }

        private async Task<string> GetMovieId(string path)
        {
            MovieMetadata metadata = await Get(path);
            if (string.IsNullOrEmpty(metadata.Id))
            {
                return await FindIdFromPath(path);
            }
            return metadata.Id;
        }

        private async Task<string> FindIdFromPath(string path)
        {
            string folderName = Path.GetFileNameWithoutExtension(path);
            IEnumerable<Movie> movies = await FindMovies(folderName);
            if (!movies.Any())
            {
                string message = string.Format("Couldn't find any movie corresponding to \"{0}\"", folderName);
                throw new MovieNotFoundException(message);
            }
            return movies
                .OrderByDescending(m => m.VoteAverage)
                .First().Id;
        }

        private async Task UpdateFromMovie(string path, FullMovie movie)
        {
            await SetFullMovieSynopsis(movie);
            await SetRating(movie);
            await UpdateInformationMetadata(path, movie);
            await _imagesService.Update(path, movie);
        }

        private async Task SetFullMovieSynopsis(FullMovie movie)
        {
            MovieSynopsis synopsis = await _synopsisService.GetSynopsis(movie.ImdbId);
            if (string.IsNullOrEmpty(movie.Tagline))
            {
                movie.Tagline = synopsis.Tagline;
            }
            if (!string.IsNullOrEmpty(synopsis.Outline))
            {
                movie.Overview = synopsis.Outline;
            }
            if (!string.IsNullOrEmpty(synopsis.Plot))
            {
                movie.Plot = synopsis.Plot;
            }
        }

        private async Task SetRating(FullMovie movie)
        {
            movie.Certification = await _metadataUpdater.FindCertification(movie.ImdbId);
        }

        private async Task UpdateInformationMetadata(string path, FullMovie movie)
        {
            MovieMetadata metadata = MapFullMovieToMetadata(movie);
            await UpdateActorsMetadata(path, metadata);
            metadata.FileInformation = _fileInformationService.GetVideoFileInformation(path);
            await Save(path, metadata);
        }

        private MovieMetadata MapFullMovieToMetadata(FullMovie movie)
        {
            MovieMetadata metadata = new MovieMetadata();
            metadata.Certification = movie.Certification;
            metadata.Genres = movie.Genres.Select(genre => genre.Name).ToList();
            metadata.Id = movie.ImdbId;
            metadata.OriginalTitle = movie.OriginalTitle;
            metadata.Outline = movie.Overview;
            metadata.Plot = movie.Plot;
            metadata.Rating = movie.VoteAverage;
            metadata.RuntimeInMinutes = movie.Runtime;
            metadata.Tagline = movie.Tagline;
            metadata.Title = movie.Title;

            if (movie.BelongsToCollection != null)
            {
                metadata.SetName = movie.BelongsToCollection.Name;
            }

            if (movie.ReleaseDate.HasValue)
            {
                metadata.Premiered = movie.ReleaseDate;
                metadata.Year = movie.ReleaseDate.Value.Year;
            }

            Reference productionCompany = movie.ProductionCompanies.FirstOrDefault();
            if (productionCompany != null)
            {
                metadata.Studio = productionCompany.Name;
            }

            Reference productionCountry = movie.ProductionCountries.FirstOrDefault();
            if (productionCountry != null)
            {
                metadata.Country = productionCountry.Name;
            }

            return metadata;
        }

        private async Task UpdateActorsMetadata(string path, MovieMetadata metadata)
        {
            string movieFolder = _fileSystemService.GetParentFolder(path, 1);
            MovieActorsResult actorsResult = await _metadataUpdater.FindCast(metadata.Id);
            UpdateActors(metadata, movieFolder, actorsResult.Cast);
            UpdateCrews(metadata, actorsResult.Crew);
        }

        private static void UpdateActors(MovieMetadata metadata, string movieFolder, IEnumerable<Cast> actors)
        {
            foreach (Cast themoviedbActor in actors)
            {
                ActorMetadata actor = new ActorMetadata
                {
                    Name = themoviedbActor.Name,
                    Role = themoviedbActor.Character,
                    Thumb = themoviedbActor.ProfilePath,
                    ThumbPath = ActorMetadata.GetActorThumbPath(movieFolder, themoviedbActor.Name)
                };
                metadata.Actors.Add(actor);
            }
        }

        private void UpdateCrews(MovieMetadata metadata, IEnumerable<Crew> crews)
        {
            foreach (Crew crew in crews)
            {
                if (crew.Department == "Directing" && crew.Job == "Director")
                {
                    metadata.Directors.Add(crew.Name);
                }
                if (crew.Department == "Writing" && crew.Job != "Novel")
                {
                    metadata.Credits.Add(crew.Name);
                }
            }
        }
    }
}
