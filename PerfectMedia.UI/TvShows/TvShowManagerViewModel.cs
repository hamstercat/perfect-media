using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.Sources;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.Sources;
using PerfectMedia.UI.TvShows.Shows;

namespace PerfectMedia.UI.TvShows
{
    public class TvShowManagerViewModel : ITvShowManagerViewModel, ISourceProvider, ILifecycleService
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly IBusyProvider _busyProvider;

        public ISourceManagerViewModel Sources { get; private set; }
        public ObservableCollection<ITvShowViewModel> TvShows { get; private set; }
        public ICommand UpdateAll { get; private set; }
        public ICommand FindNewEpisodes { get; private set; }

        public TvShowManagerViewModel(ITvShowViewModelFactory viewModelFactory, IProgressManagerViewModel progressManager, IBusyProvider busyProvider)
        {
            _viewModelFactory = viewModelFactory;
            _busyProvider = busyProvider;
            TvShows = new ObservableCollection<ITvShowViewModel>();

            UpdateAll = new UpdateAllMetadataCommand<ITvShowViewModel>(TvShows, progressManager, busyProvider);
            FindNewEpisodes = new FindNewEpisodesCommand(TvShows, progressManager, busyProvider);

            Sources = viewModelFactory.GetSourceManager(SourceType.TvShow);
            Sources.SpecificFolders.CollectionChanged += SourceFoldersCollectionChanged;
        }

        private void SourceFoldersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddTvShows(e.NewItems.Cast<string>());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveTvShows(e.OldItems.Cast<string>());
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RemoveTvShows(e.OldItems.Cast<string>());
                    AddTvShows(e.NewItems.Cast<string>());
                    break;
                case NotifyCollectionChangedAction.Reset:
                    TvShows.Clear();
                    break;
            }
        }

        private void AddTvShows(IEnumerable<string> tvShows)
        {
            foreach (string path in tvShows)
            {
                ITvShowViewModel newTvShow = _viewModelFactory.GetTvShow(path);
                TvShows.Add(newTvShow);
            }
        }

        private void RemoveTvShows(IEnumerable<string> tvShows)
        {
            foreach (string path in tvShows)
            {
                ITvShowViewModel tvShowToRemove = TvShows.First(show => show.Path == path);
                TvShows.Remove(tvShowToRemove);
            }
        }

        void ILifecycleService.Initialize()
        {
            using (_busyProvider.DoWork())
            {
                Sources.Load();
                TvShows.CollectionChanged += RefreshNewItems;
            }
        }

        private void RefreshNewItems(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (ITvShowViewModel tvShow in e.NewItems.Cast<ITvShowViewModel>())
                {
                    if (string.IsNullOrEmpty(tvShow.Title))
                    {
                        // Add to cache
                        tvShow.Refresh();
                    }
                }
            }
        }

        void ILifecycleService.Uninitialize()
        {
            // Do nothing
        }
    }
}
