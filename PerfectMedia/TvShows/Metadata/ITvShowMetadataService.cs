using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    public interface ITvShowMetadataService
    {
        TvShowMetadata Get(string path);
        void Save(string path, TvShowMetadata metadata);
        void Update(string path);
        void Delete(string path);
        IEnumerable<Series> FindSeries(string name);
        AvailableTvShowImages FindImages(string seriesId);
    }
}
