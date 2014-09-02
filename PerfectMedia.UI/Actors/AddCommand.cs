using System;
using System.Windows.Input;
using PerfectMedia.UI.Images;

namespace PerfectMedia.UI.Actors
{
    public class AddCommand : ICommand
    {
        private readonly IActorManagerViewModel _actorManager;
        private readonly IActorViewModelFactory _viewModelFactory;

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public AddCommand(IActorManagerViewModel actorManager, IActorViewModelFactory viewModelFactory)
        {
            _actorManager = actorManager;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            IImageViewModel image = _viewModelFactory.GetImage(true);
            ActorViewModel newActor = new ActorViewModel(image);
            _actorManager.Actors.Add(newActor);
        }
    }
}