using System;
using System.ComponentModel;
using System.Windows.Input;

namespace PerfectMedia.UI.Actors
{
    public class RemoveCommand : ICommand
    {
        private readonly IActorManagerViewModel _actorManager;

        public event EventHandler CanExecuteChanged;

        public RemoveCommand(IActorManagerViewModel actorManager)
        {
            _actorManager = actorManager;
            _actorManager.PropertyChanged += ActorManagerPropertyChanged;
        }

        public bool CanExecute(object parameter)
        {
            return _actorManager.SelectedActor != null;
        }

        public void Execute(object parameter)
        {
            _actorManager.Actors.Remove(_actorManager.SelectedActor);
        }

        private void ActorManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}