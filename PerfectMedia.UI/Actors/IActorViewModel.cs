using System.ComponentModel;

namespace PerfectMedia.UI.Actors
{
    public interface IActorViewModel : INotifyPropertyChanged
    {
        string Name { get; }
        string Role { get; }
    }
}