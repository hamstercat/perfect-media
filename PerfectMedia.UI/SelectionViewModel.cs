using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PerfectMedia.UI.Busy;
using PropertyChanged;
using System.Threading.Tasks;

namespace PerfectMedia.UI
{
    [ImplementPropertyChanged]
    public class SelectionViewModel<T> : ICommand
        where T : class
    {
        public event EventHandler CanExecuteChanged;
        private readonly IBusyProvider _busyProvider;
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

        public SelectionViewModel(IBusyProvider busyProvider, Func<T, Task> save)
            : this(busyProvider, default(T), save)
        { }

        public SelectionViewModel(IBusyProvider busyProvider, T defaultItem, Func<T, Task> save)
        {
            _busyProvider = busyProvider;
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
            using (_busyProvider.DoWork())
            {
                await _save(SelectedItem);
            }
        }
    }
}
