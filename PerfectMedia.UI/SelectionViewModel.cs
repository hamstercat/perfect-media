using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PropertyChanged;
using System.Threading.Tasks;

namespace PerfectMedia.UI
{
    [ImplementPropertyChanged]
    public class SelectionViewModel<T> : ICommand
        where T : class
    {
        public event EventHandler CanExecuteChanged;
        private readonly Func<T, Task> _save;

        private T _selectedItem;
        public T SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                if (CanExecuteChanged != null)
                    CanExecuteChanged(this, new EventArgs());
            }
        }

        public ObservableCollection<T> AvailableItems { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public SelectionViewModel(Func<T, Task> save)
            : this(default(T), save)
        { }

        public SelectionViewModel(T defaultItem, Func<T,Task> save)
        {
            _selectedItem = defaultItem;
            _save = save;
            AvailableItems = new ObservableCollection<T>();
            SaveCommand = this;
        }

        public bool CanExecute(object parameter)
        {
            return SelectedItem != null;
        }

        public async void Execute(object parameter)
        {
            await _save(SelectedItem);
        }
    }
}
