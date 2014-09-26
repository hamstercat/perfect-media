using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Music.Artists.Selection;

namespace PerfectMedia.UI.Music.Artists
{
    public interface IArtistViewModel : IMetadataProvider
    {
        string Path { get; }
        string Id { get; }
        IPropertyViewModel<string> Name { get; }
        IArtistSelectionViewModel Selection { get; }
    }
}