﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Sources
{
    public interface ISourceManagerViewModel
    {
        void AddRootFolder(string folder);
        void RemoveRootFolder(string folderToRemove);

        ObservableCollection<string> SpecificFolders { get; }
        Task RefreshSpecificFolders();
        void AddSpecificFolder(string folder);
        void RemoveSpecificFolder(string folderToRemove);

        void Load();
    }
}
