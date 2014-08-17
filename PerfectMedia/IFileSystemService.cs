using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectMedia
{
    public interface IFileSystemService
    {
        Task<bool> FileExists(string filePath);
        bool FileExistsSynchronously(string filePath);
        Task CreateFile(string filePath, params string[] content);
        void CreateFileSynchronously(string filePath, params string[] content);
        Task DeleteFile(string filePath);
        Task CopyFile(string sourceFile, string destinationFile);
        Task MoveFile(string sourceFile, string destinationFile);
        Task DownloadImage(string filePath, string url);

        Task<bool> FolderExists(string folderName);
        Task CreateFolder(string folderName);
        void CreateFolderSynchronously(string folderName);
        string GetParentFolder(string path, int parentCount);

        Task<IEnumerable<string>> FindDirectories(string path);
        Task<IEnumerable<string>> FindDirectories(string path, string searchPattern);
        Task<IEnumerable<string>> FindVideoFiles(string path);
    }
}
