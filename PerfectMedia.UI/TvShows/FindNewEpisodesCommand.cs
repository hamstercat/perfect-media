using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Shows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PerfectMedia.UI.TvShows
{
    public class FindNewEpisodesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly SmartObservableCollection<ITvShowViewModel> _tvShows;
        private readonly IProgressManagerViewModel _progressManager;

        public FindNewEpisodesCommand(SmartObservableCollection<ITvShowViewModel> tvShows, IProgressManagerViewModel progressManager)
        {
            _tvShows = tvShows;
            _tvShows.CollectionChanged += TvShowsCollectionChanged;
            _progressManager = progressManager;
        }

        public bool CanExecute(object parameter)
        {
            return _tvShows.Count != 0;
        }

        public void Execute(object parameter)
        {
            foreach (ITvShowViewModel tvShow in _tvShows)
            {
                foreach (ProgressItem item in tvShow.FindNewEpisodes())
                {
                    _progressManager.AddItem(item);
                }
            }
            _progressManager.Start();
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
