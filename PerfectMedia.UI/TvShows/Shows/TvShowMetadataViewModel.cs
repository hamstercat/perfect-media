using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PerfectMedia.UI.TvShows.Shows
{
    public class TvShowMetadataViewModel : BaseViewModel, IMetadataProvider
    {
        private readonly ITvShowMetadataService _metadataService;
        private bool _lazyLoaded;

        public string Path { get; private set; }
        public TvShowImagesViewModel Images { get; private set; }
        public ObservableCollection<ActorViewModel> Actors { get; private set; }
        
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        #region Metadata
        private int _state;
        public int State
        {
            get
            {
                InitialLoadInformation();
                return _state;
            }
            set
            {
                _state = value;
                OnPropertyChanged("State");
            }
        }

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

        private string _id;
        public string Id
        {
            get
            {
                InitialLoadInformation();
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
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

        private DashDelimitedCollectionViewModel<string> _genres;
        public DashDelimitedCollectionViewModel<string> Genres
        {
            get
            {
                return _genres;
            }
            set
            {
                _genres = value;
                OnPropertyChanged("Genres");
            }
        }

        private string _imdbId;
        public string ImdbId
        {
            get
            {
                InitialLoadInformation();
                return _imdbId;
            }
            set
            {
                _imdbId = value;
                OnPropertyChanged("ImdbId");
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

        private int _runtimeInMinutes;
        public int RuntimeInMinutes
        {
            get
            {
                InitialLoadInformation();
                return _runtimeInMinutes;
            }
            set
            {
                _runtimeInMinutes = value;
                OnPropertyChanged("RuntimeInMinutes");
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

        private string _language;
        public string Language
        {
            get
            {
                InitialLoadInformation();
                return _language;
            }
            set
            {
                _language = value;
                OnPropertyChanged("Language");
            }
        }
        #endregion

        public TvShowMetadataViewModel(ITvShowViewModelFactory viewModelFactory, ITvShowMetadataService metadataService, string path)
        {
            _metadataService = metadataService;
            Path = path;
            _lazyLoaded = false;

            Images = viewModelFactory.GetTvShowImages(path);
            Actors = new ObservableCollection<ActorViewModel>();
            Genres = new DashDelimitedCollectionViewModel<string>(s => s);

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this);
            SaveCommand = new SaveMetadataCommand(this);
        }

        public void Refresh()
        {
            TvShowMetadata metadata = _metadataService.Get(Path);
            RefreshFromMetadata(metadata);
            Images.Refresh();
        }

        public void Update()
        {
            TvShowMetadata metadata = _metadataService.Get(Path);
            if (string.IsNullOrEmpty(metadata.Id))
            {
                _metadataService.Update(Path);
            }
            Refresh();
        }

        public void Save()
        {
            TvShowMetadata metadata = CreateMetadata();
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

        private void RefreshFromMetadata(TvShowMetadata metadata)
        {
            State = metadata.State;
            Title = metadata.Title;
            Id = metadata.Id;
            MpaaRating = metadata.MpaaRating;
            ImdbId = metadata.ImdbId;
            Plot = metadata.Plot;
            RuntimeInMinutes = metadata.RuntimeInMinutes;
            Rating = metadata.Rating;
            PremieredDate = metadata.PremieredDate;
            Studio = metadata.Studio;
            Language = metadata.Language;
            
            Genres.Collection.Clear();
            foreach (string genre in metadata.Genres)
            {
                Genres.Collection.Add(genre);
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

        private TvShowMetadata CreateMetadata()
        {
            TvShowMetadata metadata = new TvShowMetadata
            {
                State = State,
                Title = Title,
                Id = Id,
                MpaaRating = MpaaRating,
                ImdbId = ImdbId,
                Plot = Plot,
                RuntimeInMinutes = RuntimeInMinutes,
                Rating = Rating,
                PremieredDate = PremieredDate,
                Studio = Studio,
                Language = Language,
                Genres = new List<string>(Genres.Collection)
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
