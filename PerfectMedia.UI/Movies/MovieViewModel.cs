using PerfectMedia.FileInformation;
using PerfectMedia.Movies;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
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

        private DateTime? _premiered;
        public DateTime? Premiered
        {
            get
            {
                InitialLoadInformation();
                return _premiered;
            }
            set
            {
                InitialLoadInformation();
                _premiered = value;
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

        private SmartObservableCollection<ActorMetadata> _actors;
        public SmartObservableCollection<ActorMetadata> Actors
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
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public MovieViewModel(IMovieMetadataService metadataService, IProgressManagerViewModel progressManager, string path)
        {
            _metadataService = metadataService;
            Path = path;
            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager);
            SaveCommand = new SaveMetadataCommand(this);

            _genres = new DashDelimitedCollectionViewModel<string>(s => s);
            _actors = new SmartObservableCollection<ActorMetadata>();
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
            Premiered = metadata.Premiered;
            Rating = metadata.Rating;
            RuntimeInMinutes = metadata.RuntimeInMinutes;
            SetName = metadata.SetName;
            Studio = metadata.Studio;
            Tagline = metadata.Tagline;
            Title = metadata.Title;
            Year = metadata.Year;

            Actors.Clear();
            Actors.AddRange(metadata.Actors);

            Genres.Collection.Clear();
            Genres.Collection.AddRange(metadata.Genres);
        }

        private MovieMetadata CreateMetadata()
        {
            return new MovieMetadata
            {
                Actors = Actors.ToList(),
                FileInformation = FileInformation,
                Genres = Genres.Collection.ToList(),
                Id = Id,
                OriginalTitle = OriginalTitle,
                Outline = Outline,
                PlayCount = PlayCount,
                Plot = Plot,
                Premiered = Premiered,
                Rating = Rating,
                RuntimeInMinutes = RuntimeInMinutes,
                SetName = SetName,
                Studio = Studio,
                Tagline = Tagline,
                Title = Title,
                Year = Year
            };
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
