﻿using System.Collections.Generic;
using System.Windows.Input;
using PerfectMedia.Movies;
using PerfectMedia.UI.Busy;
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

        public MovieSelectionViewModel(IMovieMetadataService metadataService, IMovieViewModel movieViewModel, IBusyProvider busyProvider)
        {
            SearchCommand = new SearchCommand(metadataService, this, busyProvider);
            Selection = new SelectionViewModel<Movie>(busyProvider, async movie =>
            {
                await SaveNewId(metadataService, movie.Id, movieViewModel.Path);
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

        private async Task SaveNewId(IMovieMetadataService metadataService, string movieId, string path)
        {
            MovieMetadata metadata = await metadataService.Get(path);
            metadata.Id = movieId;
            await metadataService.Save(path, metadata);
        }

        private async Task Update(IMovieMetadataService metadataService, IMovieViewModel movieViewModel, string path)
        {
            await metadataService.DeleteImages(path);
            await metadataService.Update(path);
            await movieViewModel.Refresh();
        }
    }
}
