using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Selection
{
    public class SaveCommand<T> : AsyncCommand
        where T : class
    {
        public override event EventHandler CanExecuteChanged;

        private readonly ISelectionViewModel<T> _selectionViewModel;

        public SaveCommand(ISelectionViewModel<T> selectionViewModel)
        {
            _selectionViewModel = selectionViewModel;
            _selectionViewModel.PropertyChanged += SelectionViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _selectionViewModel.SelectedItem != null;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _selectionViewModel.SaveSelectedItem();
        }

        private void SelectionViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            EventHandler handler = CanExecuteChanged;
            if (e.PropertyName == "SelectedItem" && handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
