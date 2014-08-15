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

        private double _rating;
        public double Rating
        {
            get
            {
                InitialLoadInformation();
                return _rating;
            }
            set
            {
                InitialLoadInformation();
                _rating = value;
            }
        }

        private string _plot;
        public string Plot
        {
            get
            {
                InitialLoadInformation();
                return _plot;
            }
            set
            {
                InitialLoadInformation();
                _plot = value;
            }
        }

        private readonly ImageViewModel _imagePath;
        public ImageViewModel ImagePath
        {
            get
            {
                InitialLoadInformation();
                return _imagePath;
            }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get
            {
                InitialLoadInformation();
                return _imageUrl;
            }
            set
            {
                InitialLoadInformation();
                _imageUrl = value;
            }
        }

        private int _playCount;
        public int PlayCount
        {
            get
            {
                InitialLoadInformation();
                return _playCount;
            }
            set
            {
                InitialLoadInformation();
                _playCount = value;
            }
        }

        private DateTime? _lastPlayed;
        public DateTime? LastPlayed
        {
            get
            {
                InitialLoadInformation();
                return _lastPlayed;
            }
            set
            {
                InitialLoadInformation();
                _lastPlayed = value;
            }
        }

        private DashDelimitedCollectionViewModel<string> _credits;
        public DashDelimitedCollectionViewModel<string> Credits
        {
            get
            {
                InitialLoadInformation();
                return _credits;
            }
            set
            {
                InitialLoadInformation();
                _credits = value;
            }
        }

        private DashDelimitedCollectionViewModel<string> _directors;
        public DashDelimitedCollectionViewModel<string> Directors
        {
            get
            {
                InitialLoadInformation();
                return _directors;
            }
            set
            {
                InitialLoadInformation();
                _directors = value;
            }
        }

        private DateTime? _airedDate;
        public DateTime? AiredDate
        {
            get
            {
                InitialLoadInformation();
                return _airedDate;
            }
            set
            {
                InitialLoadInformation();
                _airedDate = value;
            }
        }

        private int? _displaySeason;
        public int? DisplaySeason
        {
            get
            {
                InitialLoadInformation();
                return _displaySeason;
            }
            set
            {
                InitialLoadInformation();
                _displaySeason = value;
            }
        }

        private int? _displayEpisode;
        public int? DisplayEpisode
        {
            get
            {
                InitialLoadInformation();
                return _displayEpisode;
            }
            set
            {
                InitialLoadInformation();
                _displayEpisode = value;
            }
        }

        private double? _episodeBookmarks;
        public double? EpisodeBookmarks
        {
            get
            {
                InitialLoadInformation();
                return _episodeBookmarks;
            }
            set
            {
                InitialLoadInformation();
                _episodeBookmarks = value;
            }
        }
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

            // We don't want to trigger the InitialLoadInformation by setting the properties
            _credits = new DashDelimitedCollectionViewModel<string>(s => s);
            _directors = new DashDelimitedCollectionViewModel<string>(s => s);
            _imagePath = new ImageViewModel(fileSystemService, true);

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

        private void InitialLoadInformation()
        {
            if (!_lazyLoaded)
            {
                _lazyLoaded = true;
                // TODO: call asynchronously
                Refresh();
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
