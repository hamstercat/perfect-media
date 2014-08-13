﻿using System.Collections.Generic;
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

        public void MoveFile(string sourceFile, string destinationFile)
        {
            if (FileExists(sourceFile))
            {
                File.Move(sourceFile, destinationFile);
            }
        }

        public async Task DownloadImage(string filePath, string url)
        {
            await DownloadImageAsync(filePath, url);
        }

        public bool FolderExists(string folderName)
        {
            return Directory.Exists(folderName);
        }

        public void CreateFolder(string folderName)
        {
            Directory.CreateDirectory(folderName);
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

        public IEnumerable<string> FindDirectories(string path)
        {
            return FindDirectories(path, "*");
        }

        public IEnumerable<string> FindDirectories(string path, string searchPattern)
        {
            return Directory.GetDirectories(path, searchPattern, SearchOption.TopDirectoryOnly);
        }

        public IEnumerable<string> FindVideoFiles(string path)
        {
            return FindFiles(path, VideoFileExtensions);
        }

        private Task DownloadImageAsync(string filePath, string url)
        {
            return Task.Run(() =>
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

        private IEnumerable<string> FindFiles(string path, params string[] extensions)
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
