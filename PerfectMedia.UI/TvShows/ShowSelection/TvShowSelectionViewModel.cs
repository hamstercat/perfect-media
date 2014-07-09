﻿using PerfectMedia.TvShows.Metadata;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.TvShows.ShowSelection
{
    [ImplementPropertyChanged]
    public class TvShowSelectionViewModel : BaseViewModel, ITvShowSelectionViewModel
    {
        public string Title { get; set; }
        public bool IsClosed { get; set; }
        public object OriginalContent { get; set; }
        public Series SelectedSerie { get; set; }
        public SmartObservableCollection<Series> Series { get; private set; }
        public ICommand SearchCommand { get; private set; }

        public TvShowSelectionViewModel(ITvShowMetadataService metadataService)
        {
            Series = new SmartObservableCollection<Series>();
            SearchCommand = new SearchCommand(metadataService, this);
        }
    }
}
