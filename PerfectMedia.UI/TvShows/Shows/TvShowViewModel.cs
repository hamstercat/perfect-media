using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PerfectMedia.TvShows;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Seasons;
using PerfectMedia.UI.TvShows.ShowSelection;
using PropertyChanged;

namespace PerfectMedia.UI.TvShows.Shows
{
    [ImplementPropertyChanged]
    public class TvShowViewModel : BaseViewModel, ITvShowViewModel, ITreeViewItemViewModel
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
                if (_isExpanded)
                {
                    LoadSeasons();
                }
            }
        }

        public string DisplayName
        {
            get
            {
                return Metadata.DisplayName;
            }
        }

        public string Path { get; private set; }
        public ITvShowMetadataViewModel Metadata { get; private set; }
        public ITvShowSelectionViewModel Selection { get; private set; }

        private bool _seasonLoaded;
        public ObservableCollection<ISeasonViewModel> Seasons { get; private set; }

        public TvShowViewModel(ITvShowViewModelFactory viewModelFactory, ITvShowFileService tvShowFileService, string path)
        {
            _viewModelFactory = viewModelFactory;
            _tvShowFileService = tvShowFileService;
            Path = path;
            Metadata = viewModelFactory.GetTvShowMetadata(Path);
            Metadata.PropertyChanged += (s, e) => OnPropertyChanged("DisplayName");
            Selection = viewModelFactory.GetTvShowSelection(Metadata, path);

            // We need to set a "dummy" item in the collection for an arrow to appear in the TreeView since we're lazy-loading the items under it
            _seasonLoaded = false;
            Seasons = new ObservableCollection<ISeasonViewModel> { _viewModelFactory.GetSeason(Metadata, "dummy") };
        }

        public void Refresh()
        {
            Metadata.Refresh();
        }

        public IEnumerable<ProgressItem> Update()
        {
            return Metadata.Update();
        }

        public void Save()
        {
            Metadata.Save();
        }

        public IEnumerable<ProgressItem> FindNewEpisodes()
        {
            LoadSeasons();
            return Seasons.SelectMany(season => season.FindNewEpisodes());
        }

        private void LoadSeasons()
        {
            if (!_seasonLoaded)
            {
                // Remove the dummy object
                Seasons.Clear();

                IEnumerable<Season> seasons = _tvShowFileService.GetSeasons(Path);
                foreach (Season season in seasons)
                {
                    ISeasonViewModel seasonViewModel = _viewModelFactory.GetSeason(Metadata, season.Path);
                    Seasons.Add(seasonViewModel);
                }
                _seasonLoaded = true;
            }
        }
    }
}
