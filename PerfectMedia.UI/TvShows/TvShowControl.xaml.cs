using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PerfectMedia.UI.Selection;
using PerfectMedia.UI.Sources;
using PerfectMedia.UI.TvShows.Shows;

namespace PerfectMedia.UI.TvShows
{
    /// <summary>
    /// Interaction logic for TvShowControl.xaml
    /// </summary>
    public partial class TvShowControl
    {
        public TvShowControl()
        {
            InitializeComponent();
        }

        private void ShowSources(object sender, RoutedEventArgs e)
        {
            var sourcesWindow = new SourcesWindow { DataContext = DataContext };
            sourcesWindow.ShowDialog();
        }

        private void ShowTvShowSelection(object sender, RoutedEventArgs e)
        {
            object originalContent = BindingOperations.GetBinding(MainContentControl, ContentProperty);
            ISelectionViewModel tvShow = GetTvShowViewModel(sender);
            tvShow.OriginalContent = originalContent;
            tvShow.IsClosed = false;
            MainContentControl.Content = tvShow;
        }

        private ISelectionViewModel GetTvShowViewModel(object sender)
        {
            var frameworkElement = (FrameworkElement)sender;
            var tvShow = (ITvShowViewModel)frameworkElement.DataContext;
            return tvShow.Selection;
        }

        private async void TvShowsSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            await AsyncHelper.ExecuteEventHandlerTask(this, async () =>
            {
                var newItem = (ITreeViewItemViewModel)e.NewValue;
                await newItem.Load();
            });
        }

        private async void TvShowsExpanded(object sender, RoutedEventArgs e)
        {
            await AsyncHelper.ExecuteEventHandlerTask(this, async () =>
            {
                var treeViewItem = (TreeViewItem)e.OriginalSource;
                var treeViewItemViewModel = (ITreeViewItemViewModel)treeViewItem.DataContext;
                await treeViewItemViewModel.LoadChildren();
            });
        }
    }
}
