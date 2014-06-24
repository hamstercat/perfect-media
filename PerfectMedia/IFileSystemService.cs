using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia
{
    public interface IFileSystemService
    {
        bool FileExists(string nfoFileFullPath);
        void DeleteFile(string filePath);
        void DownloadFile(string filePath, string url);

        bool FolderExists(string folderName);
        void CreateFolder(string folderName);

        IEnumerable<string> FindDirectories(string path, string searchPattern);
        IEnumerable<string> FindFiles(string path, string searchPattern);
    }
}
