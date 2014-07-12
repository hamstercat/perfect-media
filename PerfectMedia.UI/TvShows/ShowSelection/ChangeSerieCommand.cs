using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.TvShows.Shows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PerfectMedia.UI.TvShows.ShowSelection
{
    public class ChangeSerieCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly ITvShowMetadataService _metadataService;
        private readonly ITvShowMetadataViewModel _tvShowMetadata;
        private readonly ITvShowSelectionViewModel _selectionViewModel;
        private readonly string _path;

        public ChangeSerieCommand(ITvShowMetadataService metadataService, ITvShowMetadataViewModel tvShowMetadata, ITvShowSelectionViewModel selectionViewModel, string path)
        {
            _metadataService = metadataService;
            _tvShowMetadata = tvShowMetadata;
            _selectionViewModel = selectionViewModel;
            _selectionViewModel.PropertyChanged += SelectionViewModelPropertyChanged;
            _path = path;
        }

        public bool CanExecute(object parameter)
        {
            return _selectionViewModel.SelectedSerie != null;
        }

        public void Execute(object parameter)
        {
            SaveNewId();
            Update();
            _selectionViewModel.IsClosed = true;
        }

        private void SelectionViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedSerie" && CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }

        private void SaveNewId()
        {
            TvShowMetadata metadata = _metadataService.Get(_path);
            metadata.Id = _selectionViewModel.SelectedSerie.SeriesId;
            _metadataService.Save(_path, metadata);
        }

        private void Update()
        {
            _metadataService.DeleteImages(_path);
            _metadataService.Update(_path);
            _tvShowMetadata.Refresh();
        }
    }
}
