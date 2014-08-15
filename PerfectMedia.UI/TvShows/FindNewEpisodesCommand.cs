using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Shows;

namespace PerfectMedia.UI.TvShows
{
    public class FindNewEpisodesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly ObservableCollection<ITvShowViewModel> _tvShows;
        private readonly IProgressManagerViewModel _progressManager;

        public FindNewEpisodesCommand(ObservableCollection<ITvShowViewModel> tvShows, IProgressManagerViewModel progressManager)
        {
            _tvShows = tvShows;
            _tvShows.CollectionChanged += TvShowsCollectionChanged;
            _progressManager = progressManager;
        }

        public bool CanExecute(object parameter)
        {
            return _tvShows.Count != 0;
        }

        public async void Execute(object parameter)
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

        private void TvShowsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
