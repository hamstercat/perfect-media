using System;
using PerfectMedia.Sources;
using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Sources;
using PerfectMedia.UI.TvShows.Episodes;
using PerfectMedia.UI.TvShows.Seasons;
using PerfectMedia.UI.TvShows.Shows;
using PerfectMedia.UI.TvShows.ShowSelection;

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
        ICachedPropertyViewModel<string> GetStringCachedProperty(string key);
        ICachedPropertyViewModel<int?> GetIntCachedProperty(string key);
    }
}
