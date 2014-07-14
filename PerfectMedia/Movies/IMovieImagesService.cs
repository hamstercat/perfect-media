using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    public interface IMovieImagesService
    {
        void Update(string path, AvailableMovieImages images);
        void Delete(string path);
    }
}
