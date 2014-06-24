using PerfectMedia.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.ViewModels.TvShows
{
    public interface ITvShowViewModelFactory
    {
        SourceManagerViewModel GetSourceManager(SourceType sourceType);
        TvShowViewModel GetTvShow(string path);
        TvShowMetadataViewModel GetTvShowMetadata(string path);
        TvShowImagesViewModel GetTvShowImages(string path);
        SeasonViewModel GetSeason(string path);
        EpisodeViewModel GetEpisode(string path);
    }
}
