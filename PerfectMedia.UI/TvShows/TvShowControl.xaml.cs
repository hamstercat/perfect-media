using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PerfectMedia.UI.Sources;
using PerfectMedia.UI.TvShows.Shows;

namespace PerfectMedia.UI.TvShows
{
    /// <summary>
    /// Interaction logic for TvShowControl.xaml
    /// </summary>
    public partial class TvShowControl : UserControl
    {
        public TvShowControl()
        {
            InitializeComponent();
        }

        private void ShowSources(object sender, RoutedEventArgs e)
        {
            SourcesWindow sourcesWindow = new SourcesWindow { DataContext = DataContext };
            sourcesWindow.ShowDialog();
        }

        private void ShowTvShowSelection(object sender, RoutedEventArgs e)
        {
            object originalContent = BindingOperations.GetBinding(MainContentControl, ContentProperty);
            ITvShowViewModel tvShow = GetTvShowViewModel(sender);
            tvShow.Selection.OriginalContent = originalContent;
            tvShow.Selection.IsClosed = false;
            MainContentControl.Content = tvShow.Selection;
        }

        private ITvShowViewModel GetTvShowViewModel(object sender)
        {
            FrameworkElement frameworkElement = (FrameworkElement)sender;
            return (ITvShowViewModel)frameworkElement.DataContext;
        }

        private async void TvShowsSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ITreeViewItemViewModel newItem = (ITreeViewItemViewModel)e.NewValue;
            await newItem.Load();
        }

        private async void TvShowsExpanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem treeViewItem = (TreeViewItem)e.OriginalSource;
            ITreeViewItemViewModel treeViewItemViewModel = (ITreeViewItemViewModel) treeViewItem.DataContext;
            await treeViewItemViewModel.LoadChildren();
        }
    }
}
