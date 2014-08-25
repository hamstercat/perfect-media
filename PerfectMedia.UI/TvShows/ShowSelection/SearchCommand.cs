using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Busy;

namespace PerfectMedia.UI.TvShows.ShowSelection
{
    public class SearchCommand : AsyncCommand
    {
        public override event EventHandler CanExecuteChanged;

        private readonly ITvShowMetadataService _metadataService;
        private readonly ITvShowSelectionViewModel _tvShowSelectionViewModel;
        private readonly IBusyProvider _busyProvider;

        public SearchCommand(ITvShowMetadataService metadataService, ITvShowSelectionViewModel tvShowSelectionViewModel, IBusyProvider busyProvider)
        {
            _metadataService = metadataService;
            _tvShowSelectionViewModel = tvShowSelectionViewModel;
            _busyProvider = busyProvider;
            _tvShowSelectionViewModel.PropertyChanged += TvShowSelectionPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_tvShowSelectionViewModel.SearchTitle);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            using (_busyProvider.DoWork())
            {
                IEnumerable<Series> series = await _metadataService.FindSeries(_tvShowSelectionViewModel.SearchTitle);
                _tvShowSelectionViewModel.ReplaceSeries(series);
            }
        }

        private void TvShowSelectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var handler = CanExecuteChanged;
            if (e.PropertyName == "SearchTitle" && handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
