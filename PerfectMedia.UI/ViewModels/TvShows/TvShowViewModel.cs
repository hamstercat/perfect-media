using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.ViewModels.TvShows
{
    public class TvShowViewModel : BaseViewModel, ITreeViewItemViewModel
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
                if (!_seasonLoaded && _isExpanded)
                {
                    LoadSeasons();
                }
                OnPropertyChanged("IsExpanded");
            }
        }

        public string Path { get; private set; }
        public TvShowMetadataViewModel Metadata { get; private set; }

        private bool _seasonLoaded;
        private readonly ObservableCollection<SeasonViewModel> _seasons;
        public INotifyCollectionChanged Seasons
        {
            get
            {
                return _seasons;
            }
        }

        public TvShowViewModel(ITvShowViewModelFactory viewModelFactory, ITvShowFileService tvShowFileService, string path)
        {
            _viewModelFactory = viewModelFactory;
            _tvShowFileService = tvShowFileService;
            Path = path;
            Metadata = viewModelFactory.GetTvShowMetadata(Path);

            // We need to set a "dummy" item in the collection for an arrow to appear in the TreeView since we're lazy-loading the items under it
            _seasonLoaded = false;
            _seasons = new ObservableCollection<SeasonViewModel> { _viewModelFactory.GetSeason("dummy") };
        }

        private void LoadSeasons()
        {
            // Remove the dummy object
            _seasons.Clear();

            IEnumerable<Season> seasons = _tvShowFileService.GetSeasons(Path);
            foreach (Season season in seasons)
            {
                SeasonViewModel seasonViewModel = _viewModelFactory.GetSeason(season.Path);
                _seasons.Add(seasonViewModel);
            }
            _seasonLoaded = true;
        }
    }
}
