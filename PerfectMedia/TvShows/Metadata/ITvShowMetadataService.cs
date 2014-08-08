﻿using System.Collections.Generic;

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
        AvailableTvShowImages FindImagesFromPath(string path);
        AvailableSeasonImages FindSeasonImages(string seasonPath);
        void DeleteImages(string path);
    }
}
