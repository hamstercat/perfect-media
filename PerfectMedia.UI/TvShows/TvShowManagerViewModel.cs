using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using PerfectMedia.Sources;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.Sources;
using PerfectMedia.UI.TvShows.Shows;

namespace PerfectMedia.UI.TvShows
{
    public class TvShowManagerViewModel : ISourceProvider
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;

        public ISourceManagerViewModel Sources { get; private set; }
        public ObservableCollection<ITvShowViewModel> TvShows { get; private set; }
        public ICommand UpdateAll { get; private set; }
        public ICommand FindNewEpisodes { get; private set; }

        public TvShowManagerViewModel(ITvShowViewModelFactory viewModelFactory, IProgressManagerViewModel progressManager)
        {
            _viewModelFactory = viewModelFactory;
            TvShows = new ObservableCollection<ITvShowViewModel>();

            UpdateAll = new UpdateAllMetadataCommand<ITvShowViewModel>(TvShows, progressManager);
            FindNewEpisodes = new FindNewEpisodesCommand(TvShows, progressManager);

            LoadSources(viewModelFactory);
        }

        private void LoadSources(ITvShowViewModelFactory viewModelFactory)
        {
            Sources = viewModelFactory.GetSourceManager(SourceType.TvShow);
            Sources.SpecificFolders.CollectionChanged += SourceFoldersCollectionChanged;
            Sources.Load();
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
    }
}
