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
    public class EpisodeViewModel : BaseViewModel, IMetadataProvider
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

        private string _image;
        public string Image
        {
            get
            {
                InitialLoadInformation();
                return _image;
            }
            set
            {
                _image = value;
                OnPropertyChanged("Image");
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

        private string _credits;
        public string Credits
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

        private string _director;
        public string Director
        {
            get
            {
                InitialLoadInformation();
                return _director;
            }
            set
            {
                _director = value;
                OnPropertyChanged("Director");
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

        private DateTime? _premieredDate;
        public DateTime? PremieredDate
        {
            get
            {
                InitialLoadInformation();
                return _premieredDate;
            }
            set
            {
                _premieredDate = value;
                OnPropertyChanged("PremieredDate");
            }
        }

        private string _studio;
        public string Studio
        {
            get
            {
                InitialLoadInformation();
                return _studio;
            }
            set
            {
                _studio = value;
                OnPropertyChanged("Studio");
            }
        }

        private string _mpaaRating;
        public string MpaaRating
        {
            get
            {
                InitialLoadInformation();
                return _mpaaRating;
            }
            set
            {
                _mpaaRating = value;
                OnPropertyChanged("MpaaRating");
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

        private DashDelimitedCollectionViewModel<int> _episodeBookmarks;
        public DashDelimitedCollectionViewModel<int> EpisodeBookmarks
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

        private ObservableCollection<ActorViewModel> _actors;
        public ObservableCollection<ActorViewModel> Actors
        {
            get
            {
                InitialLoadInformation();
                return _actors;
            }
            set
            {
                _actors = value;
                OnPropertyChanged("Actors");
            }
        }
        #endregion

        public string Path { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public EpisodeViewModel(IEpisodeMetadataService metadataService, string path)
        {
            _metadataService = metadataService;
            Path = path;
            _lazyLoaded = false;

            EpisodeBookmarks = new DashDelimitedCollectionViewModel<int>(int.Parse);
            Actors = new ObservableCollection<ActorViewModel>();

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this);
            SaveCommand = new SaveMetadataCommand(this);
        }

        public void Refresh()
        {
            EpisodeMetadata metadata = _metadataService.Get(Path);
            RefreshFromMetadata(metadata);
        }

        public void Update()
        {
            EpisodeMetadata metadata = _metadataService.Get(Path);
            if (metadata.FileInformation == null)
            {
                _metadataService.Update(Path);
            }
            Refresh();
        }

        public void Save()
        {
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
            Image = metadata.ImagePath;
            PlayCount = metadata.Playcount;
            LastPlayed = metadata.LastPlayed;
            Credits = metadata.Credits;
            Director = metadata.Director;
            AiredDate = metadata.AiredDate;
            PremieredDate = metadata.PremieredDate;
            Studio = metadata.Studio;
            MpaaRating = metadata.MpaaRating;
            DisplaySeason = metadata.DisplaySeason;
            DisplayEpisode = metadata.DisplayEpisode;

            EpisodeBookmarks.Collection.Clear();
            foreach (int bookmark in metadata.EpisodeBookmarks)
            {
                EpisodeBookmarks.Collection.Add(bookmark);
            }

            AddActors(metadata.Actors);
        }

        private void AddActors(List<ActorMetadata> actors)
        {
            Actors.Clear();
            foreach (ActorMetadata actor in actors)
            {
                ActorViewModel actorViewModel = new ActorViewModel
                {
                    Name = actor.Name,
                    Role = actor.Role,
                    Thumb = actor.Thumb
                };
                Actors.Add(actorViewModel);
            }
        }

        private EpisodeMetadata CreateMetadata()
        {
            EpisodeMetadata metadata = new EpisodeMetadata
            {
                Title = Title,
                Rating = Rating,
                SeasonNumber = SeasonNumber,
                EpisodeNumber = EpisodeNumber,
                Plot = Plot,
                Playcount = PlayCount,
                LastPlayed = LastPlayed,
                Credits = Credits,
                Director = Director,
                AiredDate = AiredDate,
                PremieredDate = PremieredDate,
                Studio = Studio,
                MpaaRating = MpaaRating,
                DisplaySeason = DisplaySeason,
                DisplayEpisode = DisplayEpisode,
                EpisodeBookmarks = new List<int>(EpisodeBookmarks.Collection)
            };

            metadata.Actors = new List<ActorMetadata>();
            foreach (ActorViewModel actorViewModel in Actors)
            {
                ActorMetadata actor = new ActorMetadata
                {
                    Name = actorViewModel.Name,
                    Role = actorViewModel.Role,
                    Thumb = actorViewModel.Thumb
                };
                metadata.Actors.Add(actor);
            }

            return metadata;
        }
    }
}
