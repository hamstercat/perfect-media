﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.Movies;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PropertyChanged;

namespace PerfectMedia.UI.Movies.Set
{
    [ImplementPropertyChanged]
    public class MovieSetViewModel : IMovieSetViewModel
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IMovieMetadataService _metadataService;

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
            string setName)
        {
            _fileSystemService = fileSystemService;
            _metadataService = metadataService;
            SetName = DisplayName = setName;
            Fanart = viewModelFactory.GetImage(new SetFanartImageStrategy(metadataService, this));
            Poster = viewModelFactory.GetImage(new SetPosterImageStrategy(metadataService, this));
            Children = new ObservableCollection<IMovieViewModel>();

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager);
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
                MovieSet set = _metadataService.GetMovieSet(DisplayName);
                SetName = DisplayName = set.Name;
                Fanart.Path = set.BackdropPath;
                Poster.Path = set.PosterPath;
                Fanart.RefreshImage();
                Poster.RefreshImage();
            });
        }

        public async Task<IEnumerable<ProgressItem>> Update()
        {
            List<ProgressItem> result = new List<ProgressItem>();
            if (!await _fileSystemService.FileExists(Fanart.Path) || await _fileSystemService.FileExists(Poster.Path))
            {
                result.Add(UpdateImages());
            }
            foreach (IMovieViewModel movie in Children)
            {
                result.AddRange(await movie.Update());
            }
            return result;
        }

        public async Task Save()
        {
            if (SetName != DisplayName)
            {
                await MoveImages();
                DisplayName = SetName;
                foreach (IMovieViewModel movie in Children.ToList())
                {
                    movie.SetName = SetName;
                    await movie.Save();
                }
            }
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

        public override string ToString()
        {
            return DisplayName;
        }

        private bool MovieIsInPath(IMovieViewModel movie, string path)
        {
            string movieFolder = _fileSystemService.GetParentFolder(movie.Path, 1);
            return movieFolder == path;
        }

        private ProgressItem UpdateImages()
        {
            Lazy<string> displayName = new Lazy<string>(() => DisplayName);
            return new ProgressItem(displayName, LoadImagesInternal);
        }

        private async Task LoadImagesInternal()
        {
            AvailableMovieImages images = _metadataService.FindSetImages(DisplayName);
            await SetImagePathIfNeeded(images.Fanarts, Fanart);
            await SetImagePathIfNeeded(images.Posters, Poster);
            await Refresh();
        }

        private async Task SetImagePathIfNeeded(IEnumerable<Image> images, IImageViewModel imageViewModel)
        {
            Image image = images.FirstOrDefault();
            if (image != null && !await _fileSystemService.FileExists(imageViewModel.Path))
            {
                await _fileSystemService.DownloadImage(imageViewModel.Path, image.Url);
            }
        }
    }
}
