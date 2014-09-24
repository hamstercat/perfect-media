using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectMedia.Music.Albums;

namespace PerfectMedia.Music
{
    public class MusicFileService : IMusicFileService
    {
        private readonly IFileSystemService _fileSystemService;

        public MusicFileService(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        public async Task<IEnumerable<AlbumFile>> GetAlbums(string artistFolder)
        {
            if (string.IsNullOrEmpty(artistFolder)) throw new ArgumentNullException("artistFolder");

            IEnumerable<string> folders = await _fileSystemService.FindDirectories(artistFolder);
            return folders.Select(folder => new AlbumFile { Path = folder });
        }

        public async Task<IEnumerable<TrackFile>> GetTracks(string albumFolder)
        {
            if (string.IsNullOrEmpty(albumFolder)) throw new ArgumentNullException("albumFolder");

            IEnumerable<string> tracks = await _fileSystemService.FindAudioFiles(albumFolder);
            return tracks.Select(folder => new TrackFile { Path = folder });
        }
    }
}
