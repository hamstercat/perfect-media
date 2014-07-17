using PerfectMedia.FileInformation;
using PerfectMedia.Movies;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Movies.Selection;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.Movies
{
    [ImplementPropertyChanged]
    public class MovieViewModel : IMovieViewModel
    {
        private readonly IMovieMetadataService _metadataService;
        private readonly IMovieViewModelFactory _viewModelFactory;
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

        private string _originalTitle;
        public string OriginalTitle
        {
            get
            {
                InitialLoadInformation();
                return _originalTitle;
            }
            set
            {
                InitialLoadInformation();
                _originalTitle = value;
            }
        }

        private string _setName;
        public string SetName
        {
            get
            {
                InitialLoadInformation();
                return _setName;
            }
            set
            {
                InitialLoadInformation();
                _setName = value;
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

        private int? _year;
        public int? Year
        {
            get
            {
                InitialLoadInformation();
                return _year;
            }
            set
            {
                InitialLoadInformation();
                _year = value;
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

        private string _outline;
        public string Outline
        {
            get
            {
                InitialLoadInformation();
                return _outline;
            }
            set
            {
                InitialLoadInformation();
                _outline = value;
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

        private string _tagline;
        public string Tagline
        {
            get
            {
                InitialLoadInformation();
                return _tagline;
            }
            set
            {
                InitialLoadInformation();
                _tagline = value;
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

        private VideoFileInformation _fileInformation;
        public VideoFileInformation FileInformation
        {
            get
            {
                InitialLoadInformation();
                return _fileInformation;
            }
            set
            {
                InitialLoadInformation();
                _fileInformation = value;
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

        private SmartObservableCollection<ActorViewModel> _actors;
        public SmartObservableCollection<ActorViewModel> Actors
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

        public IImageViewModel Poster { get; private set; }
        public IImageViewModel Fanart { get; private set; }
        #endregion

        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(Title))
                {
                    return System.IO.Path.GetFileNameWithoutExtension(Path);
                }
                return Title;
            }
        }

        public string Path { get; private set; }
        public IMovieSelectionViewModel Selection { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public MovieViewModel(IMovieMetadataService metadataService, IMovieViewModelFactory viewModelFactory, IProgressManagerViewModel progressManager, string path)
        {
            _metadataService = metadataService;
            _viewModelFactory = viewModelFactory;
            Path = path;
            Selection = viewModelFactory.GetSelection(this);
            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager);
            SaveCommand = new SaveMetadataCommand(this);

            Poster = viewModelFactory.GetImage(new PosterImageStrategy(metadataService, this));
            Fanart = viewModelFactory.GetImage(new FanartImageStrategy(metadataService, this));

            _genres = new DashDelimitedCollectionViewModel<string>(s => s);
            _actors = new SmartObservableCollection<ActorViewModel>();
        }

        public void Refresh()
        {
            MovieMetadata metadata = _metadataService.Get(Path);
            RefreshFromMetadata(metadata);
        }

        public IEnumerable<ProgressItem> Update()
        {
            MovieMetadata metadata = _metadataService.Get(Path);
            if (string.IsNullOrEmpty(metadata.Id))
            {
                Lazy<string> displayName = new Lazy<string>(ToString);
                yield return new ProgressItem(displayName, UpdateInternal);
            }
        }

        public void Save()
        {
            MovieMetadata metadata = CreateMetadata();
            _metadataService.Save(Path, metadata);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        private void InitialLoadInformation()
        {
            if (!_lazyLoaded)
            {
                _lazyLoaded = true;
                Refresh();
            }
        }

        private void RefreshFromMetadata(MovieMetadata metadata)
        {
            FileInformation = metadata.FileInformation;
            Id = metadata.Id;
            OriginalTitle = metadata.OriginalTitle;
            Outline = metadata.Outline;
            PlayCount = metadata.PlayCount;
            Plot = metadata.Plot;
            PremieredDate = metadata.Premiered;
            Rating = metadata.Rating;
            RuntimeInMinutes = metadata.RuntimeInMinutes;
            SetName = metadata.SetName;
            Studio = metadata.Studio;
            Tagline = metadata.Tagline;
            Title = metadata.Title;
            Year = metadata.Year;
            Poster.Path = metadata.ImagePosterPath;
            Fanart.Path = metadata.ImageFanartPath;

            Genres.ReplaceWith(metadata.Genres);
            AddActors(metadata.Actors);
        }

        private void AddActors(List<ActorMetadata> actors)
        {
            Actors.Clear();
            foreach (ActorMetadata actor in actors)
            {
                ActorViewModel actorViewModel = new ActorViewModel(_viewModelFactory.GetImage());
                actorViewModel.Name = actor.Name;
                actorViewModel.Role = actor.Role;
                actorViewModel.ThumbUrl = actor.Thumb;
                actorViewModel.ThumbPath.Path = actor.ThumbPath;
                Actors.Add(actorViewModel);
            }
        }

        private MovieMetadata CreateMetadata()
        {
            MovieMetadata metadata = new MovieMetadata
            {
                FileInformation = FileInformation,
                Genres = Genres.Collection.ToList(),
                Id = Id,
                OriginalTitle = OriginalTitle,
                Outline = Outline,
                PlayCount = PlayCount,
                Plot = Plot,
                Premiered = PremieredDate,
                Rating = Rating,
                RuntimeInMinutes = RuntimeInMinutes,
                SetName = SetName,
                Studio = Studio,
                Tagline = Tagline,
                Title = Title,
                Year = Year
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
