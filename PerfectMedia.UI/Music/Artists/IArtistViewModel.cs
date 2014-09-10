using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Metadata;

namespace PerfectMedia.UI.Music.Artists
{
    public interface IArtistViewModel : IMetadataProvider
    {
        string Path { get; }
        IPropertyViewModel<string> Name { get; }
    }
}