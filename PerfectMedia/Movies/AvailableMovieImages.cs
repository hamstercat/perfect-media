using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.Movies
{
    public class AvailableMovieImages
    {
        public IEnumerable<Image> Fanarts { get; set; }
        public IEnumerable<Image> Posters { get; set; }

        public AvailableMovieImages()
        {
            Fanarts = new List<Image>();
            Posters = new List<Image>();
        }
    }
}
