using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.Movies;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PropertyChanged;

namespace PerfectMedia.UI.Movies.Set
{
    [ImplementPropertyChanged]
    public class MovieSetViewModel : BaseViewModel, IMovieSetViewModel, ITreeViewItemViewModel
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IMovieMetadataService _metadataService;
        private readonly IBusyProvider _busyProvider;

        [Required]
        public string SetName { get; set; }

        public string DisplayName { get; private set; }
        public IImageViewModel Fanart { get; private set; }
        public IImageViewModel Poster { get; private set; }
        public ObservableCollection<IMovieViewModel> Children { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public bool IsEmpty
        {
            get
            {
                return !Children.Any();
            }
        }

        public MovieSetViewModel(IFileSystemService fileSystemService,
            IMovieViewModelFactory viewModelFactory,
            IMovieMetadataService metadataService,
            IProgressManagerViewModel progressManager,
            IBusyProvider busyProvider,
            string setName)
        {
            _fileSystemService = fileSystemService;
            _metadataService = metadataService;
            _busyProvider = busyProvider;
            SetName = DisplayName = setName;
            Fanart = viewModelFactory.GetImage(new SetFanartImageStrategy(metadataService, this));
            Poster = viewModelFactory.GetImage(new SetPosterImageStrategy(metadataService, this));
            Children = new ObservableCollection<IMovieViewModel>();

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager, busyProvider);
            SaveCommand = new SaveMetadataCommand(this);

            Refresh();
        }

        public void AddMovie(IMovieViewModel movie)
        {
            Children.Add(movie);
        }

        public void RemoveMovie(IMovieViewModel movie)
        {
            Children.Remove(movie);
        }

        public IEnumerable<IMovieViewModel> FindMovie(string path)
        {
            return Children.Where(movie => MovieIsInPath(movie, path));
        }

        public Task Refresh()
        {
            return Task.Run(() =>
            {
                using (_busyProvider.DoWork())
                {
                    MovieSet set = _metadataService.GetMovieSet(DisplayName);
                    SetName = DisplayName = set.Name;
                    Fanart.Path = set.BackdropPath;
                    Poster.Path = set.PosterPath;
                    Fanart.RefreshImage();
                    Poster.RefreshImage();
                }
            });
        }

        public async Task<IEnumerable<ProgressItem>> Update()
        {
            using (_busyProvider.DoWork())
            {
                List<ProgressItem> result = new List<ProgressItem>();
                if (!await _fileSystemService.FileExists(Fanart.Path) ||
                    await _fileSystemService.FileExists(Poster.Path))
                {
                    result.Add(UpdateImages());
                }
                foreach (IMovieViewModel movie in Children)
                {
                    result.AddRange(await movie.Update());
                }
                return result;
            }
        }

        public async Task Save()
        {
            using (_busyProvider.DoWork())
            {
                if (SetName != DisplayName)
                {
                    await MoveImages();
                    DisplayName = SetName;
                    foreach (IMovieViewModel movie in Children.ToList())
                    {
                        movie.SetName.Value = SetName;
                        await movie.Save();
                    }
                }
            }
        }

        public Task Delete()
        {
            throw new NotSupportedException("Can't delete a Movie Set");
        }

        public Task Load()
        {
            // Nothing to do
            return Task.Delay(0);
        }

        public Task LoadChildren()
        {
            // Nothing to do
            return Task.Delay(0);
        }

        public override string ToString()
        {
            return DisplayName;
        }

        private async Task MoveImages()
        {
            MovieSet oldSet = _metadataService.GetMovieSet(DisplayName);
            MovieSet newSet = _metadataService.GetMovieSet(SetName);
            await _fileSystemService.MoveFile(oldSet.BackdropPath, newSet.BackdropPath);
            await _fileSystemService.MoveFile(oldSet.PosterPath, newSet.PosterPath);
            Fanart.Path = newSet.BackdropPath;
            Poster.Path = newSet.PosterPath;
        }

        private bool MovieIsInPath(IMovieViewModel movie, string path)
        {
            string movieFolder = _fileSystemService.GetParentFolder(movie.Path, 1);
            return movieFolder == path;
        }

        private ProgressItem UpdateImages()
        {
            Lazy<string> displayName = new Lazy<string>(() => DisplayName);
            return new ProgressItem("SetName/" + SetName, displayName, LoadImagesInternal);
        }

        private async Task LoadImagesInternal()
        {
            using (_busyProvider.DoWork())
            {
                AvailableMovieImages images = await _metadataService.FindSetImages(DisplayName);
                await SetImagePathIfNeeded(images.Fanarts, Fanart);
                await SetImagePathIfNeeded(images.Posters, Poster);
                await Refresh();
            }
        }

        private async Task SetImagePathIfNeeded(IEnumerable<Image> images, IImageViewModel imageViewModel)
        {
            using (_busyProvider.DoWork())
            {
                Image image = images.FirstOrDefault();
                if (image != null && !await _fileSystemService.FileExists(imageViewModel.Path))
                {
                    await _fileSystemService.DownloadImage(imageViewModel.Path, image.Url);
                }
            }
        }
    }
}
