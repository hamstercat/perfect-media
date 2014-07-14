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

        public void Update(string path, AvailableMovieImages images)
        {
            // UpdateImageIfNeeded(tvShowImages.Fanart, images.Fanarts);
            throw new NotImplementedException();
        }

        public void Delete(string path)
        {
            // _fileSystemService.DeleteFile(tvShowImages.Fanart);
            throw new NotImplementedException();
        }

        private void UpdateImageIfNeeded(string imagePath, IEnumerable<Image> imageUrls)
        {
            if (!_fileSystemService.FileExists(imagePath))
            {
                Image defaultImage = imageUrls.FirstOrDefault();
                if (defaultImage != null)
                {
                    _fileSystemService.DownloadFile(imagePath, defaultImage.Url);
                }
            }
        }
    }
}
