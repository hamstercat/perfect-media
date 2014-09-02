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
    public class MovieSetViewModel : MediaViewModel<IMovieViewModel>, IMovieSetViewModel
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IMovieMetadataService _metadataService;
        private readonly IBusyProvider _busyProvider;

        public override string DisplayName
        {
            get { return DisplayNameInternal; }
        }

        [Required]
        public string SetName { get; set; }

        public string DisplayNameInternal { get; private set; }
        public IImageViewModel Fanart { get; private set; }
        public IImageViewModel Poster { get; private set; }
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
            IDialogViewer dialogViewer,
            string setName)
            : base(busyProvider, dialogViewer, null)
        {
            _fileSystemService = fileSystemService;
            _metadataService = metadataService;
            _busyProvider = busyProvider;
            SetName = DisplayNameInternal = setName;
            Fanart = viewModelFactory.GetImage(new SetFanartImageStrategy(metadataService, this));
            Poster = viewModelFactory.GetImage(new SetPosterImageStrategy(metadataService, this));

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager, busyProvider);
            SaveCommand = new SaveMetadataCommand(this);

            RefreshSynchronously();
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

        protected override Task RefreshInternal()
        {
            return Task.Run(() => RefreshSynchronously());
        }

        protected override async Task<IEnumerable<ProgressItem>> UpdateInternal()
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

        protected override async Task SaveInternal()
        {
            if (SetName != DisplayName)
            {
                await MoveImages();
                DisplayNameInternal = SetName;
                foreach (IMovieViewModel movie in Children.ToList())
                {
                    movie.SetName.Value = SetName;
                    await movie.Save();
                }
            }
        }

        protected override Task DeleteInternal()
        {
            throw new NotSupportedException("Can't delete a Movie Set");
        }

        protected override Task LoadChildrenInternal()
        {
            // Nothing to do
            return Task.Delay(0);
        }

        private void RefreshSynchronously()
        {
            MovieSet set = _metadataService.GetMovieSet(DisplayName);
            SetName = DisplayNameInternal = set.Name;
            Fanart.Path = set.BackdropPath;
            Poster.Path = set.PosterPath;
            Fanart.RefreshImage();
            Poster.RefreshImage();
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
