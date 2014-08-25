using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Music.Artists;
using PerfectMedia.UI.Sources;
using PropertyChanged;

namespace PerfectMedia.UI.Music
{
    [ImplementPropertyChanged]
    public class MusicManagerViewModel : IMusicManagerViewModel, ISourceProvider, ILifecycleService
    {
        private readonly IMusicViewModelFactory _viewModelFactory;
        private readonly IBusyProvider _busyProvider;

        public ISourceManagerViewModel Sources { get; set; }
        public ObservableCollection<IArtistViewModel> Artists { get; private set; }

        public MusicManagerViewModel(IMusicViewModelFactory viewModelFactory, IBusyProvider busyProvider)
        {
            _viewModelFactory = viewModelFactory;
            _busyProvider = busyProvider;
            Artists = new ObservableCollection<IArtistViewModel>();

            Sources = _viewModelFactory.GetSourceManager();
            Sources.SpecificFolders.CollectionChanged += SourceFoldersCollectionChanged;
        }

        private void SourceFoldersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddArtists(e.NewItems.Cast<string>());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveArtists(e.OldItems.Cast<string>());
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RemoveArtists(e.OldItems.Cast<string>());
                    AddArtists(e.NewItems.Cast<string>());
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Artists.Clear();
                    break;
            }
        }

        private void AddArtists(IEnumerable<string> artists)
        {
            foreach (string path in artists)
            {
                IArtistViewModel newArtist = _viewModelFactory.GetArtistViewModel(path);
                Artists.Add(newArtist);
            }
        }

        private void RemoveArtists(IEnumerable<string> artists)
        {
            foreach (string path in artists)
            {
                IArtistViewModel artistToRemove = Artists.First(artist => artist.Path == path);
                Artists.Remove(artistToRemove);
            }
        }

        void ILifecycleService.Initialize()
        {
            using (_busyProvider.DoWork())
            {
                Sources.Load();
                Artists.CollectionChanged += RefreshNewItems;
            }
        }

        private void RefreshNewItems(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (IArtistViewModel artist in e.NewItems.Cast<IArtistViewModel>())
                {
                    if (string.IsNullOrEmpty(artist.Name.Value))
                    {
                        // Add to cache
                        artist.Refresh();
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
