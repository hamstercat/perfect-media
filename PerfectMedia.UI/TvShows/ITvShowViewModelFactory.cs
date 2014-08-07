using PerfectMedia.Sources;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Sources;
using PerfectMedia.UI.TvShows.Episodes;
using PerfectMedia.UI.TvShows.Seasons;
using PerfectMedia.UI.TvShows.Shows;
using PerfectMedia.UI.TvShows.ShowSelection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.TvShows
{
    public interface ITvShowViewModelFactory
    {
        ISourceManagerViewModel GetSourceManager(SourceType sourceType);
        ITvShowViewModel GetTvShow(string path);
        ITvShowMetadataViewModel GetTvShowMetadata(string path);
        ITvShowImagesViewModel GetTvShowImages(ITvShowMetadataViewModel metadataViewModel, string path);
        ISeasonViewModel GetSeason(ITvShowMetadataViewModel tvShowMetadata, string path);
        IEpisodeViewModel GetEpisode(ITvShowMetadataViewModel tvShowMetadata, string path);
        IImageViewModel GetImage(bool horizontalAlignement);
        IImageViewModel GetImage(bool horizontalAlignement, IImageStrategy imageStrategy);
        ITvShowSelectionViewModel GetTvShowSelection(ITvShowMetadataViewModel tvShowMetadata, string path);
        ICachedPropertyViewModel<T> GetCachedProperty<T>(string key, Func<T, string> converter, Func<string, T> otherConverter);
    }
}
