using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.UI.Busy;
using PropertyChanged;

namespace PerfectMedia.UI.Selection
{
    [ImplementPropertyChanged]
    public abstract class SelectionViewModel<T> : BaseViewModel, ISelectionViewModel<T>
        where T : class
    {
        private readonly IBusyProvider _busyProvider;

        public T SelectedItem { get; set; }
        public bool IsClosed { get; set; }
        public object OriginalContent { get; set; }
        public ObservableCollection<T> AvailableItems { get; private set; }
        public ICommand SaveCommand { get; private set; }

        protected SelectionViewModel(IBusyProvider busyProvider)
            : this(busyProvider, default(T))
        {
            _busyProvider = busyProvider;
        }

        protected SelectionViewModel(IBusyProvider busyProvider, T defaultItem)
        {
            SelectedItem = defaultItem;
            _busyProvider = busyProvider;
            AvailableItems = new ObservableCollection<T>();
            SaveCommand = new SaveCommand<T>(this);
        }

        public async Task SaveSelectedItem()
        {
            using (_busyProvider.DoWork())
            {
                await SaveInternal(SelectedItem);
                IsClosed = true;
            }
        }

        public void SetAvailableItems(IEnumerable<T> items)
        {
            AvailableItems.Clear();
            foreach (T item in items)
            {
                AvailableItems.Add(item);
            }
        }

        protected abstract Task SaveInternal(T selectedItem);
    }
}
