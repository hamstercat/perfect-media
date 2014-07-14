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
        void Save(string path, MovieMetadata metadata);
        void Update(string path);
        void Delete(string path);
        IEnumerable<Movie> FindMovies(string name);
        AvailableMovieImages FindImages(string movieId);
    }
}
