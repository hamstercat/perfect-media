using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Shows;

namespace PerfectMedia.UI.TvShows
{
    public class FindNewEpisodesCommand : AsyncCommand
    {
        public override event EventHandler CanExecuteChanged;
        private readonly ObservableCollection<ITvShowViewModel> _tvShows;
        private readonly IProgressManagerViewModel _progressManager;
        private readonly IBusyProvider _busyProvider;

        public FindNewEpisodesCommand(ObservableCollection<ITvShowViewModel> tvShows, IProgressManagerViewModel progressManager, IBusyProvider busyProvider)
        {
            _tvShows = tvShows;
            _tvShows.CollectionChanged += TvShowsCollectionChanged;
            _progressManager = progressManager;
            _busyProvider = busyProvider;
        }

        public override bool CanExecute(object parameter)
        {
            return _tvShows.Count != 0;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            using (_busyProvider.DoWork())
            {
                foreach (ITvShowViewModel tvShow in _tvShows)
                {
                    foreach (ProgressItem item in await tvShow.FindNewEpisodes())
                    {
                        _progressManager.AddItem(item);
                    }
                }
                await _progressManager.Start();
            }
        }

        private void TvShowsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
