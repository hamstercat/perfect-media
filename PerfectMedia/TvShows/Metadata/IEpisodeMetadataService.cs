using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    public interface IEpisodeMetadataService
    {
        EpisodeMetadata Get(string path);
        void Save(string path, EpisodeMetadata metadata);
        void Update(string path);
    }
}
