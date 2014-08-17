using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PerfectMedia.FileInformation;
using PerfectMedia.Movies;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Movies.Selection;
using PerfectMedia.UI.Progress;
using PropertyChanged;

namespace PerfectMedia.UI.Movies
{
    [ImplementPropertyChanged]
    public class MovieViewModel : BaseViewModel, IMovieViewModel, ITreeViewItemViewModel
    {
        private readonly IMovieMetadataService _metadataService;
        private readonly IMovieViewModelFactory _viewModelFactory;
        private readonly IFileSystemService _fileSystemService;
        private bool _lazyLoaded;

        #region Metadata
        public ICachedPropertyViewModel<string> Title { get; private set; }
        public ICachedPropertyViewModel<string> SetName { get; private set; }

        public IImageViewModel Poster { get; private set; }
        public IImageViewModel Fanart { get; private set; }

        public string OriginalTitle { get; set; }
        public DashDelimitedCollectionViewModel<string> Credits { get; set; }
        public DashDelimitedCollectionViewModel<string> Directors { get; set; }
        public double? Rating { get; set; }
        public int? Year { get; set; }
        public DateTime? PremieredDate { get; set; }
        public string Outline { get; set; }
        public string Plot { get; set; }
        public string Tagline { get; set; }
        public int RuntimeInMinutes { get; set; }
        public string Certification { get; set; }
        public int PlayCount { get; set; }
        public string Id { get; set; }
        public DashDelimitedCollectionViewModel<string> Genres { get; set; }
        public string Country { get; set; }
        public VideoFileInformation FileInformation { get; set; }
        public string Studio { get; set; }
        public ObservableCollection<ActorViewModel> Actors { get; set; }
        #endregion

        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(Title.Value))
                {
                    return System.IO.Path.GetFileNameWithoutExtension(Path);
                }
                return Title.Value;
            }
        }

        public string Path { get; private set; }
        public ObservableCollection<IMovieViewModel> Children { get; private set; }
        public IMovieSelectionViewModel Selection { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public MovieViewModel(IMovieMetadataService metadataService,
            IMovieViewModelFactory viewModelFactory,
            IFileSystemService fileSystemService,
            IProgressManagerViewModel progressManager,
            string path)
        {
            _metadataService = metadataService;
            _viewModelFactory = viewModelFactory;
            _fileSystemService = fileSystemService;
            Path = path;
            // Only used by collections
            Children = new ObservableCollection<IMovieViewModel>();
            Selection = viewModelFactory.GetSelection(this);
            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager);
            SaveCommand = new SaveMetadataCommand(this);

            Title = viewModelFactory.GetCachedProperty(Path + "?title", s => s, s => s);
            Title.PropertyChanged += TitlePropertyChanged;
            SetName = viewModelFactory.GetCachedProperty(Path + "?setName", s => s, s => s);
            SetName.PropertyChanged += TitlePropertyChanged;
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

        public async Task Refresh()
        {
            MovieMetadata metadata = await _metadataService.Get(Path);
            RefreshFromMetadata(metadata);
        }

        public async Task<IEnumerable<ProgressItem>> Update()
        {
            MovieMetadata metadata = await _metadataService.Get(Path);
            if (string.IsNullOrEmpty(metadata.Id))
            {
                Lazy<string> displayName = new Lazy<string>(() => DisplayName);
                return new List<ProgressItem> { new ProgressItem(displayName, UpdateInternal) };
            }
            return Enumerable.Empty<ProgressItem>();
        }

        public async Task Save()
        {
            MovieMetadata metadata = CreateMetadata();
            await _metadataService.Save(Path, metadata);
        }

        public async Task Load()
        {
            if (!_lazyLoaded)
            {
                _lazyLoaded = true;
                await Refresh();
            }
        }

        public Task LoadChildren()
        {
            // Do nothing
            return Task.Delay(0);
        }

        public override string ToString()
        {
            return DisplayName;
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
            Studio = metadata.Studio;
            Tagline = metadata.Tagline;
            Title.Value = metadata.Title;
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

        private async Task UpdateInternal()
        {
            await _metadataService.Update(Path);
            //await Application.Current.Dispatcher.InvokeAsync(Refresh);
            await Refresh();
        }
    }
}
