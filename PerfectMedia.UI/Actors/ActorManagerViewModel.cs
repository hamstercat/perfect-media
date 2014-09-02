using System.Windows.Input;
using PerfectMedia.UI.Validations;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace PerfectMedia.UI.Actors
{
    [ImplementPropertyChanged]
    public class ActorManagerViewModel : BaseViewModel, IActorManagerViewModel
    {
        public ObservableCollection<IActorViewModel> Actors { get; private set; }
        public IActorViewModel SelectedActor { get; set; }

        public ICommand AddCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }

        public ActorManagerViewModel(IActorViewModelFactory viewModelFactory)
        {
            Actors = new ObservableCollection<IActorViewModel>();
            AddCommand = new AddCommand(this, viewModelFactory);
            RemoveCommand = new RemoveCommand(this);
        }
    }
}
