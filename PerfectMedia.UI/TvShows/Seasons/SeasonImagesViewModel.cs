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

        public SeasonImagesViewModel(IFileSystemService fileSystemService, ITvShowMetadataService metadataService, string seasonPath)
        {
            PosterUrl = new ImageViewModel(fileSystemService, new SeasonPosterImageStrategy(metadataService, seasonPath));
            BannerUrl = new ImageViewModel(fileSystemService, new SeasonBannerImageStrategy(metadataService, seasonPath));
        }
    }
}
