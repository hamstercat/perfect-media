using PerfectMedia.FileInformation;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PerfectMedia.UI.ViewModels.TvShows
{
    public class EpisodeViewModel : BaseViewModel, ITreeViewItemViewModel, IMetadataProvider
    {
        private readonly IEpisodeMetadataService _metadataService;
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
                _title = value;
                OnPropertyChanged("Title");
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
                _rating = value;
                OnPropertyChanged("Rating");
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
                _seasonNumber = value;
                OnPropertyChanged("SeasonNumber");
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
                _episodeNumber = value;
                OnPropertyChanged("EpisodeNumber");
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
                _plot = value;
                OnPropertyChanged("Plot");
            }
        }

        private string _imagePath;
        public string ImagePath
        {
            get
            {
                InitialLoadInformation();
                return _imagePath;
            }
            set
            {
                _imagePath = value;
                OnPropertyChanged("ImagePath");
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
                _imageUrl = value;
                OnPropertyChanged("ImageUrl");
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
                _playCount = value;
                OnPropertyChanged("PlayCount");
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
                _lastPlayed = value;
                OnPropertyChanged("LastPlayed");
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
                _credits = value;
                OnPropertyChanged("Credits");
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
                _directors = value;
                OnPropertyChanged("Directors");
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
                _airedDate = value;
                OnPropertyChanged("AiredDate");
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
                _displaySeason = value;
                OnPropertyChanged("DisplaySeason");
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
                _displayEpisode = value;
                OnPropertyChanged("DisplayEpisode");
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
                _episodeBookmarks = value;
                OnPropertyChanged("EpisodeBookmarks");
            }
        }
        #endregion

        private string _error;
        public string Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
                OnPropertyChanged("Error");
            }
        }
        
        // Do nothing with it, no children to show
        public bool IsExpanded { get; set; }

        public string Path { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public EpisodeViewModel(IEpisodeMetadataService metadataService, string path)
        {
            _metadataService = metadataService;
            Path = path;
            _lazyLoaded = false;

            Credits = new DashDelimitedCollectionViewModel<string>(s => s);
            Directors = new DashDelimitedCollectionViewModel<string>(s => s);

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this);
            SaveCommand = new SaveMetadataCommand(this);
        }

        public void Refresh()
        {
            Error = null;
            EpisodeMetadata metadata = _metadataService.Get(Path);
            RefreshFromMetadata(metadata);
        }

        public void Update()
        {
            Error = null;
            EpisodeMetadata metadata = _metadataService.Get(Path);
            try
            {
                if (metadata.FileInformation == null)
                {
                    _metadataService.Update(Path);
                }
                Refresh();
            }
            catch (UnknownCodecException ex)
            {
                // TODO: do something else than showing the message error
                Error = ex.Message;
            }
        }

        public void Save()
        {
            Error = null;
            EpisodeMetadata metadata = CreateMetadata();
            _metadataService.Save(Path, metadata);
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
            ImagePath = metadata.ImagePath;
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
                ImagePath = ImagePath,
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
    }
}
