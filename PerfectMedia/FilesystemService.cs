using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PerfectMedia
{
    public class FileSystemService : IFileSystemService
    {
        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public void CreateFile(string filePath, IEnumerable<string> content)
        {
            File.WriteAllLines(filePath, content);
        }

        public void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        public void CopyFile(string sourceFile, string destinationFile)
        {
            File.Copy(sourceFile, destinationFile, true);
        }

        public void DownloadFile(string filePath, string url)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, filePath);
            }
        }

        public void SaveImageAsPng(string filePath, string url)
        {
            using (WebClient client = new WebClient())
            using (Stream stream = client.OpenRead(url))
            using (MagickImage image = new MagickImage(stream))
            {
                image.Write(filePath);
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

        public IEnumerable<string> FindDirectories(string path)
        {
            return FindDirectories(path, "*");
        }

        public IEnumerable<string> FindDirectories(string path, string searchPattern)
        {
            return Directory.GetDirectories(path, searchPattern, SearchOption.TopDirectoryOnly);
        }

        public IEnumerable<string> FindFiles(string path, params string[] extensions)
        {
            return Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly)
                .Where(file =>
                {
                    string extension = Path.GetExtension(file);
                    return extensions.Contains(extension.ToLower());
                });
        }
    }
}
