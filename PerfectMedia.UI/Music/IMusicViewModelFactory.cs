using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Music.Artists;
using PerfectMedia.UI.Sources;

namespace PerfectMedia.UI.Music
{
    public interface IMusicViewModelFactory
    {
        ISourceManagerViewModel GetSourceManager();
        IArtistViewModel GetArtistViewModel(string path);
        ICachedPropertyViewModel<string> GetStringCachedProperty(string key, bool isRequired);
    }
}