using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace PerfectMedia.UI.Actors
{
    [ImplementPropertyChanged]
    public class ActorManagerViewModel : BaseViewModel, IActorManagerViewModel
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly string _path;
        private readonly Action _onPropertyChanged;

        public ObservableCollection<IActorViewModel> Actors { get; private set; }
        public IActorViewModel SelectedActor { get; set; }
        public ICommand AddCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }

        public ActorManagerViewModel(IActorViewModelFactory viewModelFactory, IFileSystemService fileSystemService, string path, Action onPropertyChanged)
        {
            _fileSystemService = fileSystemService;
            _path = path;
            _onPropertyChanged = onPropertyChanged;
            Actors = new ObservableCollection<IActorViewModel>();
            Actors.CollectionChanged += ActorsCollectionChanged;
            AddCommand = new AddCommand(this, viewModelFactory);
            RemoveCommand = new RemoveCommand(this);
        }

        public void Initialize(IEnumerable<IActorViewModel> actors)
        {
            Actors.Clear();
            foreach (IActorViewModel actor in actors)
            {
                Actors.Add(actor);
            }
        }

        public async Task Save()
        {
            foreach (var actor in Actors)
            {
                if (actor.Name.Value != actor.Role.OriginalValue)
                {
                    await MoveActorImagePath(actor);
                }
                actor.Name.Save();
                actor.Role.Save();
            }
        }

        private async Task MoveActorImagePath(IActorViewModel actor)
        {
            string newActorPath = ActorMetadata.GetActorThumbPath(_path, actor.Name.Value);
            await _fileSystemService.MoveFile(actor.ThumbPath.Path, newActorPath);
            actor.ThumbPath.Path = newActorPath;
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
