
namespace PerfectMedia.TvShows.Metadata
{
    public interface ITvShowImagesService
    {
        void Update(string path, AvailableTvShowImages images);
        void Delete(string path);
    }
}
