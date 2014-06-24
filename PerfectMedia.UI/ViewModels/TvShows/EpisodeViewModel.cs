using PerfectMedia.TvShows.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.ViewModels.TvShows
{
    public class EpisodeViewModel
    {
        private readonly IEpisodeMetadataService _metadataService;

        public string Path { get; private set; }

        public EpisodeViewModel(IEpisodeMetadataService metadataService, string path)
        {
            _metadataService = metadataService;
            Path = path;
        }
    }
}
