using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    public interface ITvShowMetadataService
    {
        Task<TvShowMetadata> Get(string path);
        Task Save(string path, TvShowMetadata metadata);
        Task Update(string path);
        Task Delete(string path);
        Task<IEnumerable<Series>> FindSeries(string name);
        Task<AvailableTvShowImages> FindImages(string seriesId);
        Task<AvailableTvShowImages> FindImagesFromPath(string path);
        Task<AvailableSeasonImages> FindSeasonImages(string seasonPath);
        Task DeleteImages(string path);
    }
}
