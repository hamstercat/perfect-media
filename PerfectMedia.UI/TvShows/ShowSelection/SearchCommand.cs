using PerfectMedia.TvShows.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PerfectMedia.UI.TvShows.ShowSelection
{
    public class SearchCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly ITvShowMetadataService _metadataService;
        private readonly ITvShowSelectionViewModel _tvShowSelectionViewModel;

        public SearchCommand(ITvShowMetadataService metadataService, ITvShowSelectionViewModel tvShowSelectionViewModel)
        {
            _metadataService = metadataService;
            _tvShowSelectionViewModel = tvShowSelectionViewModel;
            _tvShowSelectionViewModel.PropertyChanged += TvShowSelectionPropertyChanged;
        }

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_tvShowSelectionViewModel.SearchTitle);
        }

        public void Execute(object parameter)
        {
            IEnumerable<Series> series = _metadataService.FindSeries(_tvShowSelectionViewModel.SearchTitle);
            _tvShowSelectionViewModel.ReplaceSeries(series);
        }

        private void TvShowSelectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SearchTitle" && CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
