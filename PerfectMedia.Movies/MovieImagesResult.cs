using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    internal class MovieImagesResult
    {
        public List<ThemoviedbImage> Backdrops { get; set; }
        public List<ThemoviedbImage> Posters { get; set; }
    }
}
