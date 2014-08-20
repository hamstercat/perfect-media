using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using PerfectMedia.TvShows;
using PerfectMedia.UI.Busy;
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
        private readonly IBusyProvider _busyProvider;

        public string DisplayName
        {
            get
            {
                return Metadata.DisplayName;
            }
        }

        public string Title
        {
            get
            {
                return Metadata.Title.CachedValue;
            }
        }

        public string Path { get; private set; }
        public ITvShowMetadataViewModel Metadata { get; private set; }
        public ITvShowSelectionViewModel Selection { get; private set; }

        private bool _seasonLoaded;
        public ObservableCollection<ISeasonViewModel> Seasons { get; private set; }

        public TvShowViewModel(ITvShowViewModelFactory viewModelFactory, ITvShowFileService tvShowFileService, IBusyProvider busyProvider, string path)
        {
            _viewModelFactory = viewModelFactory;
            _tvShowFileService = tvShowFileService;
            _busyProvider = busyProvider;
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
            using (_busyProvider.DoWork())
            {
                await Metadata.Refresh();
            }
        }

        public async Task<IEnumerable<ProgressItem>> Update()
        {
            using (_busyProvider.DoWork())
            {
                return await Metadata.Update();
            }
        }

        public async Task Save()
        {
            using (_busyProvider.DoWork())
            {
                await Metadata.Save();
            }
        }

        public async Task Delete()
        {
            using (_busyProvider.DoWork())
            {
                await Metadata.Delete();
            }
        }

        public async Task<IEnumerable<ProgressItem>> FindNewEpisodes()
        {
            using (_busyProvider.DoWork())
            {
                await LoadChildren();
                List<ProgressItem> items = new List<ProgressItem>();
                foreach (ISeasonViewModel season in Seasons)
                {
                    items.AddRange(await season.FindNewEpisodes());
                }
                return items;
            }
        }

        public async Task Load()
        {
            using (_busyProvider.DoWork())
            {
                await Metadata.Load();
            }
        }

        public async Task LoadChildren()
        {
            if (!_seasonLoaded)
            {
                using (_busyProvider.DoWork())
                {
                    // Delete the dummy object
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
}
