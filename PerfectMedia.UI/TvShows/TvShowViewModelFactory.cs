﻿using PerfectMedia.Sources;
using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.Sources;
using PerfectMedia.UI.TvShows.Episodes;
using PerfectMedia.UI.TvShows.Seasons;
using PerfectMedia.UI.TvShows.Shows;

namespace PerfectMedia.UI.TvShows
{
    public class TvShowViewModelFactory : ITvShowViewModelFactory
    {
        private readonly ISourceService _sourceService;
        private readonly IFileSystemService _fileSystemService;
        private readonly ITvShowFileService _tvShowFileService;
        private readonly ITvShowMetadataService _tvShowMetadataService;
        private readonly IEpisodeMetadataService _episodeMetadataService;
        private readonly IProgressManagerViewModel _progressManagerViewModel;

        public TvShowViewModelFactory(ISourceService sourceService,
            IFileSystemService fileSystemService,
            ITvShowFileService tvShowFileService,
            ITvShowMetadataService tvShowMetadataService,
            IEpisodeMetadataService episodeMetadataService,
            IProgressManagerViewModel progressManagerViewModel)
        {
            _sourceService = sourceService;
            _fileSystemService = fileSystemService;
            _tvShowFileService = tvShowFileService;
            _tvShowMetadataService = tvShowMetadataService;
            _episodeMetadataService = episodeMetadataService;
            _progressManagerViewModel = progressManagerViewModel;
        }

        public ISourceManagerViewModel GetSourceManager(SourceType sourceType)
        {
            return new SourceManagerViewModel(_sourceService, _fileSystemService, sourceType);
        }

        public ITvShowViewModel GetTvShow(string path)
        {
            return new TvShowViewModel(this, _tvShowFileService, path);
        }

        public ITvShowMetadataViewModel GetTvShowMetadata(string path)
        {
            return new TvShowMetadataViewModel(this, _tvShowMetadataService, _progressManagerViewModel, path);
        }

        public ITvShowImagesViewModel GetTvShowImages(string path)
        {
            return new TvShowImagesViewModel(_tvShowFileService, _tvShowMetadataService, path);
        }

        public ISeasonViewModel GetSeason(ITvShowMetadataViewModel tvShowMetadata, string path)
        {
            return new SeasonViewModel(this, _tvShowFileService, tvShowMetadata, path);
        }

        public IEpisodeViewModel GetEpisode(ITvShowMetadataViewModel tvShowMetadata, string path)
        {
            return new EpisodeViewModel(_episodeMetadataService, tvShowMetadata, _progressManagerViewModel, path);
        }
    }
}
