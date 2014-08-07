using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Images;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.TvShows.Seasons
{
    [ImplementPropertyChanged]
    public class SeasonImagesViewModel
    {
        public IImageViewModel PosterUrl { get; private set; }
        public IImageViewModel BannerUrl { get; private set; }
        public int SeasonNumber { get; set; }

        public SeasonImagesViewModel(IFileSystemService fileSystemService, ITvShowMetadataService metadataService, string tvShowPath, string seasonPath)
        {
            PosterUrl = new ImageViewModel(fileSystemService, true, new SeasonPosterImageStrategy(metadataService, tvShowPath, seasonPath));
            BannerUrl = new ImageViewModel(fileSystemService, false, new SeasonBannerImageStrategy(metadataService, tvShowPath, seasonPath));
        }
    }
}
