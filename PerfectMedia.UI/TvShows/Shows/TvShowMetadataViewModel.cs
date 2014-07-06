using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.TvShows.Shows
{
    [ImplementPropertyChanged]
    public class TvShowMetadataViewModel : ITvShowMetadataViewModel, IMetadataProvider
    {
        private readonly ITvShowViewModelFactory _viewModelFactory;
        private readonly ITvShowMetadataService _metadataService;
        private bool _lazyLoaded;

        public string Path { get; private set; }
        public ITvShowImagesViewModel Images { get; private set; }

        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        #region Metadata
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
                InitialLoadInformation();
                _actors = value;
            }
        }

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
                InitialLoadInformation();
                _state = value;
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
                InitialLoadInformation();
                _title = value;
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
                InitialLoadInformation();
                _id = value;
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
                InitialLoadInformation();
                _mpaaRating = value;
            }
        }

        private DashDelimitedCollectionViewModel<string> _genres;
        public DashDelimitedCollectionViewModel<string> Genres
        {
            get
            {
                InitialLoadInformation();
                return _genres;
            }
            set
            {
                InitialLoadInformation();
                _genres = value;
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
                InitialLoadInformation();
                _imdbId = value;
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
                InitialLoadInformation();
                _runtimeInMinutes = value;
            }
        }

        private double? _rating;
        public double? Rating
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
                InitialLoadInformation();
                _premieredDate = value;
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
                InitialLoadInformation();
                _studio = value;
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
                InitialLoadInformation();
                _language = value;
            }
        }
        #endregion

        public TvShowMetadataViewModel(ITvShowViewModelFactory viewModelFactory, ITvShowMetadataService metadataService, IProgressManagerViewModel progressManager, string path)
        {
            _viewModelFactory = viewModelFactory;
            _metadataService = metadataService;
            Path = path;
            _lazyLoaded = false;

            Images = viewModelFactory.GetTvShowImages(this, path);
            // We don't want to trigger the InitialLoadInformation by setting the properties
            _actors = new ObservableCollection<ActorViewModel>();
            _genres = new DashDelimitedCollectionViewModel<string>(s => s);

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager);
            SaveCommand = new SaveMetadataCommand(this);
        }

        public void Refresh()
        {
            TvShowMetadata metadata = _metadataService.Get(Path);
            RefreshFromMetadata(metadata);
            Images.Refresh();
        }

        public IEnumerable<ProgressItem> Update()
        {
            TvShowMetadata metadata = _metadataService.Get(Path);
            if (string.IsNullOrEmpty(metadata.Id))
            {
                Lazy<string> displayName = new Lazy<string>(ToString);
                yield return new ProgressItem(displayName, UpdateInternal);
            }
        }

        public void Save()
        {
            TvShowMetadata metadata = CreateMetadata();
            _metadataService.Save(Path, metadata);
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Title))
            {
                return Path;
            }
            return Title;
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
                ActorViewModel actorViewModel = _viewModelFactory.GetActor();
                actorViewModel.Name = actor.Name;
                actorViewModel.Role = actor.Role;
                actorViewModel.ThumbUrl = actor.Thumb;
                actorViewModel.ThumbPath.Path = actor.ThumbPath;
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
                    Thumb = actorViewModel.ThumbUrl,
                    ThumbPath = actorViewModel.ThumbPath.Path
                };
                metadata.Actors.Add(actor);
            }

            return metadata;
        }

        private Task UpdateInternal()
        {
            return Task.Run(() =>
            {
                _metadataService.Update(Path);
                Refresh();
            });
        }
    }
}
