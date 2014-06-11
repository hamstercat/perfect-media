using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.ViewModels
{
    public class SourceManagerViewModel : BaseViewModel
    {
        private readonly ObservableCollection<string> _rootFolders;
        public INotifyCollectionChanged RootFolders
        {
            get
            {
                return _rootFolders;
            }
        }

        private readonly ObservableCollection<string> _specificFolders;
        public INotifyCollectionChanged SpecificFolders
        {
            get
            {
                return _specificFolders;
            }
        }

        public SourceManagerViewModel()
        {
            _rootFolders = new ObservableCollection<string>();
            _specificFolders = new ObservableCollection<string>();

            _rootFolders.CollectionChanged += RootFoldersCollectionChanged;
        }

        public void AddRootFolder(string folder)
        {
            if (!_rootFolders.Contains(folder))
            {
                _rootFolders.Add(folder);
            }
        }

        public void AddSpecificFolder(string folder)
        {
            if (!_specificFolders.Contains(folder))
            {
                _specificFolders.Add(folder);
            }
        }

        public void RemoveRootFolder(string folderToRemove)
        {
            _rootFolders.Remove(folderToRemove);
        }

        public void RemoveSpecificFolder(string folderToRemove)
        {
            _specificFolders.Remove(folderToRemove);
        }

        public void RefreshSpecificFolders()
        {
            foreach (string folder in _rootFolders)
            {
                IEnumerable<string> tvShows = Directory.GetDirectories(folder);
                foreach (string tvShow in tvShows)
                {
                    AddSpecificFolder(tvShow);
                }
            }
        }

        private void RootFoldersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Required to update the UI binding
            // TODO: need to find another way than this
            OnPropertyChanged("RootFolders");
        }
    }
}
