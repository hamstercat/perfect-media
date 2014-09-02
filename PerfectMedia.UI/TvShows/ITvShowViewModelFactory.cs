using System;
using PerfectMedia.Sources;
using PerfectMedia.UI.Actors;
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
        ITvShowImagesViewModel GetTvShowImages(ITvShowViewModel tvShow, string path);
        ISeasonViewModel GetSeason(ITvShowViewModel tvShow, string path);
        IEpisodeViewModel GetEpisode(ITvShowViewModel tvShow, string path);
        IImageViewModel GetImage(bool horizontalAlignement);
        IImageViewModel GetImage(bool horizontalAlignement, IImageStrategy imageStrategy);
        ITvShowSelectionViewModel GetTvShowSelection(ITvShowViewModel tvShow, string path);
        ICachedPropertyViewModel<string> GetStringCachedProperty(string key, bool isRequired);
        ICachedPropertyViewModel<int?> GetIntCachedProperty(string key, bool isRequired);
        IActorManagerViewModel GetActorManager();
    }
}
