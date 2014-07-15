using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    public class MovieMetadataService : IMovieMetadataService
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IMovieMetadataRepository _metadataRepository;
        private readonly IMovieMetadataUpdater _metadataUpdater;
        private readonly IMovieImagesService _imagesService;

        public MovieMetadataService(IFileSystemService fileSystemService,
            IMovieMetadataRepository metadataRepository,
            IMovieMetadataUpdater metadataUpdater,
            IMovieImagesService imagesService)
        {
            _fileSystemService = fileSystemService;
            _metadataRepository = metadataRepository;
            _metadataUpdater = metadataUpdater;
            _imagesService = imagesService;
        }

        public MovieMetadata Get(string path)
        {
            MovieMetadata metadata = _metadataRepository.Get(path);
            foreach (ActorMetadata actor in metadata.Actors)
            {
                actor.ThumbPath = ActorMetadata.GetActorThumbPath(path, actor.Name);
            }
            return metadata;
        }

        public void Save(string path, MovieMetadata metadata)
        {
            _metadataRepository.Save(path, metadata);
        }

        public void Update(string path)
        {
            FullMovie movie = FindFullMovie(path);
            UpdateInformationMetadata(path, movie);
            UpdateImages(path, movie.ImdbId);
        }

        public void Delete(string path)
        {
            _metadataRepository.Delete(path);
        }

        public IEnumerable<Movie> FindMovies(string name)
        {
            return _metadataUpdater.FindMovies(name);
        }

        public AvailableMovieImages FindImages(string movieId)
        {
            return _metadataUpdater.FindImages(movieId);
        }

        private FullMovie FindFullMovie(string path)
        {
            string movieId = GetMovieId(path);
            FullMovie fullMovie = _metadataUpdater.GetMovieMetadata(movieId);
            if (fullMovie == null)
            {
                throw new ItemNotFoundException(path);
            }
            return fullMovie;
        }

        private string GetMovieId(string path)
        {
            MovieMetadata metadata = Get(path);
            if (string.IsNullOrEmpty(metadata.Id))
            {
                return FindIdFromPath(path);
            }
            return metadata.Id;
        }

        private string FindIdFromPath(string path)
        {
            string folderName = Path.GetFileNameWithoutExtension(path);
            IEnumerable<Movie> movies = FindMovies(folderName);
            if (!movies.Any())
            {
                string message = string.Format("Couldn't find any movie corresponding to \"{0}\"", folderName);
                throw new ItemNotFoundException(message);
            }
            return movies.First().Id;
        }

        private void UpdateInformationMetadata(string path, FullMovie movie)
        {
            MovieMetadata metadata = MapFullMovieToMetadata(movie, path);
            UpdateActorsMetadata(path, metadata);
            Save(path, metadata);
        }

        private MovieMetadata MapFullMovieToMetadata(FullMovie movie, string path)
        {
            MovieMetadata metadata = new MovieMetadata();
            metadata.Genres = movie.Genres.Select(genre => genre.Name).ToList();
            metadata.Id = movie.ImdbId;
            metadata.OriginalTitle = movie.OriginalTitle;
            metadata.Outline = movie.Overview;
            //metadata.Plot = movie.Pl
            metadata.Rating = movie.VoteAverage;
            metadata.RuntimeInMinutes = movie.Runtime;
            metadata.SetName = movie.BelongsToCollection;
            metadata.Tagline = movie.Tagline;
            metadata.Title = movie.Title;

            if (movie.ReleaseDate.HasValue)
            {
                metadata.Premiered = movie.ReleaseDate;
                metadata.Year = movie.ReleaseDate.Value.Year;
            }

            StudioCompany productionCompany = movie.ProductionCompanies.FirstOrDefault();
            if (productionCompany != null)
            {
                metadata.Studio = productionCompany.Name;
            }

            return metadata;
        }

        private void UpdateActorsMetadata(string path, MovieMetadata metadata)
        {
            string movieFolder = _fileSystemService.GetParentDirectory(path, 1);
            IEnumerable<Actor> actors = _metadataUpdater.FindActors(metadata.Id);
            foreach (Actor themoviedbActor in actors)
            {
                ActorMetadata actor = new ActorMetadata
                {
                    Name = themoviedbActor.Name,
                    Role = themoviedbActor.Role,
                    Thumb = themoviedbActor.Image,
                    ThumbPath = ActorMetadata.GetActorThumbPath(movieFolder, themoviedbActor.Name)
                };
                metadata.Actors.Add(actor);
            }
        }

        private void UpdateImages(string path, string movieId)
        {
            AvailableMovieImages images = _metadataUpdater.FindImages(movieId);
            _imagesService.Update(path, images);
        }
    }
}
