﻿using PerfectMedia.TvShows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.ViewModels.TvShows
{
    public class SeasonViewModel : BaseViewModel, ITreeViewItemViewModel
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly ITvShowFileService _tvShowFileService;
        private readonly string _tvShowPath;

        private bool _imagesLoaded;
        private bool _episodeLoaded;

        private bool _isExpanded;
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                _isExpanded = value;
                if (!_episodeLoaded && _isExpanded)
                {
                    LoadEpisodes();
                }
                OnPropertyChanged("IsExpanded");
            }
        }

        private string _posterUrl;
        public string PosterUrl
        {
            get
            {
                LoadImages();
                return _posterUrl;
            }
            set
            {
                _posterUrl = value;
                OnPropertyChanged("PosterUrl");
            }
        }

        private string _bannerUrl;
        public string BannerUrl
        {
            get
            {
                LoadImages();
                return _bannerUrl;
            }
            set
            {
                _bannerUrl = value;
                OnPropertyChanged("BannerUrl");
            }
        }

        public string Path { get; private set; }
        public ObservableCollection<EpisodeViewModel> Episodes { get; private set; }

        public SeasonViewModel(ITvShowViewModelFactory viewModelFactory, ITvShowFileService tvShowFileService, string tvShowPath, string path)
        {
            _viewModelFactory = viewModelFactory;
            _tvShowFileService = tvShowFileService;
            _tvShowPath = tvShowPath;
            Path = path;

            // We need to set a "dummy" item in the collection for an arrow to appear in the TreeView since we're lazy-loading the items under it
            _imagesLoaded = false;
            _episodeLoaded = false;
            Episodes = new ObservableCollection<EpisodeViewModel> { _viewModelFactory.GetEpisode("dummy") };
        }

        private void LoadEpisodes()
        {
            // Remove the dummy object
            Episodes.Clear();

            IEnumerable<Episode> episodes = _tvShowFileService.GetEpisodes(Path);
            foreach (Episode episode in episodes)
            {
                EpisodeViewModel episodeViewModel = _viewModelFactory.GetEpisode(episode.Path);
                Episodes.Add(episodeViewModel);
            }
            _episodeLoaded = true;
        }

        private void LoadImages()
        {
            if (!_imagesLoaded)
            {
                Season season = _tvShowFileService.GetSeason(_tvShowPath, Path);
                _imagesLoaded = true;
                PosterUrl = season.PosterUrl;
                BannerUrl = season.BannerUrl;
            }
        }
    }
}
