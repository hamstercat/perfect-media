using PerfectMedia.Sources;
using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.ViewModels.TvShows
{
    public class TvShowViewModelFactory : ITvShowViewModelFactory
    {
        private readonly ISourceService _sourceService;
        private readonly ITvShowFileService _tvShowFileService;
        private readonly ITvShowMetadataService _tvShowMetadataService;
        private readonly IEpisodeMetadataService _episodeMetadataService;

        public TvShowViewModelFactory(ISourceService sourceService,
            ITvShowFileService tvShowFileService,
            ITvShowMetadataService tvShowMetadataService,
            IEpisodeMetadataService episodeMetadataService)
        {
            _sourceService = sourceService;
            _tvShowFileService = tvShowFileService;
            _tvShowMetadataService = tvShowMetadataService;
            _episodeMetadataService = episodeMetadataService;
        }

        public SourceManagerViewModel GetSourceManager(SourceType sourceType)
        {
            return new SourceManagerViewModel(_sourceService, sourceType);
        }

        public TvShowViewModel GetTvShow(string path)
        {
            return new TvShowViewModel(this, _tvShowFileService, path);
        }

        public TvShowMetadataViewModel GetTvShowMetadata(string path)
        {
            return new TvShowMetadataViewModel(this, _tvShowMetadataService, path);
        }

        public TvShowImagesViewModel GetTvShowImages(string path)
        {
            return new TvShowImagesViewModel(_tvShowFileService, _tvShowMetadataService, path);
        }

        public SeasonViewModel GetSeason(string path)
        {
            return new SeasonViewModel(this, _tvShowFileService, path);
        }

        public EpisodeViewModel GetEpisode(string path)
        {
            return new EpisodeViewModel(_episodeMetadataService, path);
        }
    }
}
