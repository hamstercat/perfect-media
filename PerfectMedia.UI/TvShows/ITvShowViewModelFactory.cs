using PerfectMedia.Sources;
using PerfectMedia.UI.Sources;
using PerfectMedia.UI.TvShows.Episodes;
using PerfectMedia.UI.TvShows.Seasons;
using PerfectMedia.UI.TvShows.Shows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.TvShows
{
    public interface ITvShowViewModelFactory
    {
        SourceManagerViewModel GetSourceManager(SourceType sourceType);
        TvShowViewModel GetTvShow(string path);
        TvShowMetadataViewModel GetTvShowMetadata(string path);
        TvShowImagesViewModel GetTvShowImages(string path);
        SeasonViewModel GetSeason(string tvShowPath, string path);
        EpisodeViewModel GetEpisode(string path);
    }
}
