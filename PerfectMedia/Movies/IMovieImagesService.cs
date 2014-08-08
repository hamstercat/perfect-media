
namespace PerfectMedia.Movies
{
    public interface IMovieImagesService
    {
        void Update(string path, FullMovie movie);
        void Delete(string path);
    }
}
