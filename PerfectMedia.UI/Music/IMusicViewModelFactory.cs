using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Images;
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
        IAlbumViewModel GetAlbum(string path, IArtistViewModel artistViewModel);
        ITrackViewModel GetTrack(string path);
        IImageViewModel GetImage(bool horizontalAlignement);
        IImageViewModel GetImage(bool horizontalAlignement, IImageStrategy imageStrategy);
    }
}