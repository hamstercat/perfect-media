using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.ViewModels
{
    public class TvShowManagerViewModel : BaseViewModel, ISourceProvider
    {
        public SourceManagerViewModel Sources { get; private set; }
        public ObservableCollection<TvShowViewModel> TvShows { get; private set; }

        public TvShowViewModel _selectedItem;
        public TvShowViewModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                _selectedItem.Load();
                OnPropertyChanged("SelectedItem");
            }
        }

        public TvShowManagerViewModel()
        {
            Sources = new SourceManagerViewModel();
            TvShows = new ObservableCollection<TvShowViewModel>();

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
                case NotifyCollectionChangedAction.Move:
                default:
                    break;
            }
        }

        private void AddTvShows(IEnumerable<string> tvShows)
        {
            foreach (string path in tvShows)
            {
                TvShowViewModel newTvShow = new TvShowViewModel(path);
                TvShows.Add(newTvShow);
            }
        }

        private void RemoveTvShows(IEnumerable<string> tvShows)
        {
            foreach (string path in tvShows)
            {
                TvShowViewModel tvShowToRemove = TvShows.First(show => show.Path == path);
                TvShows.Remove(tvShowToRemove);
            }
        }
    }
}
