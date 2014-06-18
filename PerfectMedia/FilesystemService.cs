using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia
{
    public class FilesystemService : IFileSystemService
    {
        public IEnumerable<string> FindSeasonFolders(string path)
        {
            IEnumerable<string> normalSeasons = Directory.GetDirectories(path, "Season *", SearchOption.TopDirectoryOnly);
            IEnumerable<string> specialSeasons = Directory.GetDirectories(path, "Special*", SearchOption.TopDirectoryOnly);
            return normalSeasons.Union(specialSeasons);
        }

        public IEnumerable<string> FindVideoFiles(string path)
        {
            return Directory.GetFiles(path, "*.mkv", SearchOption.TopDirectoryOnly);
        }

        public void DownloadFile(string filePath, string url)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, filePath);
            }
        }
    }
}
