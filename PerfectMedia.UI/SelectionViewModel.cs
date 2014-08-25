using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PerfectMedia.UI.Busy;
using PropertyChanged;
using System.Threading.Tasks;

namespace PerfectMedia.UI
{
    [ImplementPropertyChanged]
    public class SelectionViewModel<T> : AsyncCommand
        where T : class
    {
        public override event EventHandler CanExecuteChanged;
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
                EventHandler handler = CanExecuteChanged;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
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

        public override bool CanExecute(object parameter)
        {
            return SelectedItem != null;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            using (_busyProvider.DoWork())
            {
                await _save(SelectedItem);
            }
        }
    }
}
