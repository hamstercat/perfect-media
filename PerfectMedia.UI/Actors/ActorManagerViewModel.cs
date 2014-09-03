using System;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using PerfectMedia.UI.Validations;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace PerfectMedia.UI.Actors
{
    [ImplementPropertyChanged]
    public class ActorManagerViewModel : BaseViewModel, IActorManagerViewModel
    {
        private readonly Action _onPropertyChanged;

        public ObservableCollection<IActorViewModel> Actors { get; private set; }
        public IActorViewModel SelectedActor { get; set; }

        public ICommand AddCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }

        public ActorManagerViewModel(IActorViewModelFactory viewModelFactory, Action onPropertyChanged)
        {
            _onPropertyChanged = onPropertyChanged;
            Actors = new ObservableCollection<IActorViewModel>();
            Actors.CollectionChanged += ActorsCollectionChanged;
            AddCommand = new AddCommand(this, viewModelFactory);
            RemoveCommand = new RemoveCommand(this);
        }

        private void ActorsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            _onPropertyChanged();
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (IActorViewModel actor in e.NewItems.Cast<IActorViewModel>())
                {
                    actor.PropertyChanged += (s, ea) => _onPropertyChanged();
                }
            }
        }
    }
}
