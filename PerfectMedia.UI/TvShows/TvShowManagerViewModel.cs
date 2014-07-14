using PerfectMedia.Sources;
using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.Sources;
using PerfectMedia.UI.TvShows.Shows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.TvShows
{
    public class TvShowManagerViewModel : ISourceProvider
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly ITvShowFileService _tvShowFileService;
        private readonly ITvShowMetadataService _metadataService;

        public ISourceManagerViewModel Sources { get; private set; }
        public SmartObservableCollection<ITvShowViewModel> TvShows { get; private set; }
        public ICommand UpdateAll { get; private set; }
        public ICommand FindNewEpisodes { get; private set; }

        public TvShowManagerViewModel(ITvShowViewModelFactory viewModelFactory, ITvShowFileService tvShowFileService, ITvShowMetadataService metadataService, IProgressManagerViewModel progressManager)
        {
            _viewModelFactory = viewModelFactory;
            _tvShowFileService = tvShowFileService;
            _metadataService = metadataService;
            TvShows = new SmartObservableCollection<ITvShowViewModel>();

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
                case NotifyCollectionChangedAction.Move:
                default:
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
