using PerfectMedia.UI.Images;

namespace PerfectMedia.UI.TvShows.Seasons
{
    public interface ISeasonImagesViewModel
    {
        IImageViewModel BannerUrl { get; }
        IImageViewModel PosterUrl { get; }
        int SeasonNumber { get; set; }
        void Refresh();
    }
}