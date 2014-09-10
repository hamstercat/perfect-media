using System.ComponentModel;
using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Images;

namespace PerfectMedia.UI.Actors
{
    public interface IActorViewModel : INotifyPropertyChanged
    {
        IPropertyViewModel<string> Name { get; }
        IPropertyViewModel<string> Role { get; }
        string ThumbUrl { get; }
        IImageViewModel ThumbPath { get; }
    }
}