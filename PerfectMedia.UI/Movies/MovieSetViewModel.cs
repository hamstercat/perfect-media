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
        public string DisplayName { get; set; }
        public ObservableCollection<IMovieViewModel> Children { get; private set; }

        public bool IsEmpty
        {
            get
            {
                return !Children.Any();
            }
        }

        public MovieSetViewModel()
        {
            Children = new ObservableCollection<IMovieViewModel>();
        }

        public void AddMovie(IMovieViewModel movie)
        {
            Children.Add(movie);
        }

        public void RemoveMovie(IMovieViewModel movie)
        {
            Children.Remove(movie);
        }

        public IMovieViewModel FindMovie(string path)
        {
            return Children.FirstOrDefault(movie => movie.Path == path);
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
