using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.TvShows.Metadata;
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

        // Do nothing with it, no children to show
        public bool IsExpanded { get; set; }

        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(Title.Value))
                {
                    return System.IO.Path.GetFileName(Path);
                }
                return string.Format("{0}x{1:d2}: {2}",
                    SeasonNumber.Value,
                    EpisodeNumber.Value,
                    Title.Value);
            }
        }

        public string Path { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public EpisodeViewModel(ITvShowViewModelFactory viewModelFactory, IEpisodeMetadataService metadataService, ITvShowMetadataViewModel tvShowMetadata, IProgressManagerViewModel progressManager, IFileSystemService fileSystemService, string path)
        {
            _metadataService = metadataService;
            _tvShowMetadata = tvShowMetadata;
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
            ImagePath = new ImageViewModel(fileSystemService, true);

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager);
            SaveCommand = new SaveMetadataCommand(this);
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
            EpisodeMetadata metadata = await _metadataService.Get(Path);
            RefreshFromMetadata(metadata);
        }

        public async Task<IEnumerable<ProgressItem>> Update()
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
                items.Add(new ProgressItem(displayName, UpdateInternal));
            }
            return items;
        }

        public Task Save()
        {
            return Task.Run(() =>
            {
                EpisodeMetadata metadata = CreateMetadata();
                _metadataService.Save(Path, metadata);
            });
        }

        public async Task Load()
        {
            if (!_lazyLoaded)
            {
                _lazyLoaded = true;
                await Refresh();
            }
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
            await _metadataService.Update(Path, _tvShowMetadata.Id);
            await Refresh();
        }
    }
}
