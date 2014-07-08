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
        private bool _collecting;

        public SmartObservableCollection<ProgressItem> Total { get; private set; }
        public SmartObservableCollection<ProgressItem> Completed { get; private set; }
        public SmartObservableCollection<ProgressItem> InError { get; private set; }

        public ProgressManagerViewModel(IProgressIndicatorFactory progressIndicatorFactory)
        {
            _progressIndicatorFactory = progressIndicatorFactory;

            Total = new SmartObservableCollection<ProgressItem>();
            Completed = new SmartObservableCollection<ProgressItem>();
            InError = new SmartObservableCollection<ProgressItem>();
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

        public async void Start()
        {
            _collecting = false;
            foreach (ProgressItem item in Total)
            {
                await ExecuteItem(item);
            }
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
