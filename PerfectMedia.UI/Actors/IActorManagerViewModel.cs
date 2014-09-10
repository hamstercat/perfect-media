using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PerfectMedia.UI.Actors
{
    public interface IActorManagerViewModel : INotifyPropertyChanged
    {
        ObservableCollection<IActorViewModel> Actors { get; }
        IActorViewModel SelectedActor { get; }
        void Initialize(IEnumerable<IActorViewModel> actors);
    }
}