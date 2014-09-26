using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Selection
{
    public class SearchCommand<T> : AsyncCommand
    {
        public override event EventHandler CanExecuteChanged;

        private readonly ISearchableSelectionViewModel<T> _searchableSelectionViewModel;

        public SearchCommand(ISearchableSelectionViewModel<T> searchableSelectionViewModel)
        {
            _searchableSelectionViewModel = searchableSelectionViewModel;
            _searchableSelectionViewModel.PropertyChanged += SearchableSelectionPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_searchableSelectionViewModel.SearchTitle);
        }

        public override Task ExecuteAsync(object parameter)
        {
            return _searchableSelectionViewModel.Search();
        }

        private void SearchableSelectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            EventHandler handler = CanExecuteChanged;
            if (e.PropertyName == "SearchTitle" && handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}