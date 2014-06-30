using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.TvShows.Seasons;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.TvShows.Shows
{
    [ImplementPropertyChanged]
    public class TvShowViewModel : ITvShowViewModel, ITreeViewItemViewModel
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
            }
        }

        public string Path { get; private set; }
        public ITvShowMetadataViewModel Metadata { get; private set; }

        private bool _seasonLoaded;
        public ObservableCollection<ISeasonViewModel> Seasons { get; private set; }

        public TvShowViewModel(ITvShowViewModelFactory viewModelFactory, ITvShowFileService tvShowFileService, string path)
        {
            _viewModelFactory = viewModelFactory;
            _tvShowFileService = tvShowFileService;
            Path = path;
            Metadata = viewModelFactory.GetTvShowMetadata(Path);

            // We need to set a "dummy" item in the collection for an arrow to appear in the TreeView since we're lazy-loading the items under it
            _seasonLoaded = false;
            Seasons = new ObservableCollection<ISeasonViewModel> { _viewModelFactory.GetSeason(Path, "dummy") };
        }

        private void LoadSeasons()
        {
            // Remove the dummy object
            Seasons.Clear();

            IEnumerable<Season> seasons = _tvShowFileService.GetSeasons(Path);
            foreach (Season season in seasons)
            {
                ISeasonViewModel seasonViewModel = _viewModelFactory.GetSeason(Path, season.Path);
                Seasons.Add(seasonViewModel);
            }
            _seasonLoaded = true;
        }
    }
}
