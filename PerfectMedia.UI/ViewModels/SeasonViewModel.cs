using PerfectMedia.TvShows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.ViewModels
{
    public class SeasonViewModel : BaseViewModel, ITreeViewItemViewModel
    {
        private readonly ITvShowService _tvShowService;

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

        public SeasonViewModel(ITvShowService tvShowService, string path)
        {
            _tvShowService = tvShowService;
            Path = path;

            // We need to set a "dummy" item in the collection for an arrow to appear in the TreeView since we're lazy-loading the items under it
            _episodeLoaded = false;
            _episodes = new ObservableCollection<EpisodeViewModel> { new EpisodeViewModel("dummy") };
        }

        private void LoadEpisodes()
        {
            // Remove the dummy object
            _episodes.Clear();

            IEnumerable<Episode> episodes = _tvShowService.GetEpisodes(Path);
            foreach (Episode episode in episodes)
            {
                EpisodeViewModel episodeViewModel = new EpisodeViewModel(episode.Path);
                _episodes.Add(episodeViewModel);
            }
            _episodeLoaded = true;
        }
    }
}
