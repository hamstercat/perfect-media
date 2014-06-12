using PerfectMedia.TvShows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.ViewModels
{
    public class TvShowViewModel : BaseViewModel, ITreeViewItemViewModel
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
                if (!_seasonLoaded && _isExpanded)
                {
                    LoadSeasons();
                }
                OnPropertyChanged("IsExpanded");
            }
        }

        public string Path { get; private set; }

        private bool _seasonLoaded;
        private readonly ObservableCollection<SeasonViewModel> _seasons;
        public INotifyCollectionChanged Seasons
        {
            get
            {
                return _seasons;
            }
        }

        public TvShowViewModel(ITvShowService tvShowService, string path)
        {
            _tvShowService = tvShowService;
            Path = path;

            // We need to set a "dummy" item in the collection for an arrow to appear in the TreeView since we're lazy-loading the items under it
            _seasonLoaded = false;
            _seasons = new ObservableCollection<SeasonViewModel> { new SeasonViewModel(_tvShowService, "dummy") };
        }

        public void Load()
        {
            // TODO: refresh this show from filesystem
        }

        private void LoadSeasons()
        {
            // Remove the dummy object
            _seasons.Clear();

            IEnumerable<Season> seasons = _tvShowService.GetSeasons(Path);
            foreach (Season season in seasons)
            {
                SeasonViewModel seasonViewModel = new SeasonViewModel(_tvShowService, season.Path);
                _seasons.Add(seasonViewModel);
            }
            _seasonLoaded = true;
        }
    }
}
