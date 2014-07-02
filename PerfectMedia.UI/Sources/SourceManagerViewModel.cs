using PerfectMedia.Sources;
using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace PerfectMedia.UI.Sources
{
    [ImplementPropertyChanged]
    public class SourceManagerViewModel : ISourceManagerViewModel
    {
        private readonly ISourceService _sourceService;
        private readonly IFileSystemService _fileSystemService;
        private readonly SourceType _sourceType;

        public ObservableCollection<string> RootFolders { get; private set; }
        public ObservableCollection<string> SpecificFolders { get; private set; }

        public SourceManagerViewModel(ISourceService sourceService, IFileSystemService fileSystemService, SourceType sourceType)
        {
            _sourceService = sourceService;
            _fileSystemService = fileSystemService;
            _sourceType = sourceType;

            RootFolders = new ObservableCollection<string>();
            SpecificFolders = new ObservableCollection<string>();

            RootFolders.CollectionChanged += RootFoldersCollectionChanged;
            SpecificFolders.CollectionChanged += SpecificFoldersCollectionChanged;
        }

        public void Load()
        {
            IEnumerable<Source> sources = _sourceService.GetSources(_sourceType);

            // Since we're loading the sources from the repo, don't save them back when adding them in the manager
            RootFolders.CollectionChanged -= RootFoldersCollectionChanged;
            SpecificFolders.CollectionChanged -= SpecificFoldersCollectionChanged;

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

            RootFolders.CollectionChanged += RootFoldersCollectionChanged;
            SpecificFolders.CollectionChanged += SpecificFoldersCollectionChanged;
        }

        public void AddRootFolder(string folder)
        {
            if (!RootFolders.Contains(folder))
            {
                RootFolders.Add(folder);
            }
        }

        public void AddSpecificFolder(string folder)
        {
            if (!SpecificFolders.Contains(folder))
            {
                SpecificFolders.Add(folder);
            }
        }

        public void RemoveRootFolder(string folderToRemove)
        {
            RootFolders.Remove(folderToRemove);
        }

        public void RemoveSpecificFolder(string folderToRemove)
        {
            SpecificFolders.Remove(folderToRemove);
        }

        public void RefreshSpecificFolders()
        {
            foreach (string folder in RootFolders)
            {
                IEnumerable<string> specificFolders = _fileSystemService.FindDirectories(folder);
                foreach (string specificFolder in specificFolders)
                {
                    AddSpecificFolder(specificFolder);
                }
            }
        }

        private void RootFoldersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddFolders(RootFolders, e.NewItems.Cast<string>(), true);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveFolders(RootFolders, e.OldItems.Cast<string>(), true);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RemoveFolders(RootFolders, e.OldItems.Cast<string>(), true);
                    AddFolders(RootFolders, e.NewItems.Cast<string>(), true);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    RootFolders.Clear();
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
                    AddFolders(SpecificFolders, e.NewItems.Cast<string>(), false);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveFolders(SpecificFolders, e.OldItems.Cast<string>(), false);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RemoveFolders(SpecificFolders, e.OldItems.Cast<string>(), false);
                    AddFolders(SpecificFolders, e.NewItems.Cast<string>(), false);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    SpecificFolders.Clear();
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
                _sourceService.Save(source);
            }
        }

        private void RemoveFolders(ObservableCollection<string> foldersCollection, IEnumerable<string> foldersToRemove, bool isRoot)
        {
            foreach (string folder in foldersToRemove)
            {
                Source source = new Source(_sourceType, isRoot, folder);
                _sourceService.Delete(source);
            }
        }
    }
}
