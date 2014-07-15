using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.Movies
{
    public class ThemoviedbConfiguration
    {
        public ImageConfiguration Images { get; set; }
    }

    public class ImageConfiguration
    {
        public string SecureBaseUrl { get; set; }
    }
}
