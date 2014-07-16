using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    public class MovieImagesService : IMovieImagesService
    {
        private readonly IFileSystemService _fileSystemService;

        public MovieImagesService(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        public void Update(string path, FullMovie movie)
        {
            string posterPath = MovieHelper.GetMoviePosterPath(path);
            UpdateImageIfNeeded(posterPath, movie.PosterPath);

            string fanartPath = MovieHelper.GetMovieFanartPath(path);
            UpdateImageIfNeeded(fanartPath, movie.BackdropPath);
        }

        public void Delete(string path)
        {
            string posterPath = MovieHelper.GetMoviePosterPath(path);
            _fileSystemService.DeleteFile(posterPath);

            string fanartPath = MovieHelper.GetMovieFanartPath(path);
            _fileSystemService.DeleteFile(fanartPath);
        }

        private void UpdateImageIfNeeded(string imagePath, string imageUrl)
        {
            if (!_fileSystemService.FileExists(imagePath) && !string.IsNullOrEmpty(imageUrl))
            {
                _fileSystemService.DownloadFile(imagePath, imageUrl);
            }
        }
    }
}
