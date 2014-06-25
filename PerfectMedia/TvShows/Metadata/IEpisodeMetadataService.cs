﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    public interface IEpisodeMetadataService
    {
        EpisodeMetadata Get(string episodeFile);
        void Save(string episodeFile, EpisodeMetadata metadata);
        void Update(string episodeFile);
        void Delete(string episodeFile);
    }
}
