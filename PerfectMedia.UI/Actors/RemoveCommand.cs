using System;
using System.ComponentModel;
using System.Windows.Input;

namespace PerfectMedia.UI.Actors
{
    public class RemoveCommand : ICommand
    {
        private readonly IActorManagerViewModel _actorManager;

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public RemoveCommand(IActorManagerViewModel actorManager)
        {
            _actorManager = actorManager;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var actor = (IActorViewModel)parameter;
            _actorManager.Actors.Remove(actor);
        }
    }
}