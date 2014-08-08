﻿using System.Collections.ObjectModel;

namespace PerfectMedia.UI.Sources
{
    public interface ISourceManagerViewModel
    {
        void AddRootFolder(string folder);
        void RemoveRootFolder(string folderToRemove);

        ObservableCollection<string> SpecificFolders { get; }
        void RefreshSpecificFolders();
        void AddSpecificFolder(string folder);
        void RemoveSpecificFolder(string folderToRemove);

        void Load();
    }
}
