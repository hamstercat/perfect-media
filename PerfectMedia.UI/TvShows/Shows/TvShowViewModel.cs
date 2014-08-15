﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task Refresh()
        {
            await Metadata.Refresh();
        }

        public async Task<IEnumerable<ProgressItem>> Update()
        {
            return await Metadata.Update();
        }

        public async Task Save()
        {
            await Metadata.Save();
        }

        public async Task<IEnumerable<ProgressItem>> FindNewEpisodes()
        {
            await LoadSeasons();
            List<ProgressItem> items = new List<ProgressItem>();
            foreach (ISeasonViewModel season in Seasons)
            {
                items.AddRange(await season.FindNewEpisodes());
            }
            return items;
        }

        private async Task LoadSeasons()
        {
            if (!_seasonLoaded)
            {
                // Remove the dummy object
                Seasons.Clear();

                IEnumerable<Season> seasons = await _tvShowFileService.GetSeasons(Path);
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
