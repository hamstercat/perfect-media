using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PerfectMedia.UI.Sources;

namespace PerfectMedia.UI.Movies
{
    /// <summary>
    /// Interaction logic for MovieControl.xaml
    /// </summary>
    public partial class MovieControl : UserControl
    {
        public MovieControl()
        {
            InitializeComponent();
        }

        private void ShowSources(object sender, RoutedEventArgs e)
        {
            SourcesWindow sourcesWindow = new SourcesWindow { DataContext = DataContext };
            sourcesWindow.ShowDialog();
        }

        private void ShowMovieSelection(object sender, RoutedEventArgs e)
        {
            object originalContent = BindingOperations.GetBinding(MainContentControl, ContentProperty);
            IMovieViewModel movie = GetMovieViewModel(sender);
            movie.Selection.OriginalContent = originalContent;
            movie.Selection.IsClosed = false;
            MainContentControl.Content = movie.Selection;
        }

        private IMovieViewModel GetMovieViewModel(object sender)
        {
            FrameworkElement frameworkElement = (FrameworkElement)sender;
            return (IMovieViewModel)frameworkElement.DataContext;
        }

        private async void MoviesSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            await AsyncHelper.ExecuteEventHandlerTask(this, async () =>
            {
                ITreeViewItemViewModel newItem = (ITreeViewItemViewModel) e.NewValue;
                if (newItem != null)
                {
                    await newItem.Load();
                }
            });
        }
    }
}
