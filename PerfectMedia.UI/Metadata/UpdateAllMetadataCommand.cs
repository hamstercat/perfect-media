using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Shows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PerfectMedia.UI.Metadata
{
    public class UpdateAllMetadataCommand<T> : ICommand
        where T : IMetadataProvider
    {
        public event EventHandler CanExecuteChanged;
        private readonly ObservableCollection<T> _items;
        private readonly IProgressManagerViewModel _progressManager;

        public UpdateAllMetadataCommand(ObservableCollection<T> items, IProgressManagerViewModel progressManager)
        {
            _items = items;
            _items.CollectionChanged += TvShowsCollectionChanged;
            _progressManager = progressManager;
        }

        public bool CanExecute(object parameter)
        {
            return _items.Count != 0;
        }

        public void Execute(object parameter)
        {
            foreach (IMetadataProvider item in _items)
            {
                foreach (ProgressItem progressItem in item.Update())
                {
                    _progressManager.AddItem(progressItem);
                }
            }
            _progressManager.Start();
        }

        private void TvShowsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (CanExecuteChanged != null)
            {
                App.Current.Dispatcher.InvokeAsync(()=>
                {
                    CanExecuteChanged(this, new EventArgs());
                });
            }
        }
    }
}
