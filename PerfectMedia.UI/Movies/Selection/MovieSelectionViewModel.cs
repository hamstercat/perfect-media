using System.Collections.Generic;
using System.Windows.Input;
using PerfectMedia.Movies;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Selection;
using PropertyChanged;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Movies.Selection
{
    [ImplementPropertyChanged]
    public class MovieSelectionViewModel : SearchableSelectionViewModel<Movie>, IMovieSelectionViewModel
    {
        private readonly IMovieMetadataService _metadataService;
        private readonly IMovieViewModel _movieViewModel;

        public MovieSelectionViewModel(IMovieMetadataService metadataService, IMovieViewModel movieViewModel, IBusyProvider busyProvider)
            : base(busyProvider, movieViewModel.Title.Value)
        {
            _metadataService = metadataService;
            _movieViewModel = movieViewModel;
        }

        protected override async Task SaveInternal(Movie selectedItem)
        {
            await SaveNewId(selectedItem.Id, _movieViewModel.Path);
            await Update(_movieViewModel.Path);
        }

        protected override Task<IEnumerable<Movie>> SearchInternal(string searchTitle)
        {
            return _metadataService.FindMovies(searchTitle);
        }

        private async Task SaveNewId(string movieId, string path)
        {
            MovieMetadata metadata = await _metadataService.Get(path);
            metadata.Id = movieId;
            await _metadataService.Save(path, metadata);
        }

        private async Task Update(string path)
        {
            await _metadataService.DeleteImages(path);
            await _metadataService.Update(path);
            await _movieViewModel.Refresh();
        }
    }
}
