using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PropertyChanged;

namespace PerfectMedia.UI.Progress
{
    [ImplementPropertyChanged]
    public class ProgressManagerViewModel : BaseViewModel, IProgressManagerViewModel
    {
        private readonly IProgressIndicatorFactory _progressIndicatorFactory;
        private bool _collecting;

        public ObservableCollection<ProgressItem> Total { get; private set; }
        public ObservableCollection<ProgressItem> Completed { get; private set; }
        public ObservableCollection<ProgressItem> InError { get; private set; }

        public ProgressManagerViewModel(IProgressIndicatorFactory progressIndicatorFactory)
        {
            _progressIndicatorFactory = progressIndicatorFactory;

            Total = CreateProgressItemCollection("Total");
            Completed = CreateProgressItemCollection("Completed");
            InError = CreateProgressItemCollection("InError");
        }

        public void AddItem(ProgressItem item)
        {
            if (!_collecting)
            {
                _collecting = true;
                ClearItems();
                ShowProgressIndicator();
            }
            Total.Add(item);
        }

        public async Task Start()
        {
            _collecting = false;
            foreach (ProgressItem item in Total)
            {
                await ExecuteItem(item);
            }
        }

        private ObservableCollection<ProgressItem> CreateProgressItemCollection(string propertyName)
        {
            var collection = new ObservableCollection<ProgressItem>();
            collection.CollectionChanged += (s, e) => OnPropertyChanged(propertyName);
            return collection;
        }

        private void ClearItems()
        {
            Total.Clear();
            Completed.Clear();
            InError.Clear();
        }

        private void ShowProgressIndicator()
        {
            var progressIndicator = _progressIndicatorFactory.CreateProgressIndicator();
            progressIndicator.Show(this);
        }

        private async Task ExecuteItem(ProgressItem item)
        {
            await item.Execute();
            Completed.Add(item);
            if (!string.IsNullOrEmpty(item.Error))
            {
                InError.Add(item);
            }
        }
    }
}
