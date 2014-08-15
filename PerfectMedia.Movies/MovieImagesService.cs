
using System.Threading.Tasks;
namespace PerfectMedia.Movies
{
    /// <summary>
    /// Handles fanart and poster images for a specific movie.
    /// </summary>
    public class MovieImagesService : IMovieImagesService
    {
        private readonly IFileSystemService _fileSystemService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieImagesService"/> class.
        /// </summary>
        /// <param name="fileSystemService">The file system service.</param>
        public MovieImagesService(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        /// <summary>
        /// Updates the images of the movie located at the specified path.
        /// </summary>
        /// <param name="path">The movie path.</param>
        /// <param name="movie">The movie metadata.</param>
        public async Task Update(string path, FullMovie movie)
        {
            string posterPath = MovieHelper.GetMoviePosterPath(path);
            await UpdateImageIfNeeded(posterPath, movie.PosterPath);

            string fanartPath = MovieHelper.GetMovieFanartPath(path);
            await UpdateImageIfNeeded(fanartPath, movie.BackdropPath);
        }

        /// <summary>
        /// Deletes the images of the movie located at the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        public void Delete(string path)
        {
            string posterPath = MovieHelper.GetMoviePosterPath(path);
            _fileSystemService.DeleteFile(posterPath);

            string fanartPath = MovieHelper.GetMovieFanartPath(path);
            _fileSystemService.DeleteFile(fanartPath);
        }

        private async Task UpdateImageIfNeeded(string imagePath, string imageUrl)
        {
            if (!await _fileSystemService.FileExists(imagePath) && !string.IsNullOrEmpty(imageUrl))
            {
                await _fileSystemService.DownloadImage(imagePath, imageUrl);
            }
        }
    }
}
