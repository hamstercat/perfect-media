using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Music.Albums;
using PerfectMedia.UI.Music.Artists;
using PerfectMedia.UI.Music.Tracks;
using PerfectMedia.UI.Sources;

namespace PerfectMedia.UI.Music
{
    public interface IMusicViewModelFactory
    {
        ISourceManagerViewModel GetSourceManager();
        IArtistViewModel GetArtist(string path);
        IAlbumViewModel GetAlbum(string path);
        ITrackViewModel GetTrack(string path);
    }
}