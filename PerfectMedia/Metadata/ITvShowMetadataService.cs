using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Metadata
{
    public interface ITvShowMetadataService
    {
        TvShowMetadata GetLocalMetadata(string path);
    }
}
