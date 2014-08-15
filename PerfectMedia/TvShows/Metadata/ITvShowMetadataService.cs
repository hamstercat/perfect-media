﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    public interface ITvShowMetadataService
    {
        Task<TvShowMetadata> Get(string path);
        void Save(string path, TvShowMetadata metadata);
        Task Update(string path);
        void Delete(string path);
        IEnumerable<Series> FindSeries(string name);
        AvailableTvShowImages FindImages(string seriesId);
        AvailableTvShowImages FindImagesFromPath(string path);
        Task<AvailableSeasonImages> FindSeasonImages(string seasonPath);
        void DeleteImages(string path);
    }
}
