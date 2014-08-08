using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Movies.Set;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.Sources;
using PropertyChanged;

namespace PerfectMedia.UI.Movies
{
    [ImplementPropertyChanged]
    public class MovieManagerViewModel : ISourceProvider
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IMovieViewModelFactory _viewModelFactory;

        public ISourceManagerViewModel Sources { get; set; }
        public ObservableCollection<IMovieItem> Movies { get; private set; }
        public ICommand UpdateAll { get; private set; }

        public MovieManagerViewModel(IFileSystemService fileSystemService, IMovieViewModelFactory viewModelFactory, IProgressManagerViewModel progressManager)
        {
            _fileSystemService = fileSystemService;
            _viewModelFactory = viewModelFactory;
            Movies = new ObservableCollection<IMovieItem>();
            UpdateAll = new UpdateAllMetadataCommand<IMovieItem>(Movies, progressManager);
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
            }
        }

        private void AddMovies(IEnumerable<string> movies)
        {
            foreach (string path in movies)
            {
                foreach (string file in FindMovieFiles(path))
                {
                    IMovieViewModel newMovie = _viewModelFactory.GetMovie(file);
                    AddMovie(newMovie);
                    newMovie.PropertyChanged += MoviePropertyChanged;
                }
            }
        }

        private void AddMovie(IMovieViewModel movie)
        {
            if (string.IsNullOrEmpty(movie.SetName))
            {
                Movies.Add(movie);
            }
            else
            {
                AddMovieSet(movie);
            }
        }

        private void AddMovieSet(IMovieViewModel movie)
        {
            IMovieSetViewModel movieSet = Movies.OfType<IMovieSetViewModel>().FirstOrDefault(m => m.DisplayName == movie.SetName);
            if (movieSet == null)
            {
                movieSet = _viewModelFactory.GetMovieSet(movie.SetName);
                Movies.Add(movieSet);
            }
            movieSet.AddMovie(movie);
        }

        private void RemoveMovies(IEnumerable<string> movies)
        {
            foreach (string path in movies)
            {
                foreach (IMovieViewModel movieToRemove in FindMovieInMovies(path))
                {
                    RemoveMovie(movieToRemove);
                    movieToRemove.PropertyChanged -= MoviePropertyChanged;
                }
            }
        }

        private IEnumerable<IMovieViewModel> FindMovieInMovies(string path)
        {
            foreach (IMovieItem movieItem in Movies.ToList())
            {
                IEnumerable<IMovieViewModel> movies = movieItem.FindMovie(path);
                foreach (IMovieViewModel movie in movies.ToList())
                {
                    yield return movie;
                }
            }
        }

        private void RemoveMovie(IMovieViewModel movie)
        {
            Movies.Remove(movie);
            foreach (IMovieSetViewModel movieSet in Movies.OfType<IMovieSetViewModel>().ToList())
            {
                movieSet.RemoveMovie(movie);
                if (movieSet.IsEmpty)
                {
                    Movies.Remove(movieSet);
                }
            }
        }

        private void MoviePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SetName")
            {
                IMovieViewModel movie = (IMovieViewModel)sender;
                Application.Current.Dispatcher.Invoke(() =>
                {
                    RemoveMovie(movie);
                    AddMovie(movie);
                });
            }
        }

        private IEnumerable<string> FindMovieFiles(string path)
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
