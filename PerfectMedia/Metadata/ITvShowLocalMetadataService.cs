using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Metadata
{
    public interface ITvShowLocalMetadataService
    {
        TvShowMetadata GetLocalMetadata(string path);
        void SaveLocalMetadata(string path, TvShowMetadata metadata);

        TvShowImages GetLocalImages(string path);
        void SaveFanart(string path, string imageUrl);
        void SavePoster(string path, string imageUrl);
        void SaveBanner(string path, string imageUrl);

        IEnumerable<SeasonImages> GetLocalSeasonImages(string _path);
    }
}
