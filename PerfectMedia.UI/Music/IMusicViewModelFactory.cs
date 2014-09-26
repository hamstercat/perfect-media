using PerfectMedia.UI.Images;
using PerfectMedia.UI.Music.Albums;
using PerfectMedia.UI.Music.Albums.Selection;
using PerfectMedia.UI.Music.Artists;
using PerfectMedia.UI.Music.Artists.Selection;
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
        IArtistSelectionViewModel GetArtistSelection(IArtistViewModel artistViewModel);
        IAlbumSelectionViewModel GetAlbumSelection(IAlbumViewModel albumViewModel);
    }
}