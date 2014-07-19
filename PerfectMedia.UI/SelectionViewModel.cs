using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI
{
    [ImplementPropertyChanged]
    public class SelectionViewModel<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action<T> _save;

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

        public SelectionViewModel(Action<T> save)
            : this(default(T), save)
        { }

        public SelectionViewModel(T defaultItem, Action<T> save)
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

        public void Execute(object parameter)
        {
            _save(SelectedItem);
        }
    }
}
