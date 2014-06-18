using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.Metadata
{
    public interface ISeasonMetadataService
    {
        void UpdateMetadata(string path, string seriesId);
    }
}
