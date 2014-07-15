﻿using PerfectMedia.Movies;
using PerfectMedia.Sources;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.Sources;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.Movies
{
    [ImplementPropertyChanged]
    public class MovieManagerViewModel : ISourceProvider
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IMovieViewModelFactory _viewModelFactory;

        public ISourceManagerViewModel Sources { get; set; }
        public SmartObservableCollection<IMovieViewModel> Movies { get; private set; }
        public ICommand UpdateAll { get; private set; }

        public MovieManagerViewModel(IFileSystemService fileSystemService, IMovieViewModelFactory viewModelFactory, IProgressManagerViewModel progressManager)
        {
            _fileSystemService = fileSystemService;
            _viewModelFactory = viewModelFactory;
            Movies = new SmartObservableCollection<IMovieViewModel>();
            UpdateAll = new UpdateAllMetadataCommand<IMovieViewModel>(Movies, progressManager);
            LoadSources();
        }

        private void LoadSources()
        {
            Sources = _viewModelFactory.GetSourceManager();
            Sources.SpecificFolders.CollectionChanged += SourceFoldersCollectionChanged;
            Sources.Load();
        }

        private void SourceFoldersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddMovies(e.NewItems.Cast<string>());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveMovies(e.OldItems.Cast<string>());
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RemoveMovies(e.OldItems.Cast<string>());
                    AddMovies(e.NewItems.Cast<string>());
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Movies.Clear();
                    break;
                case NotifyCollectionChangedAction.Move:
                default:
                    break;
            }
        }

        private void AddMovies(IEnumerable<string> movies)
        {
            foreach (string path in movies)
            {
                foreach (string file in FindMoviesInPath(path))
                {
                    IMovieViewModel newMovie = _viewModelFactory.GetMovie(file);
                    Movies.Add(newMovie);
                }
            }
        }

        private void RemoveMovies(IEnumerable<string> movies)
        {
            foreach (string path in movies)
            {
                IMovieViewModel movieToRemove = Movies.First(movie => movie.Path == path);
                Movies.Remove(movieToRemove);
            }
        }

        private IEnumerable<string> FindMoviesInPath(string path)
        {
            return _fileSystemService.FindVideoFiles(path)
                .Where(FileIsNotTrailer);
        }

        private bool FileIsNotTrailer(string videoFile)
        {
            string fileName = System.IO.Path.GetFileNameWithoutExtension(videoFile);
            return !fileName.EndsWith("-trailer");
        }
    }
}
