using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Images;
using PropertyChanged;

namespace PerfectMedia.UI.TvShows.Seasons
{
    [ImplementPropertyChanged]
    public class SeasonImagesViewModel : ISeasonImagesViewModel
    {
        public IImageViewModel PosterUrl { get; private set; }
        public IImageViewModel BannerUrl { get; private set; }
        public int SeasonNumber { get; set; }

        public SeasonImagesViewModel(ITvShowViewModelFactory viewModelFactory,
            ITvShowMetadataService metadataService,
            string tvShowPath,
            string seasonPath)
        {
            PosterUrl = viewModelFactory.GetImage(true, new SeasonPosterImageStrategy(metadataService, tvShowPath, seasonPath));
            BannerUrl = viewModelFactory.GetImage(false, new SeasonBannerImageStrategy(metadataService, tvShowPath, seasonPath));
        }

        public void Refresh()
        {
            PosterUrl.RefreshImage();
            BannerUrl.RefreshImage();
        }
    }
}
