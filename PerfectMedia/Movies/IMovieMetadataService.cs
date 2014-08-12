using System.Collections.Generic;

namespace PerfectMedia.Movies
{
    /// <summary>
    /// Finds metadata about movies.
    /// </summary>
    public interface IMovieMetadataService
    {
        /// <summary>
        /// Gets metadata about the movie located at the specified path.
        /// </summary>
        /// <param name="path">The movie file path.</param>
        /// <returns></returns>
        MovieMetadata Get(string path);

        /// <summary>
        /// Gets the movie set.
        /// </summary>
        /// <param name="setName">Name of the set.</param>
        /// <returns></returns>
        MovieSet GetMovieSet(string setName);

        /// <summary>
        /// Saves the metadata to the movie located at the specified path.
        /// </summary>
        /// <param name="path">The movie file path.</param>
        /// <param name="metadata">The metadata.</param>
        void Save(string path, MovieMetadata metadata);

        /// <summary>
        /// Updates the movie located at the specified path.
        /// </summary>
        /// <param name="path">The movie file path.</param>
        /// <exception cref="MovieNotFoundException">No movie found</exception>
        void Update(string path);

        /// <summary>
        /// Deletes the metadata from the movie located at the specified path.
        /// </summary>
        /// <param name="path">The movie file path.</param>
        void Delete(string path);

        /// <summary>
        /// Deletes the images associated with the movie located at the specified path.
        /// </summary>
        /// <param name="path">The movie file path.</param>
        void DeleteImages(string path);

        /// <summary>
        /// Finds the movis summary that match the given name.
        /// </summary>
        /// <param name="name">The movie name.</param>
        /// <returns></returns>
        IEnumerable<Movie> FindMovies(string name);

        /// <summary>
        /// Finds the images about a movie.
        /// </summary>
        /// <param name="movieId">The movie identifier.</param>
        /// <returns></returns>
        AvailableMovieImages FindImages(string movieId);

        /// <summary>
        /// Finds the set images.
        /// </summary>
        /// <param name="setName">Name of the set.</param>
        /// <returns></returns>
        AvailableMovieImages FindSetImages(string setName);
    }
}
