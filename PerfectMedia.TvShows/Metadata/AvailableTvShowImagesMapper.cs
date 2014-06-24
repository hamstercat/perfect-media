using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                default:
                    break;
            }
        }

        private void AddFanartImage(Banner banner)
        {
            Image image = CreateImage(banner);
            image.Size = banner.BannerType2;
            _fanarts.Add(image);
        }

        private void AddPosterImage(Banner banner)
        {
            Image image = CreateImage(banner);
            image.Size = banner.BannerType2;
            if (banner.Season.HasValue)
            {
                AvailableSeasonImages seasonImages = GetAvailableSeasonImages(banner.Season.Value);
                seasonImages.Posters.Add(image);
            }
            else
            {
                _posters.Add(image);
            }
        }

        private void AddBannerImage(Banner banner)
        {
            Image image = CreateImage(banner);
            if (banner.Season.HasValue)
            {
                AvailableSeasonImages seasonImages = GetAvailableSeasonImages(banner.Season.Value);
                seasonImages.Banners.Add(image);
            }
            else
            {
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
            return new AvailableTvShowImages
            {
                Fanarts = _fanarts.OrderByDescending(img => img.Rating),
                Posters = _posters.OrderByDescending(img => img.Rating),
                Banners = _banners.OrderByDescending(img => img.Rating),
                Seasons = _seasons
            };
        }
    }
}
