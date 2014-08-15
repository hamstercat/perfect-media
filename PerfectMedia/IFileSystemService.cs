﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectMedia
{
    public interface IFileSystemService
    {
        Task<bool> FileExists(string filePath);
        void CreateFile(string filePath, IEnumerable<string> content);
        void DeleteFile(string filePath);
        void CopyFile(string sourceFile, string destinationFile);
        Task MoveFile(string sourceFile, string destinationFile);
        Task DownloadImage(string filePath, string url);

        bool FolderExists(string folderName);
        void CreateFolder(string folderName);
        string GetParentFolder(string path, int parentCount);

        IEnumerable<string> FindDirectories(string path);
        IEnumerable<string> FindDirectories(string path, string searchPattern);
        IEnumerable<string> FindVideoFiles(string path);
    }
}
