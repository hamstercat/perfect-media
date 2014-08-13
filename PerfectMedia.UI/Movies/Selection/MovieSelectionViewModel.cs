using System.Collections.Generic;
using System.Windows.Input;
using PerfectMedia.Movies;
using PropertyChanged;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Movies.Selection
{
    [ImplementPropertyChanged]
    public class MovieSelectionViewModel : BaseViewModel, IMovieSelectionViewModel
    {
        public string SearchTitle { get; set; }
        public bool IsClosed { get; set; }
        public object OriginalContent { get; set; }
        public SelectionViewModel<Movie> Selection { get; private set; }
        public ICommand SearchCommand { get; private set; }

        public MovieSelectionViewModel(IMovieMetadataService metadataService, IMovieViewModel movieViewModel)
        {
            SearchCommand = new SearchCommand(metadataService, this);
            Selection = new SelectionViewModel<Movie>(async movie =>
            {
                SaveNewId(metadataService, movie.Id, movieViewModel.Path);
                await Update(metadataService, movieViewModel, movieViewModel.Path);
                IsClosed = true;
            });
        }

        public void ReplaceMovies(IEnumerable<Movie> movies)
        {
            Selection.AvailableItems.Clear();
            foreach (Movie movie in movies)
            {
                Selection.AvailableItems.Add(movie);
            }
        }

        private void SaveNewId(IMovieMetadataService metadataService, string movieId, string path)
        {
            MovieMetadata metadata = metadataService.Get(path);
            metadata.Id = movieId;
            metadataService.Save(path, metadata);
        }

        private async Task Update(IMovieMetadataService metadataService, IMovieViewModel movieViewModel, string path)
        {
            metadataService.DeleteImages(path);
            await metadataService.Update(path);
            movieViewModel.Refresh();
        }
    }
}
