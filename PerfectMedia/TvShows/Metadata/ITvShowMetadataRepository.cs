using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    public interface ITvShowMetadataRepository
    {
        TvShowMetadata Get(string path);
        void Save(string path, TvShowMetadata metadata);
        void Delete(string path);
    }
}
