using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Music.Albums.Selection;

namespace PerfectMedia.UI.Music.Albums
{
    public interface IAlbumViewModel : IMetadataProvider
    {
        string Path { get; }
        string Id { get; }
        IPropertyViewModel<string> Title { get; }
        string ArtistId { get; }
        IAlbumSelectionViewModel Selection { get; }
    }
}
