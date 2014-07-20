using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    public interface IMovieMetadataService
    {
        MovieMetadata Get(string path);
        MovieSet GetMovieSet(string setName);
        void Save(string path, MovieMetadata metadata);
        void Update(string path);
        void Delete(string path);
        void DeleteImages(string path);
        IEnumerable<Movie> FindMovies(string name);
        AvailableMovieImages FindImages(string movieId);
        AvailableMovieImages FindSetImages(string setName);
    }
}
