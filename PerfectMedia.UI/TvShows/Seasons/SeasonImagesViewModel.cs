using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Images;
using PropertyChanged;

namespace PerfectMedia.UI.TvShows.Seasons
{
    [ImplementPropertyChanged]
    public class SeasonImagesViewModel
    {
        public IImageViewModel PosterUrl { get; private set; }
        public IImageViewModel BannerUrl { get; private set; }
        public int SeasonNumber { get; set; }

        public SeasonImagesViewModel(IFileSystemService fileSystemService,
            ITvShowMetadataService metadataService,
            IBusyProvider busyProvider,
            string tvShowPath,
            string seasonPath)
        {
            PosterUrl = new ImageViewModel(fileSystemService, busyProvider, true, new SeasonPosterImageStrategy(metadataService, tvShowPath, seasonPath));
            BannerUrl = new ImageViewModel(fileSystemService, busyProvider, false, new SeasonBannerImageStrategy(metadataService, tvShowPath, seasonPath));
        }
    }
}
