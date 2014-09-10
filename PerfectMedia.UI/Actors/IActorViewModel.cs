using System.ComponentModel;
using PerfectMedia.UI.Images;

namespace PerfectMedia.UI.Actors
{
    public interface IActorViewModel : INotifyPropertyChanged
    {
        string Name { get; }
        string Role { get; }
        string ThumbUrl { get; }
        IImageViewModel ThumbPath { get; }
        IActorViewModel Clone();
    }
}