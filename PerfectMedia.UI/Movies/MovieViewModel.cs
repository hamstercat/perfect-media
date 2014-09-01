using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.FileInformation;
using PerfectMedia.Movies;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Movies.Selection;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.Validations;
using PropertyChanged;

namespace PerfectMedia.UI.Movies
{
    [ImplementPropertyChanged]
    public class MovieViewModel : MediaViewModel, IMovieViewModel
    {
        private readonly IMovieMetadataService _metadataService;
        private readonly IMovieViewModelFactory _viewModelFactory;
        private readonly IFileSystemService _fileSystemService;
        private readonly IBusyProvider _busyProvider;

        [RequiredCached]
        public ICachedPropertyViewModel<string> Title { get; private set; }

        [LocalizedRequired]
        public string Id { get; set; }

        [Rating]
        public double? Rating { get; set; }

        [Positive]
        public int? RuntimeInMinutes { get; set; }

        [Positive]
        public int? PlayCount { get; set; }

        public ICachedPropertyViewModel<string> SetName { get; private set; }
        public IImageViewModel Poster { get; private set; }
        public IImageViewModel Fanart { get; private set; }
        public string OriginalTitle { get; set; }
        public DashDelimitedCollectionViewModel<string> Credits { get; set; }
        public DashDelimitedCollectionViewModel<string> Directors { get; set; }
        public int? Year { get; set; }
        public DateTime? PremieredDate { get; set; }
        public string Outline { get; set; }
        public string Plot { get; set; }
        public string Tagline { get; set; }
        public string Certification { get; set; }
        public DashDelimitedCollectionViewModel<string> Genres { get; set; }
        public string Country { get; set; }
        public VideoFileInformation FileInformation { get; set; }
        public string Studio { get; set; }
        public ObservableCollection<ActorViewModel> Actors { get; set; }

        public override string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(Title.CachedValue))
                {
                    return System.IO.Path.GetFileNameWithoutExtension(Path);
                }
                return Title.CachedValue;
            }
        }

        public string Path { get; private set; }
        public ObservableCollection<IMovieViewModel> Children { get; private set; }
        public IMovieSelectionViewModel Selection { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public MovieViewModel(IMovieMetadataService metadataService,
            IMovieViewModelFactory viewModelFactory,
            IFileSystemService fileSystemService,
            IProgressManagerViewModel progressManager,
            IBusyProvider busyProvider,
            IDialogViewer dialogViewer,
            string path)
            : base(busyProvider, dialogViewer)
        {
            _metadataService = metadataService;
            _viewModelFactory = viewModelFactory;
            _fileSystemService = fileSystemService;
            _busyProvider = busyProvider;
            // Only used by movie sets
            Children = new ObservableCollection<IMovieViewModel>();
            Selection = viewModelFactory.GetSelection(this);
            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager, busyProvider);
            SaveCommand = new SaveMetadataCommand(this);
            DeleteCommand = new DeleteMetadataCommand(this);

            Title = viewModelFactory.GetStringCachedProperty(path + "?title", true);
            Title.PropertyChanged += TitlePropertyChanged;
            SetName = viewModelFactory.GetStringCachedProperty(path + "?setName", false);
            SetName.PropertyChanged += TitlePropertyChanged;
            Path = path;
            Poster = viewModelFactory.GetImage(new PosterImageStrategy(metadataService, this));
            Fanart = viewModelFactory.GetImage(new FanartImageStrategy(metadataService, this));
            Credits = new DashDelimitedCollectionViewModel<string>(s => s);
            Directors = new DashDelimitedCollectionViewModel<string>(s => s);
            Genres = new DashDelimitedCollectionViewModel<string>(s => s);
            Actors = new ObservableCollection<ActorViewModel>();
        }

        public IEnumerable<IMovieViewModel> FindMovie(string path)
        {
            string movieFolder = _fileSystemService.GetParentFolder(Path, 1);
            if (movieFolder == path)
            {
                yield return this;
            }
        }

        protected override async Task RefreshInternal()
        {
            MovieMetadata metadata = await _metadataService.Get(Path);
            RefreshFromMetadata(metadata);
        }

        protected override async Task<IEnumerable<ProgressItem>> UpdateInternal()
        {
            await Refresh();
            if (string.IsNullOrEmpty(Id))
            {
                Lazy<string> displayName = new Lazy<string>(() => DisplayName);
                return new List<ProgressItem> { new ProgressItem(Path, displayName, UpdateMethod) };
            }
            return Enumerable.Empty<ProgressItem>();
        }

        protected override async Task SaveInternal()
        {
            Title.Save();
            SetName.Save();
            MovieMetadata metadata = CreateMetadata();
            await _metadataService.Save(Path, metadata);
        }

        protected override async Task DeleteInternal()
        {
            await _metadataService.Delete(Path);
            await Refresh();
        }

        protected override Task LoadChildrenInternal()
        {
            // Do nothing
            return Task.Delay(0);
        }

        private void TitlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("Title");
            OnPropertyChanged("SetName");
        }

        private void RefreshFromMetadata(MovieMetadata metadata)
        {
            Certification = metadata.Certification;
            FileInformation = metadata.FileInformation;
            Id = metadata.Id;
            OriginalTitle = metadata.OriginalTitle;
            Outline = metadata.Outline;
            PlayCount = metadata.PlayCount;
            Plot = metadata.Plot;
            PremieredDate = metadata.Premiered;
            Rating = metadata.Rating;
            RuntimeInMinutes = metadata.RuntimeInMinutes;
            Country = metadata.Country;
            SetName.Value = metadata.SetName;
            SetName.Save();
            Studio = metadata.Studio;
            Tagline = metadata.Tagline;
            Title.Value = metadata.Title;
            Title.Save();
            Year = metadata.Year;
            Poster.Path = metadata.ImagePosterPath;
            Fanart.Path = metadata.ImageFanartPath;

            Credits.ReplaceWith(metadata.Credits);
            Directors.ReplaceWith(metadata.Directors);
            Genres.ReplaceWith(metadata.Genres);
            AddActors(metadata.Actors);
        }

        private void AddActors(IEnumerable<ActorMetadata> actors)
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
                Certification = Certification,
                Credits = Credits.Collection.ToList(),
                Directors = Directors.Collection.ToList(),
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
                Country = Country,
                SetName = SetName.Value,
                Studio = Studio,
                Tagline = Tagline,
                Title = Title.Value,
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

        private async Task UpdateMethod()
        {
            using (_busyProvider.DoWork())
            {
                await _metadataService.Update(Path);
                await Refresh();
            }
        }
    }
}
