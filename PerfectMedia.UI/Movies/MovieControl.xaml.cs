using System.Windows;
using System.Windows.Data;
using PerfectMedia.UI.Selection;
using PerfectMedia.UI.Sources;

namespace PerfectMedia.UI.Movies
{
    /// <summary>
    /// Interaction logic for MovieControl.xaml
    /// </summary>
    public partial class MovieControl
    {
        public MovieControl()
        {
            InitializeComponent();
        }

        private void ShowSources(object sender, RoutedEventArgs e)
        {
            var sourcesWindow = new SourcesWindow { DataContext = DataContext };
            sourcesWindow.ShowDialog();
        }

        private void ShowMovieSelection(object sender, RoutedEventArgs e)
        {
            object originalContent = BindingOperations.GetBinding(MainContentControl, ContentProperty);
            ISelectionViewModel movie = GetMovieViewModel(sender);
            movie.OriginalContent = originalContent;
            movie.IsClosed = false;
            MainContentControl.Content = movie;
        }

        private ISelectionViewModel GetMovieViewModel(object sender)
        {
            var frameworkElement = (FrameworkElement)sender;
            var movie = (IMovieViewModel)frameworkElement.DataContext;
            return movie.Selection;
        }

        private async void MoviesSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            await AsyncHelper.ExecuteEventHandlerTask(this, async () =>
            {
                var newItem = (ITreeViewItemViewModel)e.NewValue;
                if (newItem != null)
                {
                    await newItem.Load();
                }
            });
        }
    }
}
