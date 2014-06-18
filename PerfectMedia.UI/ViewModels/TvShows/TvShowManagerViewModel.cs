﻿using PerfectMedia.Metadata;
using PerfectMedia.Sources;
using PerfectMedia.TvShows;
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
        private readonly ITvShowService _tvShowService;
        private readonly ITvShowLocalMetadataService _tvShowLocalMetadataService;
        private readonly ITvShowMetadataService _metadataService;

        public SourceManagerViewModel Sources { get; private set; }
        public ObservableCollection<TvShowViewModel> TvShows { get; private set; }

        public TvShowManagerViewModel()
            : this(ServiceLocator.Get<ITvShowService>(),
                   ServiceLocator.Get<ITvShowLocalMetadataService>(),
                   ServiceLocator.Get<ITvShowMetadataService>(),
                   ServiceLocator.Get<ISourceRepository>())
        { }

        public TvShowManagerViewModel(ITvShowService tvShowService, ITvShowLocalMetadataService tvShowLocalMetadataService, ITvShowMetadataService metadataService, ISourceRepository sourceRepository)
        {
            _tvShowService = tvShowService;
            _tvShowLocalMetadataService = tvShowLocalMetadataService;
            _metadataService = metadataService;
            TvShows = new ObservableCollection<TvShowViewModel>();

            Sources = new SourceManagerViewModel(sourceRepository, SourceType.TvShow);
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
                TvShowViewModel newTvShow = new TvShowViewModel(_tvShowService, _tvShowLocalMetadataService, _metadataService, path);
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
