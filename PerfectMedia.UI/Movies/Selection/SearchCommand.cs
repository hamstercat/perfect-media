using PerfectMedia.Movies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PerfectMedia.UI.Movies.Selection
{
    public class SearchCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly IMovieMetadataService _metadataService;
        private readonly IMovieSelectionViewModel _movieSelectionViewModel;

        public SearchCommand(IMovieMetadataService metadataService, IMovieSelectionViewModel movieSelectionViewModel)
        {
            _metadataService = metadataService;
            _movieSelectionViewModel = movieSelectionViewModel;
            _movieSelectionViewModel.PropertyChanged += MovieSelectionPropertyChanged;
        }

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_movieSelectionViewModel.SearchTitle);
        }

        public void Execute(object parameter)
        {
            IEnumerable<Movie> series = _metadataService.FindMovies(_movieSelectionViewModel.SearchTitle);
            _movieSelectionViewModel.ReplaceMovies(series);
        }

        private void MovieSelectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SearchTitle" && CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
