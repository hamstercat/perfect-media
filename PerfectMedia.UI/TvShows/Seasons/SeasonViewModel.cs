using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Episodes;
using PerfectMedia.UI.TvShows.Shows;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.TvShows.Seasons
{
    [ImplementPropertyChanged]
    public class SeasonViewModel : ISeasonViewModel, ITreeViewItemViewModel
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly ITvShowFileService _tvShowFileService;
        private readonly ITvShowMetadataViewModel _tvShowMetadata;

        private bool _imagesLoaded;
        private bool _episodeLoaded;

        private bool _isExpanded;
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                _isExpanded = value;
                if (_isExpanded)
                {
                    LoadEpisodes();
                }
            }
        }

        public string DisplayName
        {
            get
            {
                return System.IO.Path.GetFileName(Path);
            }
        }

        private IImageViewModel _posterUrl;
        public IImageViewModel PosterUrl
        {
            get
            {
                LoadImages();
                return _posterUrl;
            }
        }

        private IImageViewModel _bannerUrl;
        public IImageViewModel BannerUrl
        {
            get
            {
                LoadImages();
                return _bannerUrl;
            }
        }

        public string Path { get; private set; }
        public ObservableCollection<IEpisodeViewModel> Episodes { get; private set; }

        public SeasonViewModel(ITvShowViewModelFactory viewModelFactory,
            ITvShowFileService tvShowFileService,
            ITvShowMetadataViewModel tvShowMetadata,
            ITvShowMetadataService metadataService,
            string path)
        {
            _viewModelFactory = viewModelFactory;
            _tvShowFileService = tvShowFileService;
            _tvShowMetadata = tvShowMetadata;
            Path = path;

            _posterUrl = viewModelFactory.GetImage(new SeasonPosterImageStrategy(metadataService, path));
            _bannerUrl = viewModelFactory.GetImage(new SeasonBannerImageStrategy(metadataService, path));

            // We need to set a "dummy" item in the collection for an arrow to appear in the TreeView since we're lazy-loading the items under it
            _imagesLoaded = false;
            _episodeLoaded = false;
            Episodes = new ObservableCollection<IEpisodeViewModel> { _viewModelFactory.GetEpisode(_tvShowMetadata, "dummy") };
        }

        public IEnumerable<ProgressItem> FindNewEpisodes()
        {
            LoadEpisodes();
            foreach (IEpisodeViewModel episode in Episodes)
            {
                foreach (ProgressItem item in episode.Update())
                {
                    yield return item;
                }
            }
        }

        private void LoadEpisodes()
        {
            if (!_episodeLoaded)
            {
                // Remove the dummy object
                Episodes.Clear();

                IEnumerable<PerfectMedia.TvShows.Episode> episodes = _tvShowFileService.GetEpisodes(Path);
                foreach (PerfectMedia.TvShows.Episode episode in episodes)
                {
                    IEpisodeViewModel episodeViewModel = _viewModelFactory.GetEpisode(_tvShowMetadata, episode.Path);
                    Episodes.Add(episodeViewModel);
                }
                _episodeLoaded = true;
            }
        }

        private void LoadImages()
        {
            if (!_imagesLoaded)
            {
                Season season = _tvShowFileService.GetSeason(_tvShowMetadata.Path, Path);
                _imagesLoaded = true;
                PosterUrl.Path = season.PosterUrl;
                BannerUrl.Path = season.BannerUrl;
            }
        }
    }
}
