using PerfectMedia.FileInformation;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Shows;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.TvShows.Episodes
{
    [ImplementPropertyChanged]
    public class EpisodeViewModel : IEpisodeViewModel, ITreeViewItemViewModel, IMetadataProvider
    {
        private readonly IEpisodeMetadataService _metadataService;
        private readonly ITvShowMetadataViewModel _tvShowMetadata;
        private bool _lazyLoaded;

        #region Metadata
        private string _title;
        public string Title
        {
            get
            {
                InitialLoadInformation();
                return _title;
            }
            set
            {
                InitialLoadInformation();
                _title = value;
            }
        }

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

        private int _seasonNumber;
        public int SeasonNumber
        {
            get
            {
                InitialLoadInformation();
                return _seasonNumber;
            }
            set
            {
                InitialLoadInformation();
                _seasonNumber = value;
            }
        }

        private int _episodeNumber;
        public int EpisodeNumber
        {
            get
            {
                InitialLoadInformation();
                return _episodeNumber;
            }
            set
            {
                InitialLoadInformation();
                _episodeNumber = value;
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

        private ImageViewModel _imagePath;
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
                if (string.IsNullOrEmpty(Title))
                {
                    return System.IO.Path.GetFileName(Path);
                }
                return string.Format("{0}x{1:d2}: {2}",
                    SeasonNumber,
                    EpisodeNumber,
                    Title);
            }
        }

        public string Path { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public EpisodeViewModel(IEpisodeMetadataService metadataService, ITvShowMetadataViewModel tvShowMetadata, IProgressManagerViewModel progressManager, IFileSystemService fileSystemService, string path)
        {
            _metadataService = metadataService;
            _tvShowMetadata = tvShowMetadata;
            Path = path;
            _lazyLoaded = false;

            // We don't want to trigger the InitialLoadInformation by setting the properties
            _credits = new DashDelimitedCollectionViewModel<string>(s => s);
            _directors = new DashDelimitedCollectionViewModel<string>(s => s);
            _imagePath = new ImageViewModel(fileSystemService);

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager);
            SaveCommand = new SaveMetadataCommand(this);
        }

        public void Refresh()
        {
            EpisodeMetadata metadata = _metadataService.Get(Path);
            RefreshFromMetadata(metadata);
        }

        public IEnumerable<ProgressItem> Update()
        {
            foreach (ProgressItem item in _tvShowMetadata.Update())
            {
                yield return item;
            }

            EpisodeMetadata metadata = _metadataService.Get(Path);
            if (metadata.FileInformation == null)
            {
                Lazy<string> displayName = new Lazy<string>(ToString);
                yield return new ProgressItem(displayName, UpdateInternal);
            }
        }

        public void Save()
        {
            EpisodeMetadata metadata = CreateMetadata();
            _metadataService.Save(Path, metadata);
        }

        public override string ToString()
        {
            return DisplayName;
        }

        private void InitialLoadInformation()
        {
            if (!_lazyLoaded)
            {
                _lazyLoaded = true;
                Refresh();
            }
        }

        private void RefreshFromMetadata(EpisodeMetadata metadata)
        {
            Title = metadata.Title;
            Rating = metadata.Rating;
            SeasonNumber = metadata.SeasonNumber;
            EpisodeNumber = metadata.EpisodeNumber;
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

            Credits.Collection.Clear();
            foreach (string credit in metadata.Credits)
            {
                Credits.Collection.Add(credit);
            }

            Directors.Collection.Clear();
            foreach (string director in metadata.Director)
            {
                Directors.Collection.Add(director);
            }
        }

        private EpisodeMetadata CreateMetadata()
        {
            return new EpisodeMetadata
            {
                Title = Title,
                Rating = Rating,
                SeasonNumber = SeasonNumber,
                EpisodeNumber = EpisodeNumber,
                Plot = Plot,
                ImagePath = ImagePath.Path,
                ImageUrl = ImageUrl,
                Playcount = PlayCount,
                LastPlayed = LastPlayed,
                Credits = new List<string>(Credits.Collection),
                Director = new List<string>(Directors.Collection),
                AiredDate = AiredDate,
                DisplaySeason = DisplaySeason,
                DisplayEpisode = DisplayEpisode,
                EpisodeBookmarks = EpisodeBookmarks
            };
        }

        private Task UpdateInternal()
        {
            return Task.Run(() =>
            {
                _metadataService.Update(Path, _tvShowMetadata.Id);
                Refresh();
            });
        }
    }
}
