using System.Collections.Generic;

namespace PerfectMedia.TvShows.Metadata
{
    public interface ITvShowMetadataUpdater
    {
        IEnumerable<Series> FindSeries(string name);
        FullSerie GetTvShowMetadata(string serieId);
        AvailableTvShowImages FindImages(string serieId);
        IEnumerable<Actor> FindActors(string serieId);
        EpisodeMetadata GetEpisodeMetadata(string serieId, int seasonNumber, int episodeNumber);
    }
}
