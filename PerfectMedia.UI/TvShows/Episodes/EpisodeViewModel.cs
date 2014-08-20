﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Shows;
using PropertyChanged;

namespace PerfectMedia.UI.TvShows.Episodes
{
    [ImplementPropertyChanged]
    public class EpisodeViewModel : BaseViewModel, IEpisodeViewModel, ITreeViewItemViewModel, IMetadataProvider
    {
        private readonly IEpisodeMetadataService _metadataService;
        private readonly ITvShowMetadataViewModel _tvShowMetadata;
        private readonly IBusyProvider _busyProvider;
        private bool _lazyLoaded;

        #region Metadata
        public ICachedPropertyViewModel<string> Title { get; private set; }
        public ICachedPropertyViewModel<int> SeasonNumber { get; private set; }
        public ICachedPropertyViewModel<int> EpisodeNumber { get; private set; }

        public double Rating { get; set; }
        public string Plot { get; set; }
        public ImageViewModel ImagePath { get; set; }
        public string ImageUrl { get; set; }
        public int PlayCount { get; set; }
        public DateTime? LastPlayed { get; set; }
        public DashDelimitedCollectionViewModel<string> Credits { get; set; }
        public DashDelimitedCollectionViewModel<string> Directors { get; set; }
        public DateTime? AiredDate { get; set; }
        public int? DisplaySeason { get; set; }
        public int? DisplayEpisode { get; set; }
        public double? EpisodeBookmarks { get; set; }
        #endregion

        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(Title.CachedValue))
                {
                    return System.IO.Path.GetFileName(Path);
                }
                return string.Format("{0}x{1:d2}: {2}",
                    SeasonNumber.CachedValue,
                    EpisodeNumber.CachedValue,
                    Title.CachedValue);
            }
        }

        public string Path { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public EpisodeViewModel(ITvShowViewModelFactory viewModelFactory,
            IEpisodeMetadataService metadataService,
            ITvShowMetadataViewModel tvShowMetadata,
            IProgressManagerViewModel progressManager,
            IFileSystemService fileSystemService,
            IBusyProvider busyProvider,
            string path)
        {
            _metadataService = metadataService;
            _tvShowMetadata = tvShowMetadata;
            _busyProvider = busyProvider;
            Path = path;
            _lazyLoaded = false;

            Title = viewModelFactory.GetCachedProperty(path + "?title", s => s, s => s);
            Title.PropertyChanged += CachedPropertyChanged;
            SeasonNumber = viewModelFactory.GetCachedProperty(path + "?seasonNumber", i => i.ToString(CultureInfo.InvariantCulture), int.Parse);
            SeasonNumber.PropertyChanged += CachedPropertyChanged;
            EpisodeNumber = viewModelFactory.GetCachedProperty(path + "?episodeNumber", i => i.ToString(CultureInfo.InvariantCulture), int.Parse);
            EpisodeNumber.PropertyChanged += CachedPropertyChanged;

            Credits = new DashDelimitedCollectionViewModel<string>(s => s);
            Directors = new DashDelimitedCollectionViewModel<string>(s => s);
            ImagePath = new ImageViewModel(fileSystemService, busyProvider, true);

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager, busyProvider);
            SaveCommand = new SaveMetadataCommand(this);
            DeleteCommand = new DeleteMetadataCommand(this);
        }

        private void CachedPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("Title");
            OnPropertyChanged("SeasonNumber");
            OnPropertyChanged("EpisodeNumber");
            OnPropertyChanged("DisplayName");
        }

        public async Task Refresh()
        {
            using (_busyProvider.DoWork())
            {
                EpisodeMetadata metadata = await _metadataService.Get(Path);
                RefreshFromMetadata(metadata);
            }
        }

        public async Task<IEnumerable<ProgressItem>> Update()
        {
            using (_busyProvider.DoWork())
            {
                List<ProgressItem> items = new List<ProgressItem>();
                foreach (ProgressItem item in await _tvShowMetadata.Update())
                {
                    items.Add(item);
                }

                EpisodeMetadata metadata = await _metadataService.Get(Path);
                if (metadata.FileInformation == null)
                {
                    Lazy<string> displayName = new Lazy<string>(() => DisplayName);
                    items.Add(new ProgressItem(Path, displayName, UpdateInternal));
                }
                else if(string.IsNullOrEmpty(Title.CachedValue))
                {
                    // Add to cache
                    await Refresh();
                }
                return items;
            }
        }

        public Task Save()
        {
            return Task.Run(() =>
            {
                using (_busyProvider.DoWork())
                {
                    Title.Save();
                    SeasonNumber.Save();
                    EpisodeNumber.Save();
                    EpisodeMetadata metadata = CreateMetadata();
                    _metadataService.Save(Path, metadata);
                }
            });
        }

        public async Task Delete()
        {
            using (_busyProvider.DoWork())
            {
                await _metadataService.Delete(Path);
                await Refresh();
            }
        }

        public async Task Load()
        {
            if (!_lazyLoaded)
            {
                _lazyLoaded = true;
                await Refresh();
            }
        }

        public Task LoadChildren()
        {
            // Nothing to do
            return Task.Delay(0);
        }

        private void RefreshFromMetadata(EpisodeMetadata metadata)
        {
            Title.Value = metadata.Title;
            Rating = metadata.Rating;
            SeasonNumber.Value = metadata.SeasonNumber;
            EpisodeNumber.Value = metadata.EpisodeNumber;
            Plot = metadata.Plot;
            ImagePath.Path = null;
            ImagePath.Path = metadata.ImagePath;
            ImageUrl = metadata.ImageUrl;
            PlayCount = metadata.Playcount;
            LastPlayed = metadata.LastPlayed;
            AiredDate = metadata.AiredDate;
            DisplaySeason = metadata.DisplaySeason;
            DisplayEpisode = metadata.DisplayEpisode;
            EpisodeBookmarks = metadata.EpisodeBookmarks;

            Credits.ReplaceWith(metadata.Credits);
            Directors.ReplaceWith(metadata.Director);
        }

        private EpisodeMetadata CreateMetadata()
        {
            return new EpisodeMetadata
            {
                Title = Title.Value,
                Rating = Rating,
                SeasonNumber = SeasonNumber.Value,
                EpisodeNumber = EpisodeNumber.Value,
                Plot = Plot,
                ImagePath = ImagePath.Path,
                ImageUrl = ImageUrl,
                Playcount = PlayCount,
                LastPlayed = LastPlayed,
                Credits = Credits.Collection.ToList(),
                Director = Directors.Collection.ToList(),
                AiredDate = AiredDate,
                DisplaySeason = DisplaySeason,
                DisplayEpisode = DisplayEpisode,
                EpisodeBookmarks = EpisodeBookmarks
            };
        }

        private async Task UpdateInternal()
        {
            using (_busyProvider.DoWork())
            {
                await _metadataService.Update(Path, _tvShowMetadata.Id);
                await Refresh();
            }
        }
    }
}
