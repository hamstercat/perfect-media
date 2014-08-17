using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Input;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Progress;

namespace PerfectMedia.UI.Metadata
{
    public class UpdateAllMetadataCommand<T> : ICommand
        where T : IMetadataProvider
    {
        public event EventHandler CanExecuteChanged;
        private readonly ObservableCollection<T> _items;
        private readonly IProgressManagerViewModel _progressManager;
        private readonly IBusyProvider _busyProvider;

        public UpdateAllMetadataCommand(ObservableCollection<T> items, IProgressManagerViewModel progressManager, IBusyProvider busyProvider)
        {
            _items = items;
            _items.CollectionChanged += TvShowsCollectionChanged;
            _progressManager = progressManager;
            _busyProvider = busyProvider;
        }

        public bool CanExecute(object parameter)
        {
            return _items.Count != 0;
        }

        public async void Execute(object parameter)
        {
            using (_busyProvider.DoWork())
            {
                foreach (T item in _items)
                {
                    foreach (ProgressItem progressItem in await item.Update())
                    {
                        _progressManager.AddItem(progressItem);
                    }
                }
                await _progressManager.Start();
            }
        }

        private void TvShowsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (CanExecuteChanged != null)
            {
                Application.Current.Dispatcher.InvokeAsync(()=> CanExecuteChanged(this, new EventArgs()));
            }
        }
    }
}
