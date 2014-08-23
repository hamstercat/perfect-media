using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Shows;
using PerfectMedia.UI.Validation;
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

        [Rating]
        public double? Rating { get; set; }

        [RequiredCached]
        public ICachedPropertyViewModel<string> Title { get; private set; }

        [RequiredCached]
        public ICachedPropertyViewModel<int?> SeasonNumber { get; private set; }

        [RequiredCached]
        public ICachedPropertyViewModel<int?> EpisodeNumber { get; private set; }

        [Positive]
        public int? PlayCount { get; set; }

        [Positive]
        public int? DisplaySeason { get; set; }

        [Positive]
        public int? DisplayEpisode { get; set; }

        public string Plot { get; set; }
        public ImageViewModel ImagePath { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? LastPlayed { get; set; }
        public DashDelimitedCollectionViewModel<string> Credits { get; set; }
        public DashDelimitedCollectionViewModel<string> Directors { get; set; }
        public DateTime? AiredDate { get; set; }
        public double? EpisodeBookmarks { get; set; }

        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(Title.CachedValue))
                {
                    return System.IO.Path.GetFileName(Path);
                }
                if (SeasonNumber == null || EpisodeNumber == null)
                {
                    return Title.CachedValue;
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
            _lazyLoaded = false;

            Title = viewModelFactory.GetStringCachedProperty(path + "?title");
            Title.PropertyChanged += CachedPropertyChanged;
            SeasonNumber = viewModelFactory.GetIntCachedProperty(path + "?seasonNumber");
            SeasonNumber.PropertyChanged += CachedPropertyChanged;
            EpisodeNumber = viewModelFactory.GetIntCachedProperty(path + "?episodeNumber");
            EpisodeNumber.PropertyChanged += CachedPropertyChanged;
            Path = path;

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
                else
                {
                    RefreshFromMetadata(metadata);
                }
                return items;
            }
        }

        public async Task Save()
        {
            using (_busyProvider.DoWork())
            {
                Title.Save();
                SeasonNumber.Save();
                EpisodeNumber.Save();
                EpisodeMetadata metadata = CreateMetadata();
                await _metadataService.Save(Path, metadata);
            }
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
            Title.Save();
            Rating = metadata.Rating;
            SeasonNumber.Value = metadata.SeasonNumber;
            SeasonNumber.Save();
            EpisodeNumber.Value = metadata.EpisodeNumber;
            EpisodeNumber.Save();
            Plot = metadata.Plot;
            ImagePath.Path = null;
            ImagePath.Path = metadata.ImagePath;
            ImageUrl = metadata.ImageUrl;
            PlayCount = metadata.PlayCount;
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
                SeasonNumber = SeasonNumber.Value.Value,
                EpisodeNumber = EpisodeNumber.Value.Value,
                Plot = Plot,
                ImagePath = ImagePath.Path,
                ImageUrl = ImageUrl,
                PlayCount = PlayCount,
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
