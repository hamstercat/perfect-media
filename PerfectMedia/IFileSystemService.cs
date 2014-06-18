using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia
{
    public interface IFileSystemService
    {
        IEnumerable<string> FindFolders(string path, string searchPattern);
        IEnumerable<string> FindVideoFiles(string path);
        void DownloadFile(string filePath, string url);
    }
}
