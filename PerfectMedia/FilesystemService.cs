using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia
{
    public class FileSystemService : IFileSystemService
    {
        public bool FileExists(string nfoFileFullPath)
        {
            return File.Exists(nfoFileFullPath);
        }

        public void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        public void DownloadFile(string filePath, string url)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, filePath);
            }
        }

        public bool FolderExists(string folderName)
        {
            return Directory.Exists(folderName);
        }

        public void CreateFolder(string folderName)
        {
            Directory.CreateDirectory(folderName);
        }

        public IEnumerable<string> FindDirectories(string path, string searchPattern)
        {
            return Directory.GetDirectories(path, searchPattern, SearchOption.TopDirectoryOnly);
        }

        public IEnumerable<string> FindFiles(string path, string searchPattern)
        {
            return Directory.GetFiles(path, searchPattern, SearchOption.TopDirectoryOnly);
        }
    }
}
