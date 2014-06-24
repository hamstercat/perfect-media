using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    public interface ITvShowImagesService
    {
        void Update(string path, AvailableTvShowImages images);
        void Delete(string path);
    }
}
