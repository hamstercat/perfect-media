using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    public interface ITvShowImagesService
    {
        Task Update(string path, AvailableTvShowImages images);
        Task Delete(string path);
    }
}
