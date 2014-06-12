using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia
{
    public class FileFinder : IFileFinder
    {
        public IEnumerable<string> FindFolders(string path, string searchPattern)
        {
            return Directory.GetDirectories(path, searchPattern, SearchOption.TopDirectoryOnly);
        }

        public IEnumerable<string> FindVideoFiles(string path)
        {
            return Directory.GetFiles(path, "*.mkv", SearchOption.TopDirectoryOnly);
        }
    }
}
