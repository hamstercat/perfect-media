using System.Collections.Generic;
using System.Linq;

namespace PerfectMedia.TvShows.Metadata
{
    internal class AvailableTvShowImagesMapper
    {
        private readonly IEnumerable<Banner> _thetvdbBanners;

        private List<Image> _fanarts;
        private List<Image> _posters;
        private List<Image> _banners;
        private Dictionary<int, AvailableSeasonImages> _seasons;

        public AvailableTvShowImagesMapper(IEnumerable<Banner> thetvdbBanners)
        {
            _thetvdbBanners = thetvdbBanners;
        }

        internal AvailableTvShowImages Map()
        {
            InitializeImageCollection();
            foreach(Banner banner in _thetvdbBanners)
            {
                AddImageToTheAppropriateCollection(banner);
            }
            return CreateAvailableTvShowImages();
        }

        private void InitializeImageCollection()
        {
            _fanarts = new List<Image>();
            _posters = new List<Image>();
            _banners = new List<Image>();
            _seasons = new Dictionary<int, AvailableSeasonImages>();
        }

        private void AddImageToTheAppropriateCollection(Banner banner)
        {
            switch (banner.BannerType)
            {
                case "fanart":
                    AddFanartImage(banner);
                    break;
                case "poster":
                    AddPosterImage(banner);
                    break;
                case "series":
                    AddBannerImage(banner);
                    break;
                case "season":
                    AddPosterImage(banner);
                    break;
            }
        }

        private void AddFanartImage(Banner banner)
        {
            Image image = CreateImage(banner);
            image.Description = banner.BannerType2;
            image.WidthRatio = 1920;
            image.HeightRatio = 1080;
            _fanarts.Add(image);
        }

        private void AddPosterImage(Banner banner)
        {
            Image image = CreateImage(banner);
            image.WidthRatio = 680;
            image.HeightRatio = 1000;
            if (banner.Season.HasValue)
            {
                image.Description = TvShowHelper.GetSeasonName(banner.Season.Value);
                AvailableSeasonImages seasonImages = GetAvailableSeasonImages(banner.Season.Value);
                seasonImages.Posters.Add(image);
            }
            else
            {
                image.Description = "TV Show";
                _posters.Add(image);
            }
        }

        private void AddBannerImage(Banner banner)
        {
            Image image = CreateImage(banner);
            image.WidthRatio = 758;
            image.HeightRatio = 140;
            if (banner.Season.HasValue)
            {
                image.Description = TvShowHelper.GetSeasonName(banner.Season.Value);
                AvailableSeasonImages seasonImages = GetAvailableSeasonImages(banner.Season.Value);
                seasonImages.Banners.Add(image);
            }
            else
            {
                image.Description = "TV Show";
                _banners.Add(image);
            }
        }

        private AvailableSeasonImages GetAvailableSeasonImages(int seasonNumber)
        {
            AvailableSeasonImages seasonImages;
            if (!_seasons.TryGetValue(seasonNumber, out seasonImages))
            {
                seasonImages = new AvailableSeasonImages();
                _seasons[seasonNumber] = seasonImages;
            }
            return seasonImages;
        }

        private Image CreateImage(Banner banner)
        {
            return new Image
            {
                Url = TvShowHelper.ExpandImagesUrl(banner.BannerPath),
                Rating = banner.Rating
            };
        }

        private AvailableTvShowImages CreateAvailableTvShowImages()
        {
            AvailableTvShowImages images = new AvailableTvShowImages
            {
                Fanarts = OrderImages(_fanarts),
                Posters = OrderImages(_posters),
                Banners = OrderImages(_banners),
            };
            foreach (var season in _seasons.OrderBy(s => s.Key))
            {
                images.Seasons[season.Key] = new AvailableSeasonImages
                {
                    Banners = OrderImages(season.Value.Banners).ToList(),
                    Posters = OrderImages(season.Value.Posters).ToList()
                };
            }
            return images;
        }

        private IEnumerable<Image> OrderImages(IEnumerable<Image> images)
        {
            return images
                .OrderByDescending(img => img.Description)
                .ThenByDescending(img => img.Rating);
        }
    }
}
