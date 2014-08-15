using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using ImageMagick;
using System.Threading.Tasks;

namespace PerfectMedia
{
    public class FileSystemService : IFileSystemService
    {
        private static readonly string[] VideoFileExtensions = ConfigurationManager.AppSettings["VideoFileExtensions"].Split(',');

        public Task<bool> FileExists(string filePath)
        {
            return Task.Run(() => File.Exists(filePath));
        }

        public async Task CreateFile(string filePath, IEnumerable<string> content)
        {
            await Task.Run(() => File.WriteAllLines(filePath, content));
        }

        public async Task DeleteFile(string filePath)
        {
            await Task.Run(() => File.Delete(filePath));
        }

        public async Task CopyFile(string sourceFile, string destinationFile)
        {
            await Task.Run(() => File.Copy(sourceFile, destinationFile, true));
        }

        public async Task MoveFile(string sourceFile, string destinationFile)
        {
            if (await FileExists(sourceFile))
            {
                await Task.Run(() => File.Move(sourceFile, destinationFile));
            }
        }

        public async Task DownloadImage(string filePath, string url)
        {
            await Task.Run(() =>
            {
                using (WebClient client = new WebClient())
                using (Stream stream = client.OpenRead(url))
                using (MagickImage image = new MagickImage(stream))
                {
                    image.Quality = 80;
                    image.Write(filePath);
                }
            });
        }

        public async Task<bool> FolderExists(string folderName)
        {
            return await Task.Run(() => Directory.Exists(folderName));
        }

        public async Task CreateFolder(string folderName)
        {
            await Task.Run(() => Directory.CreateDirectory(folderName));
        }

        // This method comes from https://stackoverflow.com/questions/4389775/what-is-a-good-way-to-remove-last-few-directory
        // TODO: Rewrite it more clearly
        public string GetParentFolder(string path, int parentCount)
        {
            if (string.IsNullOrEmpty(path) || parentCount < 1)
                return path;

            string parent = Path.GetDirectoryName(path);

            if (--parentCount > 0)
                return GetParentFolder(parent, parentCount);

            return parent;
        }

        public async Task<IEnumerable<string>> FindDirectories(string path)
        {
            return await FindDirectories(path, "*");
        }

        public async Task<IEnumerable<string>> FindDirectories(string path, string searchPattern)
        {
            return await Task.Run(() => Directory.GetDirectories(path, searchPattern, SearchOption.TopDirectoryOnly));
        }

        public async Task<IEnumerable<string>> FindVideoFiles(string path)
        {
            return await FindFiles(path, VideoFileExtensions);
        }

        private static async Task<IEnumerable<string>> FindFiles(string path, params string[] extensions)
        {
            IEnumerable<string> files = await Task.Run(() => Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly));
            return files.Where(file =>
            {
                string extension = Path.GetExtension(file);
                return extensions.Contains(extension.ToLower());
            });
        }
    }
}
