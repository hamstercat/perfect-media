using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectMedia.ExternalApi;

namespace PerfectMedia.Music
{
    public class MusicImageService : IMusicImageService
    {
        private readonly IFileSystemService _fileSystemService;

        public MusicImageService(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        public async Task UpdateArtist(string path, string imageUrl)
        {
            string fanart = MusicHelper.GetArtistImage(path);
            await DownloadImageIfNeeded(fanart, imageUrl);
        }

        public async Task DeleteArtist(string path)
        {
            string fanart = MusicHelper.GetArtistImage(path);
            await _fileSystemService.DeleteFile(fanart);
        }

        public async Task UpdateAlbum(string path, string imageUrl)
        {
            string album = MusicHelper.GetAlbumImage(path);
            await DownloadImageIfNeeded(album, imageUrl);
        }

        public async Task DeleteAlbum(string path)
        {
            string album = MusicHelper.GetAlbumImage(path);
            await _fileSystemService.DeleteFile(album);
        }

        private async Task DownloadImageIfNeeded(string path, string url)
        {
            if (!await _fileSystemService.FileExists(path) && !string.IsNullOrEmpty(url))
            {
                await _fileSystemService.DownloadImage(path, url);
            }
        }
    }
}
