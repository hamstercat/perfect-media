using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    public interface IEpisodeMetadataRepository
    {
        EpisodeMetadata Get(string episodeFile);
        void Save(string episodeFile, EpisodeMetadata metadata);
        void Delete(string episodeFile);
    }
}
