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
            return !string.IsNullOrEmpty(_tvShowSelectionViewModel.Title);
        }

        public void Execute(object parameter)
        {
            IEnumerable<Series> series = _metadataService.FindSeries(_tvShowSelectionViewModel.Title);
            _tvShowSelectionViewModel.Series.Clear();
            _tvShowSelectionViewModel.Series.AddRange(series);
        }

        private void TvShowSelectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Title" && CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
