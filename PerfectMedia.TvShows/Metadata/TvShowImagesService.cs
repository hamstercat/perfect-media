using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    public class TvShowImagesService : ITvShowImagesService
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly ITvShowFileService _tvShowFileService;

        public TvShowImagesService(IFileSystemService fileSystemService, ITvShowFileService tvShowFileService)
        {
            _fileSystemService = fileSystemService;
            _tvShowFileService = tvShowFileService;
        }

        public void Update(string path, AvailableTvShowImages images)
        {
            TvShowImages tvShowImages = _tvShowFileService.GetShowImages(path);
            UpdateImageIfNeeded(tvShowImages.Fanart, images.Fanarts);
            UpdateImageIfNeeded(tvShowImages.Poster, images.Posters);
            UpdateImageIfNeeded(tvShowImages.Banner, images.Banners);
            UpdateSeasonImages(tvShowImages.Seasons, images.Seasons);
        }

        public void Delete(string path)
        {
            TvShowImages tvShowImages = _tvShowFileService.GetShowImages(path);
            _fileSystemService.DeleteFile(tvShowImages.Fanart);
            _fileSystemService.DeleteFile(tvShowImages.Poster);
            _fileSystemService.DeleteFile(tvShowImages.Banner);
            DeleteSeasonImages(tvShowImages.Seasons);
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

        private void UpdateSeasonImages(IEnumerable<Season> seasons, IDictionary<int, AvailableSeasonImages> imagesBySeason)
        {
            foreach (Season season in seasons)
            {
                AvailableSeasonImages imageUrls;
                if (imagesBySeason.TryGetValue(season.SeasonNumber, out imageUrls))
                {
                    UpdateImageIfNeeded(season.PosterUrl, imageUrls.Posters);
                    UpdateImageIfNeeded(season.BannerUrl, imageUrls.Banners);
                }
            }
        }

        private void DeleteSeasonImages(IEnumerable<Season> seasons)
        {
            foreach (Season images in seasons)
            {
                _fileSystemService.DeleteFile(images.PosterUrl);
                _fileSystemService.DeleteFile(images.BannerUrl);
            }
        }
    }
}
