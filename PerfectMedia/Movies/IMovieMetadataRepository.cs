using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    public interface IMovieMetadataRepository
    {
        MovieMetadata Get(string path);
        void Save(string path, MovieMetadata metadata);
        void Delete(string path);
    }
}
