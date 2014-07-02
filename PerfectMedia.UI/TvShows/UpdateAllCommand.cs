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
    public class UpdateAllCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly ObservableCollection<ITvShowViewModel> _tvShows;

        public UpdateAllCommand(ObservableCollection<ITvShowViewModel> tvShows)
        {
            _tvShows = tvShows;
            _tvShows.CollectionChanged += TvShowsCollectionChanged;
        }

        public bool CanExecute(object parameter)
        {
            return _tvShows.Count != 0;
        }

        public void Execute(object parameter)
        {
            foreach (ITvShowViewModel tvShow in _tvShows)
            {
                try
                {
                    tvShow.Update();
                }
                catch (ItemNotFoundException)
                {
                    // TODO
                    throw;
                }
            }
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
