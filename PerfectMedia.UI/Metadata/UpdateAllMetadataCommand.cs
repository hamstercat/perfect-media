using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Progress;

namespace PerfectMedia.UI.Metadata
{
    public class UpdateAllMetadataCommand<T> : AsyncCommand
        where T : IMetadataProvider
    {
        public override event EventHandler CanExecuteChanged;
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

        public override bool CanExecute(object parameter)
        {
            return _items.Count != 0;
        }

        public override async Task ExecuteAsync(object parameter)
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
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                Application.Current.Dispatcher.InvokeAsync(()=> handler(this, new EventArgs()));
            }
        }
    }
}
