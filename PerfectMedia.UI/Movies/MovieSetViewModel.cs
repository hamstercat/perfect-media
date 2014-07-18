using PerfectMedia.UI.Progress;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Movies
{
    public class MovieSetViewModel : IMovieSetViewModel
    {
        private readonly IFileSystemService _fileSystemService;

        public string DisplayName { get; set; }
        public SmartObservableCollection<IMovieViewModel> Children { get; private set; }

        public bool IsEmpty
        {
            get
            {
                return !Children.Any();
            }
        }

        public MovieSetViewModel(IFileSystemService fileSystemService, string setName)
        {
            _fileSystemService = fileSystemService;
            DisplayName = setName;
            Children = new SmartObservableCollection<IMovieViewModel>();
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

        private bool MovieIsInPath(IMovieViewModel movie, string path)
        {
            string movieFolder = _fileSystemService.GetParentFolder(movie.Path, 1);
            return movieFolder == path;
        }

        public void Refresh()
        {
            foreach (IMovieViewModel movie in Children)
            {
                movie.Refresh();
            }
        }

        public IEnumerable<ProgressItem> Update()
        {
            foreach (IMovieViewModel movie in Children)
            {
                foreach (ProgressItem item in movie.Update())
                {
                    yield return item;
                }
            }
        }

        public void Save()
        {
            foreach (IMovieViewModel movie in Children)
            {
                movie.Save();
            }
        }
    }
}
