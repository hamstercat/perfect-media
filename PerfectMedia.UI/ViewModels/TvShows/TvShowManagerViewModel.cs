﻿using PerfectMedia.Sources;
using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.ViewModels.TvShows
{
    public class TvShowManagerViewModel : BaseViewModel, ISourceProvider
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly ITvShowFileService _tvShowFileService;
        private readonly ITvShowMetadataService _metadataService;

        public SourceManagerViewModel Sources { get; private set; }
        public ObservableCollection<TvShowViewModel> TvShows { get; private set; }

        public TvShowManagerViewModel(ITvShowViewModelFactory viewModelFactory, ITvShowFileService tvShowFileService, ITvShowMetadataService metadataService)
        {
            _viewModelFactory = viewModelFactory;
            _tvShowFileService = tvShowFileService;
            _metadataService = metadataService;
            TvShows = new ObservableCollection<TvShowViewModel>();

            Sources = viewModelFactory.GetSourceManager(SourceType.TvShow);
            Sources.SpecificFolders.CollectionChanged += SourceFoldersCollectionChanged;
            Sources.Load();
        }

        private void SourceFoldersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddTvShows(e.NewItems.Cast<string>());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveTvShows(e.OldItems.Cast<string>());
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RemoveTvShows(e.OldItems.Cast<string>());
                    AddTvShows(e.NewItems.Cast<string>());
                    break;
                case NotifyCollectionChangedAction.Reset:
                    TvShows.Clear();
                    break;
                case NotifyCollectionChangedAction.Move:
                default:
                    break;
            }
        }

        private void AddTvShows(IEnumerable<string> tvShows)
        {
            foreach (string path in tvShows)
            {
                TvShowViewModel newTvShow = _viewModelFactory.GetTvShow(path);
                TvShows.Add(newTvShow);
            }
        }

        private void RemoveTvShows(IEnumerable<string> tvShows)
        {
            foreach (string path in tvShows)
            {
                TvShowViewModel tvShowToRemove = TvShows.First(show => show.Path == path);
                TvShows.Remove(tvShowToRemove);
            }
        }
    }
}
