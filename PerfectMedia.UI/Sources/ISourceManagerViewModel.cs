using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

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
