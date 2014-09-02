using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PerfectMedia.UI.Actors
{
    public interface IActorManagerViewModel : INotifyPropertyChanged
    {
        ObservableCollection<IActorViewModel> Actors { get; }
        IActorViewModel SelectedActor { get; }
    }
}