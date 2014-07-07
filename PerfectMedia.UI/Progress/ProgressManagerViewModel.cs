using PerfectMedia.FileInformation;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Progress
{
    [ImplementPropertyChanged]
    public class ProgressManagerViewModel : IProgressManagerViewModel
    {
        private readonly IProgressIndicatorFactory _progressIndicatorFactory;
        private readonly ObservableCollection<ProgressItem> _total;
        private readonly ObservableCollection<ProgressItem> _completed;
        private readonly ObservableCollection<ProgressItem> _inError;
        private bool _collecting;

        public int TotalNumberOfItems { get; private set; }
        public int NumberOfCompletedItems { get; private set; }
        public int NumberOfItemsInError { get; private set; }
        public INotifyCollectionChanged InError
        {
            get
            {
                return _inError;
            }
        }

        public ProgressManagerViewModel(IProgressIndicatorFactory progressIndicatorFactory)
        {
            _progressIndicatorFactory = progressIndicatorFactory;

            _total = new ObservableCollection<ProgressItem>();
            _completed = new ObservableCollection<ProgressItem>();
            _inError = new ObservableCollection<ProgressItem>();

            _total.CollectionChanged += CollectionChanged;
            _completed.CollectionChanged += CollectionChanged;
            _inError.CollectionChanged += CollectionChanged;
        }

        public void AddItem(ProgressItem item)
        {
            if (!_collecting)
            {
                _collecting = true;
                ClearItems();
                ShowProgressIndicator();
            }
            _total.Add(item);
        }

        public async void Start()
        {
            _collecting = false;
            foreach (ProgressItem item in _total)
            {
                await ExecuteItem(item);
            }
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            TotalNumberOfItems = _total.Count;
            NumberOfCompletedItems = _completed.Count;
            NumberOfItemsInError = _inError.Count;
        }

        private void ClearItems()
        {
            _total.Clear();
            _completed.Clear();
            _inError.Clear();
        }

        private void ShowProgressIndicator()
        {
            var progressIndicator = _progressIndicatorFactory.CreateProgressIndicator();
            progressIndicator.Show(this);
        }

        private async Task ExecuteItem(ProgressItem item)
        {
            await item.Execute();
            _completed.Add(item);
            if (!string.IsNullOrEmpty(item.Error))
            {
                _inError.Add(item);
            }
        }
    }
}
