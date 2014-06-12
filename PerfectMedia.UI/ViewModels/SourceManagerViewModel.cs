using PerfectMedia.Sources;
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
        private readonly ISourceRepository _sourceRepository;
        private readonly SourceType _sourceType;

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

        public SourceManagerViewModel(ISourceRepository sourceRepository, SourceType sourceType)
        {
            _sourceRepository = sourceRepository;
            _sourceType = sourceType;

            _rootFolders = new ObservableCollection<string>();
            _specificFolders = new ObservableCollection<string>();

            _rootFolders.CollectionChanged += RootFoldersCollectionChanged;
            _specificFolders.CollectionChanged += SpecificFoldersCollectionChanged;
        }

        public void Load()
        {
            IEnumerable<Source> sources = _sourceRepository.GetSources(_sourceType);

            // Since we're loading the sources from the repo, don't save them back when adding them in the manager
            _rootFolders.CollectionChanged -= RootFoldersCollectionChanged;
            _specificFolders.CollectionChanged -= SpecificFoldersCollectionChanged;

            foreach (Source source in sources)
            {
                if (source.IsRoot)
                {
                    AddRootFolder(source.Folder);
                }
                else
                {
                    AddSpecificFolder(source.Folder);
                }
            }

            _rootFolders.CollectionChanged += RootFoldersCollectionChanged;
            _specificFolders.CollectionChanged += SpecificFoldersCollectionChanged;
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

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddFolders(_rootFolders, e.NewItems.Cast<string>(), true);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveFolders(_rootFolders, e.NewItems.Cast<string>(), true);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RemoveFolders(_rootFolders, e.OldItems.Cast<string>(), true);
                    AddFolders(_rootFolders, e.NewItems.Cast<string>(), true);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    _rootFolders.Clear();
                    break;
                case NotifyCollectionChangedAction.Move:
                default:
                    break;
            }
        }

        private void SpecificFoldersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddFolders(_specificFolders, e.NewItems.Cast<string>(), false);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveFolders(_specificFolders, e.NewItems.Cast<string>(), false);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RemoveFolders(_specificFolders, e.OldItems.Cast<string>(), false);
                    AddFolders(_specificFolders, e.NewItems.Cast<string>(), false);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    _specificFolders.Clear();
                    break;
                case NotifyCollectionChangedAction.Move:
                default:
                    break;
            }
        }

        private void AddFolders(ObservableCollection<string> foldersCollection, IEnumerable<string> newFolders, bool isRoot)
        {
            foreach (string folder in newFolders)
            {
                Source source = new Source(_sourceType, isRoot, folder);
                _sourceRepository.Save(source);
            }
        }

        private void RemoveFolders(ObservableCollection<string> foldersCollection, IEnumerable<string> foldersToRemove, bool isRoot)
        {
            foreach (string folder in foldersToRemove)
            {
                Source source = new Source(_sourceType, isRoot, folder);
                _sourceRepository.Delete(source);
            }
        }
    }
}
