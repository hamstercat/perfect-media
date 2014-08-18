using System.ComponentModel;
using System.Threading.Tasks;
using PerfectMedia.UI.Metadata;

namespace PerfectMedia.UI.TvShows.Shows
{
    public interface ITvShowMetadataViewModel : INotifyPropertyChanged, IMetadataProvider
    {
        string Id { get; }
        string Path { get; }
        string DisplayName { get; }
        ICachedPropertyViewModel<string> Title { get; }
        Task Load();
    }
}
