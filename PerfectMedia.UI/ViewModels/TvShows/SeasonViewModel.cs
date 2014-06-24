using PerfectMedia.TvShows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.ViewModels.TvShows
{
    public class SeasonViewModel : BaseViewModel, ITreeViewItemViewModel
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly ITvShowFileService _tvShowFileService;

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
                if (!_episodeLoaded && _isExpanded)
                {
                    LoadEpisodes();
                }
                OnPropertyChanged("IsExpanded");
            }
        }

        public string Path { get; private set; }
        
        private bool _episodeLoaded;
        private readonly ObservableCollection<EpisodeViewModel> _episodes;
        public INotifyCollectionChanged Episodes
        {
            get
            {
                return _episodes;
            }
        }

        public SeasonViewModel(ITvShowViewModelFactory viewModelFactory, ITvShowFileService tvShowFileService, string path)
        {
            _viewModelFactory = viewModelFactory;
            _tvShowFileService = tvShowFileService;
            Path = path;

            // We need to set a "dummy" item in the collection for an arrow to appear in the TreeView since we're lazy-loading the items under it
            _episodeLoaded = false;
            _episodes = new ObservableCollection<EpisodeViewModel> { _viewModelFactory.GetEpisode("dummy") };
        }

        private void LoadEpisodes()
        {
            // Remove the dummy object
            _episodes.Clear();

            IEnumerable<Episode> episodes = _tvShowFileService.GetEpisodes(Path);
            foreach (Episode episode in episodes)
            {
                EpisodeViewModel episodeViewModel = _viewModelFactory.GetEpisode(episode.Path);
                _episodes.Add(episodeViewModel);
            }
            _episodeLoaded = true;
        }
    }
}
