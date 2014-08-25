using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.Movies;
using PerfectMedia.UI.Busy;

namespace PerfectMedia.UI.Movies.Selection
{
    public class SearchCommand : AsyncCommand
    {
        public override event EventHandler CanExecuteChanged;

        private readonly IMovieMetadataService _metadataService;
        private readonly IMovieSelectionViewModel _movieSelectionViewModel;
        private readonly IBusyProvider _busyProvider;

        public SearchCommand(IMovieMetadataService metadataService, IMovieSelectionViewModel movieSelectionViewModel, IBusyProvider busyProvider)
        {
            _metadataService = metadataService;
            _movieSelectionViewModel = movieSelectionViewModel;
            _busyProvider = busyProvider;
            _movieSelectionViewModel.PropertyChanged += MovieSelectionPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_movieSelectionViewModel.SearchTitle);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            using (_busyProvider.DoWork())
            {
                IEnumerable<Movie> series = await _metadataService.FindMovies(_movieSelectionViewModel.SearchTitle);
                _movieSelectionViewModel.ReplaceMovies(series);
            }
        }

        private void MovieSelectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            EventHandler handler = CanExecuteChanged;
            if (e.PropertyName == "SearchTitle" && handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
