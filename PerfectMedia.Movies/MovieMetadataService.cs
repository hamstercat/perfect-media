﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using PerfectMedia.FileInformation;

namespace PerfectMedia.Movies
{
    public class MovieMetadataService : IMovieMetadataService
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IMovieMetadataRepository _metadataRepository;
        private readonly IMovieMetadataUpdater _metadataUpdater;
        private readonly IMovieSynopsisService _synopsisService;
        private readonly IMovieImagesService _imagesService;
        private readonly IFileInformationService _fileInformationService;

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

        public MovieMetadata Get(string path)
        {
            MovieMetadata metadata = _metadataRepository.Get(path);
            SetActorsThumbPath(path, metadata);
            SetImagesPath(path, metadata);
            return metadata;
        }

        public MovieSet GetMovieSet(string setName)
        {
            MovieSet set = new MovieSet();
            set.Name = setName;
            set.BackdropPath = MovieHelper.GetMovieSetFanartPath(setName);
            set.PosterPath = MovieHelper.GetMovieSetPosterPath(setName);
            return set;
        }

        public void Save(string path, MovieMetadata metadata)
        {
            _metadataRepository.Save(path, metadata);
        }

        public void Update(string path)
        {
            FullMovie movie = FindFullMovie(path);
            if (string.IsNullOrEmpty(movie.ImdbId))
            {
                throw new MovieNotFoundException("No movie found for " + path);
            }
            UpdateFromMovie(path, movie);
        }

        public void Delete(string path)
        {
            _metadataRepository.Delete(path);
        }

        public void DeleteImages(string path)
        {
            _imagesService.Delete(path);
        }

        public IEnumerable<Movie> FindMovies(string name)
        {
            return _metadataUpdater.FindMovies(name);
        }

        public AvailableMovieImages FindImages(string movieId)
        {
            return _metadataUpdater.FindImages(movieId);
        }

        public AvailableMovieImages FindSetImages(string setName)
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

        private FullMovie FindFullMovie(string path)
        {
            string movieId = GetMovieId(path);
            FullMovie fullMovie = _metadataUpdater.GetMovieMetadata(movieId);
            if (fullMovie == null)
            {
                throw new MovieNotFoundException(path);
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
                throw new MovieNotFoundException(message);
            }
            return movies
                .OrderByDescending(m => m.VoteAverage)
                .First().Id;
        }

        private void UpdateFromMovie(string path, FullMovie movie)
        {
            SetFullMovieSynopsis(movie);
            SetRating(movie);
            UpdateInformationMetadata(path, movie);
            _imagesService.Update(path, movie);
        }

        private void SetFullMovieSynopsis(FullMovie movie)
        {
            MovieSynopsis synopsis = _synopsisService.GetSynopsis(movie.ImdbId);
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

        private void SetRating(FullMovie movie)
        {
            movie.Certification = _metadataUpdater.FindCertification(movie.ImdbId);
        }

        private void UpdateInformationMetadata(string path, FullMovie movie)
        {
            MovieMetadata metadata = MapFullMovieToMetadata(movie);
            UpdateActorsMetadata(path, metadata);
            metadata.FileInformation = _fileInformationService.GetVideoFileInformation(path);
            Save(path, metadata);
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

        private void UpdateActorsMetadata(string path, MovieMetadata metadata)
        {
            string movieFolder = _fileSystemService.GetParentFolder(path, 1);
            MovieActorsResult actorsResult = _metadataUpdater.FindCast(metadata.Id);
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
